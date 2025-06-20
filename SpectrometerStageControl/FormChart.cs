using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SpectrometerStageControl
{
    public partial class FormChart : Form, IChartView
    {
        private MainPresenter presenter;
        private bool range;

        public FormChart(MainPresenter presenter, bool range = false)
        {
            InitializeComponent();

            this.range = range;
            this.presenter = presenter;
            this.presenter.AddChartView(this);

            initialize();
            UpdateDisplay();
        }

        private void initialize()
        {

            chart1.ChartAreas[0].AxisX.Title = "Wavelength";
            chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(presenter.SpectrumData.Wavelengths.Min());
            chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(presenter.SpectrumData.Wavelengths.Max());

            chart1.ChartAreas[0].AxisY.Title = "Intensity";
            chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(presenter.SpectrumData.Intensities.Min());
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(presenter.SpectrumData.Intensities.Max());
        }

        public void UpdateDisplay()
        {
            chart1.Series.Clear();

            Series series = new Series();
            series.ChartArea = chart1.ChartAreas[0].Name;
            series.ChartType = SeriesChartType.FastLine;
            //series.ChartType = SeriesChartType.Column;
            series.Name = "Intensities";

            var waves = presenter.SpectrumData.Wavelengths;
            var intensities = (cbNormalize.Checked) ? presenter.SpectrumData.IntensitiesNormalized : presenter.SpectrumData.Intensities;

            var points = series.Points;
            for (int i = 0; i < presenter.SpectrumData.Wavelengths.Length; i++)
            {
                points.AddXY(waves[i], intensities[i]);
            }

            chart1.Series.Add(series);
        }

        private void updateChartAxes(bool normalize)
        {
            if (normalize)
            {
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 1;
                chart1.ChartAreas[0].CursorY.Interval = 0.01;
            }
            else
            {
                chart1.ChartAreas[0].AxisY.Minimum = presenter.SpectrumData.Intensities.Min();
                chart1.ChartAreas[0].AxisY.Maximum = presenter.SpectrumData.Intensities.Max();
                chart1.ChartAreas[0].CursorY.Interval = 0.1;
            }
            UpdateDisplay();
        }

        private void cbStart_CheckedChanged(object sender, EventArgs e)
        {
            tmrUpdate.Enabled = cbStart.Checked;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (range)
                presenter.GetSpectrumAtRange();
            else
                presenter.GetFullSpectrum();
        }

        private void FormChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            presenter.RemoveChartView();
        }

        private void chart1_CursorPositionChanging(object sender, CursorEventArgs e)
        {
            if (e.Axis.AxisName == AxisName.X)
                lblXPos.Text = e.NewPosition.ToString();
            else if (e.Axis.AxisName == AxisName.Y)
                lblYPos.Text = e.NewPosition.ToString();
        }

        private void cbNormalize_CheckedChanged(object sender, EventArgs e)
        {
            updateChartAxes(cbNormalize.Checked);
        }
    }
}
