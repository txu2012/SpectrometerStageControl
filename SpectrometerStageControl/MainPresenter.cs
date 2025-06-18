using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public interface IChartView : IView
    { }

    public class MainPresenter
    {
        #region Class Members
        public StageControl Stage;
        public SpectrometerControl Spectrometer;
        private IMainView mainView;
        private IChartView chartView;

        public List<string> StageDevices { get { return Stage.GetDevices(); } }
        public List<SpectrometerDevice> SpectrometerDevices { get { return Spectrometer.GetDevices(); } }
        public double[] Wavelengths { get { return Spectrometer.Wavelengths; } }
        public bool SpectrometerConnected { get { return Spectrometer.Connected; } }
        public bool StageConnected { get { return Stage.IsConnected; } }
        #endregion

        public MainPresenter() 
        {
            Spectrometer = new SpectrometerControl();
            Stage = new StageControl();
        }

        #region Connection
        public void ConnectStage(string serialNumber)
        {

        }

        public void DisconnectStage()
        {

        }

        public void ConnectSpectrometer(int index)
        {

        }

        public void DisconnectSpectrometer()
        {

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

        public void RunLength()
        {

        }

        #region Spectrometer
        public double[] GetSpectrum()
        {
            return Spectrometer.GetFullSpectrum();
        }
        #endregion

        #region Stage
        #endregion
    }
}
