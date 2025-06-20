using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpectrometerStageControl
{
    
    public interface IView
    {
        void UpdateDisplay();
    }
    public interface IMainView : IView
    {
        void Log(string msg);
    }

    public interface IChartView : IView { }

    public struct SpectrumData
    {
        private double[] wavelengths;
        private double[] intensities;
        public double[] Wavelengths 
        { 
            get 
            { 
                return this.wavelengths; 
            } 
            set
            {
                this.wavelengths = value;
            }
        }
        public double[] Intensities 
        { 
            get 
            { 
                return this.intensities; 
            } 
            set
            {
                this.intensities = value;
            }
        }

        public double[] WavelengthsNormalized
        {
            get
            {
                return normalize(this.wavelengths);
            }
        }

        public double[] IntensitiesNormalized
        {
            get
            {
                return normalize(this.intensities);
            }
        }
        private double[] normalize(double[] data)
        {
            return data.Select(d => d/data.Max()).ToArray();
        }

        public SpectrumData(double[] wave, double[] intensities)
        {
            this.wavelengths = wave;
            this.intensities = intensities;

        }
        public SpectrumData DeepCopy()
        {
            return new SpectrumData(this.Wavelengths, this.Intensities);
        }
    }

    public class MainPresenter
    {
        #region Class Members
        public StageControl Stage;
        public SpectrometerControl Spectrometer;
        private IMainView mainView;
        private IChartView chartView;

        public List<string> StageDevices { get { return Stage.GetDevices(); } }

        private List<SpectrometerDevice> spectrometerDevices;
        public List<SpectrometerDevice> SpectrometerDevices { get { return spectrometerDevices; } }
        public bool SpectrometerConnected { get { return Spectrometer.Connected; } }
        public bool StageConnected { get { return Stage.IsConnected; } }

        private SpectrumData spectrumData;
        public SpectrumData SpectrumData { get { return spectrumData; } }
        public double CenterWavelength { get; set; } = 400;
        public double WavelengthRange { get; set; } = 100;
        public long IntegrationTime_us { get; set; } = 10000;

        public decimal MoveBy_mm { get; set; } = 0.000899m;
        public decimal MoveRange_mm { get; set; } = 1.00000m;
        public int TimeMove_fs { get; set; } = 3;
        public int TimeRange_fs { get; set; } = 3335;
        #endregion

        public MainPresenter() 
        {
            Spectrometer = new SpectrometerControl();
            Stage = new StageControl();

            spectrumData = new SpectrumData()
            {
                Wavelengths = new double[] { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 },
                Intensities = new double[] { 10, 20, 30, 40, 32, 31, 22, 6, 2, 1 }
            };
        }

        #region Connection
        public void ConnectStage(string serialNumber)
        {
            try
            {
                Stage.Connect(serialNumber);

                mainView.Log($"Connected to stage {serialNumber}");
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to connect to stage {serialNumber}. {ex.Message}");
            }
        }

        public void DisconnectStage()
        {
            try
            {
                Stage.Disconnect();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to disconnect from stage. {ex.Message}");
            }
        }

        public void ConnectSpectrometer(int index)
        {
            try
            {
                Spectrometer.Connect(index);

                mainView.Log($"Connected to spectrometer {SpectrometerDevices[index].Id} {SpectrometerDevices[index].Name}");
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to connect to spectrometer {index}. {ex.Message}");
            }
        }

        public void DisconnectSpectrometer()
        {
            try
            {
                Spectrometer.Disconnect();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to disconnect from spectrometer. {ex.Message}");
            }
        }
        #endregion

        public void AddMainView(IMainView view)
        {
            mainView = view;
        }

        public void AddChartView(IChartView view)
        {
            chartView = view;
        }

        public void RemoveChartView()
        {
            chartView = null;
        }

        public void RunLength(
            decimal moveBy_mm,
            decimal moveRange_mm,
            double centerWl_nm,
            double wlRange_nm,
            long integration_us)
        {
            try
            {
                mainView.Log($"Starting set.");
                // Steps(distance), Wavelengths, Spectrum
                List<(int, SpectrumData)> data = new List<(int, SpectrumData)>();

                decimal initialPosition = -moveRange_mm;
                decimal finalPosition = moveRange_mm;
                CenterWavelength = centerWl_nm;
                WavelengthRange = wlRange_nm;
                int step = 0;

                mainView.Log($"Setting integration time to {integration_us}.");
                // Set integration time
                SetIntegrationTime(integration_us);

                // Move to intial position and wait until finished
                mainView.Log($"Moving to initial position: {initialPosition} mm.");
                StageMoveTo(initialPosition);
                WaitForStage();

                // Get first set of data
                GetSpectrumAtRange();
                data.Add((step, SpectrumData.DeepCopy()));

                while (Stage.CurrentPosition < finalPosition)
                {
                    // Move to next position
                    StageMoveRelative(true, moveBy_mm);
                    WaitForStage();
                    mainView.UpdateDisplay();
                    mainView.Log($"Moved stage {moveBy_mm} mm Forward. Current position: {Stage.CurrentPosition}");

                    // Increment time/step
                    step++;

                    // Acquire Spectrum range
                    GetSpectrumAtRange();

                    // Append new data
                    data.Add((step, SpectrumData.DeepCopy()));
                }

                mainView.Log($"Finished running set.");
            }
            catch (Exception ex)
            {
                StageStop();
                mainView.Log($"Error occured while running set. Stopping. {ex.Message}");
            }
        }

        private void WaitForStage()
        { 
            while(Stage.StageState != MotorState.Stopped)
            {
                mainView.UpdateDisplay();
                Thread.Sleep(100);
            }
        }

        #region Spectrometer
        public void RefreshSpectrometerDevices()
        {
            try
            {
                spectrometerDevices = Spectrometer.GetDevices();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to refresh spectrometer list. {ex.Message}");
            }
        }
        public void GetFullSpectrum()
        {
            try
            {
                if (!SpectrometerConnected) throw new InvalidOperationException("Spectrometer Not Connected.");

                var (wavelengths, spectrum) = Spectrometer.GetFullSpectrum();
                spectrumData.Wavelengths = wavelengths;
                spectrumData.Intensities = spectrum;

                if (chartView != null) chartView.UpdateDisplay();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to acquire full spectrum from spectrometer. {ex.Message}");
            }
        }

        public void GetSpectrumAtRange()
        {
            try
            {
                double lo = CenterWavelength - WavelengthRange;
                double hi = CenterWavelength + WavelengthRange;
                if (!SpectrometerConnected) 
                    throw new InvalidOperationException("Spectrometer Not Connected.");
                if ((lo < Spectrometer.Wavelengths[0]) || 
                    (hi > Spectrometer.Wavelengths[Spectrometer.Wavelengths.Length-1])) 
                    throw new InvalidOperationException("Wavelength range not within range of spectrometer.");

                var spec = Spectrometer.GetSpectrumAtRange(lo, hi);
                var wavelengths = spec.Select(s => s.Item1).ToArray();
                var spectrum = spec.Select(s => s.Item2).ToArray();
                spectrumData.Wavelengths = wavelengths;
                spectrumData.Intensities = spectrum;

                if (chartView != null) chartView.UpdateDisplay();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to acquire spectrum range from spectrometer. {ex.Message}");
            }
        }

        public void SetIntegrationTime(long timeUs)
        {
            try
            {
                if (!SpectrometerConnected) throw new InvalidOperationException("Spectrometer Not Connected.");

                Spectrometer.SetIntegrationTime(timeUs);
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to acquire spectrum range from spectrometer. {ex.Message}");
            }
        }
        #endregion

        #region Stage
        public void StageHome()
        {
            try
            {
                if (!StageConnected) throw new InvalidOperationException("Stage Not Connected.");
                
                Stage.Home();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to home stage. {ex.Message}");
            }
        }

        public void StageMoveRelative(bool direction, decimal moveBy_mm)
        {
            try
            {
                if (!StageConnected) throw new InvalidOperationException("Stage Not Connected.");

                Stage.MoveRelative(direction, moveBy_mm);
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to move stage {moveBy_mm} mm {((direction) ? "Forward" : "Backward")}. {ex.Message}");
            }
        }

        public void StageMoveContinuous(bool direction)
        {
            try
            {
                if (!StageConnected) throw new InvalidOperationException("Stage Not Connected.");

                Stage.MoveContiuous(direction);
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to move stage continuously {((direction) ? "Forward" : "Backward")}. {ex.Message}");
            }
        }

        public void StageStop()
        {
            try
            {
                if (!StageConnected) throw new InvalidOperationException("Stage Not Connected.");

                Stage.Stop();
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to stop stage. {ex.Message}");
            }
        }

        public void StageMoveTo(decimal targetPos_mm)
        {
            try
            {
                if (!StageConnected) throw new InvalidOperationException("Stage Not Connected.");

                Stage.MoveTo(targetPos_mm);
            }
            catch (Exception ex)
            {
                mainView.Log($"Failed to move stage to position {targetPos_mm} mm. {ex.Message}");
            }
        }
        #endregion

        public decimal FemtosecondToMm(int timeFs)
        {
            // Mm / s
            long lightSpeed_mps = 299792458000;
            double timeS = timeFs / 1_000_000_000_000_000.0;
            return (decimal)(lightSpeed_mps * (timeS));
        }
    }
}
