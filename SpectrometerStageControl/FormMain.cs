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
    public partial class FormMain : Form, IMainView
    {
        #region Class Members
        private MainPresenter presenter;
        #endregion

        public FormMain()
        {
            InitializeComponent();

            this.presenter = new MainPresenter();
            this.presenter.AddMainView(this);

            RefreshStage();
            RefreshSpectrometer();
            UpdateDisplay();
        }

        private bool updatingDisplay = false;
        private FormChart formChart;
        #region Interface Functions
        public void UpdateDisplay() 
        {
            updatingDisplay = true;

            if (presenter.StageConnected)
            {
                btnStageConnect.Enabled = false;
                btnStageRefresh.Enabled = false;
                btnStageDisconnect.Enabled = true;
                cbStage.Enabled = false;
            }
            else
            {
                btnStageConnect.Enabled = true;
                btnStageRefresh.Enabled = true;
                btnStageDisconnect.Enabled = false;
                cbStage.Enabled = true;
            }

            if (presenter.SpectrometerConnected)
            {
                btnSpecConnect.Enabled = false;
                btnSpecRefresh.Enabled = false;
                btnSpecDisconnect.Enabled = true;
                cbSpectrometer.Enabled = false;
            }
            else
            {
                btnSpecConnect.Enabled = true;
                btnSpecRefresh.Enabled = true;
                btnSpecDisconnect.Enabled = false;
                cbSpectrometer.Enabled = true;
            }

            //pnControl.Enabled = (presenter.SpectrometerConnected || presenter.StageConnected);
            //gbStage.Enabled = presenter.StageConnected;
            //gbSpectrometer.Enabled = presenter.SpectrometerConnected;

            if (gbStage.Enabled)
                UpdateStageDisplay();

            if (gbSpectrometer.Enabled)
                UpdateSpectrometerDisplay();

            updatingDisplay = false;
        }

        private void UpdateStageDisplay()
        {
            if (presenter.StageConnected)
            {
                txtHomed.Text = (presenter.Stage.IsHomed) ? "Yes" : "No";
                txtPosition.Text = presenter.Stage.CurrentPosition.ToString();

                nudStageMoveBy.Value = (decimal)presenter.MoveBy_mm;
                nudStageRange.Value = (decimal)presenter.MoveRange_mm;
            }
        }

        private void UpdateSpectrometerDisplay()
        {
            if (presenter.SpectrometerConnected)
            {
                nudCenterWave.Value = (decimal)presenter.CenterWavelength;
                nudWaveRange.Value = (decimal)presenter.WavelengthRange;
                nudIntegrationUs.Value = (decimal)presenter.IntegrationTime_us;
            }
        }

        public void Log(string msg) 
        {
            rtbLog.AppendText(msg + "\r\n\r\n");
            rtbLog.ScrollToCaret();
        }

        private void RefreshStage()
        {
            cbStage.DataSource = presenter.StageDevices;
        }

        private void RefreshSpectrometer()
        {
            presenter.RefreshSpectrometerDevices();
            cbStage.DataSource = presenter.SpectrometerDevices.Select(x => x.Id + "" + x.Name).ToList();
        }
        #endregion

        #region Connection
        private void btnStageConnect_Click(object sender, EventArgs e)
        {
            if (cbStage.SelectedItem != null)
                presenter.ConnectStage((string)cbStage.SelectedItem);

            UpdateDisplay();
        }

        private void btnSpecConnect_Click(object sender, EventArgs e)
        {
            if (cbSpectrometer.SelectedItem != null)
                presenter.ConnectSpectrometer(cbSpectrometer.SelectedIndex);

            UpdateDisplay();
        }

        private void btnStageDisconnect_Click(object sender, EventArgs e)
        {
            if (presenter.StageConnected)
                presenter.DisconnectStage();

            UpdateDisplay();
        }

        private void btnSpecDisconnect_Click(object sender, EventArgs e)
        {
            if (presenter.SpectrometerConnected)
                presenter.DisconnectSpectrometer();

            UpdateDisplay();
        }

        private void btnSpecRefresh_Click(object sender, EventArgs e)
        {
            RefreshSpectrometer();
            UpdateDisplay();
        }

        private void btnStageRefresh_Click(object sender, EventArgs e)
        {
            RefreshStage();
            UpdateDisplay();
        }
        #endregion

        #region Stage Control
        private void btnHome_Click(object sender, EventArgs e)
        {
            presenter.StageHome();
            tmrMain.Enabled = true;
        }

        private void btnStageStop_Click(object sender, EventArgs e)
        {
            presenter.StageStop();
            tmrMain.Enabled = true;
        }

        private void btnMoveByNeg_Click(object sender, EventArgs e)
        {
            presenter.StageMoveRelative(false, nudStageMoveBy.Value);
            tmrMain.Enabled = true;
        }

        private void btnMoveByPos_Click(object sender, EventArgs e)
        {
            presenter.StageMoveRelative(true, nudStageMoveBy.Value);
            tmrMain.Enabled = true;
        }

        private void btnContFwd_Click(object sender, EventArgs e)
        {
            presenter.StageMoveContinuous(true);
            tmrMain.Enabled = true;
        }

        private void btnContBack_Click(object sender, EventArgs e)
        {
            presenter.StageMoveContinuous(false);
            tmrMain.Enabled = true;
        }

        private void nudStageMoveBy_ValueChanged(object sender, EventArgs e)
        {
            if (updatingDisplay) return;
            presenter.MoveBy_mm = (decimal)nudStageMoveBy.Value;

            UpdateDisplay();
        }

        private void nudStageRange_ValueChanged(object sender, EventArgs e)
        {
            if (updatingDisplay) return;
            presenter.MoveRange_mm = (decimal)nudStageRange.Value;

            UpdateDisplay();
        }
        #endregion

        #region Spectrometer Control

        private void btnSpectrumFull_Click(object sender, EventArgs e)
        {
            presenter.GetFullSpectrum();
        }

        private void btnSpectrumRange_Click(object sender, EventArgs e)
        {
            presenter.GetSpectrumAtRange();
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            if (formChart == null || formChart.IsDisposed)
                formChart = new FormChart(presenter);

            formChart.Show();
        }

        private void nudCenterWave_ValueChanged(object sender, EventArgs e)
        {
            if (updatingDisplay) return;
            presenter.CenterWavelength = (double)nudCenterWave.Value;

            UpdateDisplay();
        }

        private void nudWaveRange_ValueChanged(object sender, EventArgs e)
        {
            if (updatingDisplay) return;
            presenter.WavelengthRange = (double)nudWaveRange.Value;

            UpdateDisplay();
        }

        private void nudWaveInc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudIntegrationUs_ValueChanged(object sender, EventArgs e)
        {
            if (updatingDisplay) return;
            presenter.IntegrationTime_us = (long)nudIntegrationUs.Value;

            UpdateDisplay();
        }
        #endregion

        private void btnRun_Click(object sender, EventArgs e)
        {
            presenter.RunLength(
                nudStageMoveBy.Value,
                nudStageRange.Value,
                (double)nudCenterWave.Value,
                (double)nudWaveRange.Value,
                (long)nudIntegrationUs.Value);
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            if (presenter.Stage.StageState != MotorState.Stopped)
            {
                UpdateStageDisplay();
            }
            else
            {
                tmrMain.Enabled = false;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (presenter.StageConnected)
                presenter.DisconnectStage();
            if (presenter.SpectrometerConnected)
                presenter.DisconnectSpectrometer();
            
            presenter.Stage.Dispose();
            presenter.Spectrometer.Dispose();
        }
    }
}
