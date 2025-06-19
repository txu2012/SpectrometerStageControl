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
        }

        private void initialize()
        {
            chart1.ChartAreas[0].AxisX.Title = "Wavelength";
            chart1.ChartAreas[0].AxisX.Minimum = Math.Floor(presenter.Wavelengths[0]);
            chart1.ChartAreas[0].AxisX.Maximum = Math.Ceiling(presenter.Wavelengths[presenter.Wavelengths.Length-1]);

            chart1.ChartAreas[0].AxisY.Title = "Spectrum";
            chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(presenter.Spectrum[0]);
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(presenter.Spectrum[presenter.Spectrum.Length - 1]);
        }

        public void UpdateDisplay()
        {
            chart1.Series.Clear();

            Series series = new Series();
            series.ChartArea = chart1.ChartAreas[0].Name;
            series.ChartType = SeriesChartType.FastLine;
            series.Name = "Spectrum";

            var points = series.Points;
            for (int i = 0; i < presenter.Wavelengths.Length; i++)
            {
                points.AddXY(presenter.Wavelengths[i], presenter.Spectrum[i]);
            }

            chart1.Series.Add(series);
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
    }
}
