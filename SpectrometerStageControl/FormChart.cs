using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpectrometerStageControl
{
    public partial class FormChart : Form, IChartView
    {
        private MainPresenter presenter;
        private double[] wavelengths;
        public FormChart(MainPresenter presenter)
        {
            InitializeComponent();

            this.presenter = presenter;
            this.presenter.AddChartView(this);


            this.wavelengths = presenter.Wavelengths;
        }

        public void UpdateDisplay()
        {

        }

    }
}
