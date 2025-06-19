
namespace SpectrometerStageControl
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.btnSpecRefresh = new System.Windows.Forms.Button();
            this.btnSpecDisconnect = new System.Windows.Forms.Button();
            this.btnSpecConnect = new System.Windows.Forms.Button();
            this.btnStageDisconnect = new System.Windows.Forms.Button();
            this.btnStageConnect = new System.Windows.Forms.Button();
            this.btnStageRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSpectrometer = new System.Windows.Forms.ComboBox();
            this.cbStage = new System.Windows.Forms.ComboBox();
            this.pnControl = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.gbSpectrometer = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nudIntegrationUs = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudCenterWave = new System.Windows.Forms.NumericUpDown();
            this.btnChart = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudWaveInc = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudWaveRange = new System.Windows.Forms.NumericUpDown();
            this.btnSpectrumFull = new System.Windows.Forms.Button();
            this.btnSpectrumRange = new System.Windows.Forms.Button();
            this.gbStage = new System.Windows.Forms.GroupBox();
            this.btnContFwd = new System.Windows.Forms.Button();
            this.btnContBack = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStageRange = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtHomed = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudStageMoveBy = new System.Windows.Forms.NumericUpDown();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnMoveByPos = new System.Windows.Forms.Button();
            this.btnMoveByNeg = new System.Windows.Forms.Button();
            this.btnStageStop = new System.Windows.Forms.Button();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.gbConnection.SuspendLayout();
            this.pnControl.SuspendLayout();
            this.gbSpectrometer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrationUs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaveInc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaveRange)).BeginInit();
            this.gbStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStageRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStageMoveBy)).BeginInit();
            this.SuspendLayout();
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.btnSpecRefresh);
            this.gbConnection.Controls.Add(this.btnSpecDisconnect);
            this.gbConnection.Controls.Add(this.btnSpecConnect);
            this.gbConnection.Controls.Add(this.btnStageDisconnect);
            this.gbConnection.Controls.Add(this.btnStageConnect);
            this.gbConnection.Controls.Add(this.btnStageRefresh);
            this.gbConnection.Controls.Add(this.label2);
            this.gbConnection.Controls.Add(this.label1);
            this.gbConnection.Controls.Add(this.cbSpectrometer);
            this.gbConnection.Controls.Add(this.cbStage);
            this.gbConnection.Location = new System.Drawing.Point(10, 10);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(782, 78);
            this.gbConnection.TabIndex = 0;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // btnSpecRefresh
            // 
            this.btnSpecRefresh.Location = new System.Drawing.Point(458, 48);
            this.btnSpecRefresh.Name = "btnSpecRefresh";
            this.btnSpecRefresh.Size = new System.Drawing.Size(75, 21);
            this.btnSpecRefresh.TabIndex = 9;
            this.btnSpecRefresh.Text = "Refresh";
            this.btnSpecRefresh.UseVisualStyleBackColor = true;
            this.btnSpecRefresh.Click += new System.EventHandler(this.btnSpecRefresh_Click);
            // 
            // btnSpecDisconnect
            // 
            this.btnSpecDisconnect.Location = new System.Drawing.Point(382, 48);
            this.btnSpecDisconnect.Name = "btnSpecDisconnect";
            this.btnSpecDisconnect.Size = new System.Drawing.Size(75, 21);
            this.btnSpecDisconnect.TabIndex = 8;
            this.btnSpecDisconnect.Text = "Disconnect";
            this.btnSpecDisconnect.UseVisualStyleBackColor = true;
            this.btnSpecDisconnect.Click += new System.EventHandler(this.btnSpecDisconnect_Click);
            // 
            // btnSpecConnect
            // 
            this.btnSpecConnect.Location = new System.Drawing.Point(306, 48);
            this.btnSpecConnect.Name = "btnSpecConnect";
            this.btnSpecConnect.Size = new System.Drawing.Size(75, 21);
            this.btnSpecConnect.TabIndex = 7;
            this.btnSpecConnect.Text = "Connect";
            this.btnSpecConnect.UseVisualStyleBackColor = true;
            this.btnSpecConnect.Click += new System.EventHandler(this.btnSpecConnect_Click);
            // 
            // btnStageDisconnect
            // 
            this.btnStageDisconnect.Location = new System.Drawing.Point(382, 22);
            this.btnStageDisconnect.Name = "btnStageDisconnect";
            this.btnStageDisconnect.Size = new System.Drawing.Size(75, 21);
            this.btnStageDisconnect.TabIndex = 6;
            this.btnStageDisconnect.Text = "Disconnect";
            this.btnStageDisconnect.UseVisualStyleBackColor = true;
            this.btnStageDisconnect.Click += new System.EventHandler(this.btnStageDisconnect_Click);
            // 
            // btnStageConnect
            // 
            this.btnStageConnect.Location = new System.Drawing.Point(306, 22);
            this.btnStageConnect.Name = "btnStageConnect";
            this.btnStageConnect.Size = new System.Drawing.Size(75, 21);
            this.btnStageConnect.TabIndex = 5;
            this.btnStageConnect.Text = "Connect";
            this.btnStageConnect.UseVisualStyleBackColor = true;
            this.btnStageConnect.Click += new System.EventHandler(this.btnStageConnect_Click);
            // 
            // btnStageRefresh
            // 
            this.btnStageRefresh.Location = new System.Drawing.Point(458, 22);
            this.btnStageRefresh.Name = "btnStageRefresh";
            this.btnStageRefresh.Size = new System.Drawing.Size(75, 21);
            this.btnStageRefresh.TabIndex = 4;
            this.btnStageRefresh.Text = "Refresh";
            this.btnStageRefresh.UseVisualStyleBackColor = true;
            this.btnStageRefresh.Click += new System.EventHandler(this.btnStageRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Spectrometer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stage";
            // 
            // cbSpectrometer
            // 
            this.cbSpectrometer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpectrometer.FormattingEnabled = true;
            this.cbSpectrometer.Location = new System.Drawing.Point(84, 48);
            this.cbSpectrometer.Name = "cbSpectrometer";
            this.cbSpectrometer.Size = new System.Drawing.Size(214, 21);
            this.cbSpectrometer.TabIndex = 1;
            // 
            // cbStage
            // 
            this.cbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStage.FormattingEnabled = true;
            this.cbStage.Location = new System.Drawing.Point(84, 22);
            this.cbStage.Name = "cbStage";
            this.cbStage.Size = new System.Drawing.Size(214, 21);
            this.cbStage.TabIndex = 0;
            // 
            // pnControl
            // 
            this.pnControl.Controls.Add(this.btnRun);
            this.pnControl.Controls.Add(this.gbSpectrometer);
            this.pnControl.Controls.Add(this.gbStage);
            this.pnControl.Location = new System.Drawing.Point(2, 108);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(434, 450);
            this.pnControl.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(314, 396);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(105, 32);
            this.btnRun.TabIndex = 11;
            this.btnRun.Text = "Run Set";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(438, 118);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(354, 440);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.Text = "";
            // 
            // gbSpectrometer
            // 
            this.gbSpectrometer.Controls.Add(this.label13);
            this.gbSpectrometer.Controls.Add(this.nudIntegrationUs);
            this.gbSpectrometer.Controls.Add(this.label10);
            this.gbSpectrometer.Controls.Add(this.nudCenterWave);
            this.gbSpectrometer.Controls.Add(this.btnChart);
            this.gbSpectrometer.Controls.Add(this.label6);
            this.gbSpectrometer.Controls.Add(this.label5);
            this.gbSpectrometer.Controls.Add(this.nudWaveInc);
            this.gbSpectrometer.Controls.Add(this.label4);
            this.gbSpectrometer.Controls.Add(this.nudWaveRange);
            this.gbSpectrometer.Controls.Add(this.btnSpectrumFull);
            this.gbSpectrometer.Controls.Add(this.btnSpectrumRange);
            this.gbSpectrometer.Location = new System.Drawing.Point(8, 202);
            this.gbSpectrometer.Name = "gbSpectrometer";
            this.gbSpectrometer.Size = new System.Drawing.Size(420, 174);
            this.gbSpectrometer.TabIndex = 1;
            this.gbSpectrometer.TabStop = false;
            this.gbSpectrometer.Text = "Spectrometer";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Integration Time (µs)";
            // 
            // nudIntegrationUs
            // 
            this.nudIntegrationUs.Location = new System.Drawing.Point(154, 74);
            this.nudIntegrationUs.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIntegrationUs.Name = "nudIntegrationUs";
            this.nudIntegrationUs.Size = new System.Drawing.Size(70, 20);
            this.nudIntegrationUs.TabIndex = 15;
            this.nudIntegrationUs.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudIntegrationUs.ValueChanged += new System.EventHandler(this.nudIntegrationUs_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Center Wavelength (nm)";
            // 
            // nudCenterWave
            // 
            this.nudCenterWave.Location = new System.Drawing.Point(154, 22);
            this.nudCenterWave.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCenterWave.Name = "nudCenterWave";
            this.nudCenterWave.Size = new System.Drawing.Size(70, 20);
            this.nudCenterWave.TabIndex = 13;
            this.nudCenterWave.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.nudCenterWave.ValueChanged += new System.EventHandler(this.nudCenterWave_ValueChanged);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(8, 132);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(105, 32);
            this.btnChart.TabIndex = 12;
            this.btnChart.Text = "Chart";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(148, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Capture";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(12, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Wavelength Increment (nm)";
            this.label5.Visible = false;
            // 
            // nudWaveInc
            // 
            this.nudWaveInc.Enabled = false;
            this.nudWaveInc.Location = new System.Drawing.Point(154, 100);
            this.nudWaveInc.Name = "nudWaveInc";
            this.nudWaveInc.Size = new System.Drawing.Size(70, 20);
            this.nudWaveInc.TabIndex = 9;
            this.nudWaveInc.Visible = false;
            this.nudWaveInc.ValueChanged += new System.EventHandler(this.nudWaveInc_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Wavelength Range +/- (nm)";
            // 
            // nudWaveRange
            // 
            this.nudWaveRange.Location = new System.Drawing.Point(154, 48);
            this.nudWaveRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWaveRange.Name = "nudWaveRange";
            this.nudWaveRange.Size = new System.Drawing.Size(70, 20);
            this.nudWaveRange.TabIndex = 5;
            this.nudWaveRange.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudWaveRange.ValueChanged += new System.EventHandler(this.nudWaveRange_ValueChanged);
            // 
            // btnSpectrumFull
            // 
            this.btnSpectrumFull.Location = new System.Drawing.Point(196, 132);
            this.btnSpectrumFull.Name = "btnSpectrumFull";
            this.btnSpectrumFull.Size = new System.Drawing.Size(105, 32);
            this.btnSpectrumFull.TabIndex = 4;
            this.btnSpectrumFull.Text = "Spectrum (Full)";
            this.btnSpectrumFull.UseVisualStyleBackColor = true;
            this.btnSpectrumFull.Click += new System.EventHandler(this.btnSpectrumFull_Click);
            // 
            // btnSpectrumRange
            // 
            this.btnSpectrumRange.Location = new System.Drawing.Point(306, 132);
            this.btnSpectrumRange.Name = "btnSpectrumRange";
            this.btnSpectrumRange.Size = new System.Drawing.Size(105, 32);
            this.btnSpectrumRange.TabIndex = 3;
            this.btnSpectrumRange.Text = "Spectrum (Range)";
            this.btnSpectrumRange.UseVisualStyleBackColor = true;
            this.btnSpectrumRange.Click += new System.EventHandler(this.btnSpectrumRange_Click);
            // 
            // gbStage
            // 
            this.gbStage.Controls.Add(this.btnContFwd);
            this.gbStage.Controls.Add(this.btnContBack);
            this.gbStage.Controls.Add(this.label12);
            this.gbStage.Controls.Add(this.label11);
            this.gbStage.Controls.Add(this.label3);
            this.gbStage.Controls.Add(this.nudStageRange);
            this.gbStage.Controls.Add(this.label9);
            this.gbStage.Controls.Add(this.label8);
            this.gbStage.Controls.Add(this.txtPosition);
            this.gbStage.Controls.Add(this.txtHomed);
            this.gbStage.Controls.Add(this.label7);
            this.gbStage.Controls.Add(this.nudStageMoveBy);
            this.gbStage.Controls.Add(this.btnHome);
            this.gbStage.Controls.Add(this.btnMoveByPos);
            this.gbStage.Controls.Add(this.btnMoveByNeg);
            this.gbStage.Controls.Add(this.btnStageStop);
            this.gbStage.Location = new System.Drawing.Point(8, 6);
            this.gbStage.Name = "gbStage";
            this.gbStage.Size = new System.Drawing.Size(420, 190);
            this.gbStage.TabIndex = 0;
            this.gbStage.TabStop = false;
            this.gbStage.Text = "Stage";
            // 
            // btnContFwd
            // 
            this.btnContFwd.Location = new System.Drawing.Point(186, 66);
            this.btnContFwd.Name = "btnContFwd";
            this.btnContFwd.Size = new System.Drawing.Size(84, 32);
            this.btnContFwd.TabIndex = 23;
            this.btnContFwd.Text = "Continuous (+)";
            this.btnContFwd.UseVisualStyleBackColor = true;
            this.btnContFwd.Click += new System.EventHandler(this.btnContFwd_Click);
            // 
            // btnContBack
            // 
            this.btnContBack.Location = new System.Drawing.Point(10, 66);
            this.btnContBack.Name = "btnContBack";
            this.btnContBack.Size = new System.Drawing.Size(84, 32);
            this.btnContBack.TabIndex = 22;
            this.btnContBack.Text = "Continuous (-)";
            this.btnContBack.UseVisualStyleBackColor = true;
            this.btnContBack.Click += new System.EventHandler(this.btnContBack_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "For Run Button";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "(+/- From Home Position)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Movement Range (mm)";
            // 
            // nudStageRange
            // 
            this.nudStageRange.DecimalPlaces = 6;
            this.nudStageRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudStageRange.Location = new System.Drawing.Point(142, 150);
            this.nudStageRange.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            262144});
            this.nudStageRange.Name = "nudStageRange";
            this.nudStageRange.Size = new System.Drawing.Size(74, 20);
            this.nudStageRange.TabIndex = 18;
            this.nudStageRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStageRange.ValueChanged += new System.EventHandler(this.nudStageRange_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Homed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Current Position (mm)";
            // 
            // txtPosition
            // 
            this.txtPosition.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtPosition.Enabled = false;
            this.txtPosition.Location = new System.Drawing.Point(314, 38);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(86, 20);
            this.txtPosition.TabIndex = 15;
            // 
            // txtHomed
            // 
            this.txtHomed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtHomed.Enabled = false;
            this.txtHomed.Location = new System.Drawing.Point(246, 38);
            this.txtHomed.Name = "txtHomed";
            this.txtHomed.Size = new System.Drawing.Size(52, 20);
            this.txtHomed.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Move By (mm)";
            // 
            // nudStageMoveBy
            // 
            this.nudStageMoveBy.DecimalPlaces = 6;
            this.nudStageMoveBy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.nudStageMoveBy.Location = new System.Drawing.Point(142, 108);
            this.nudStageMoveBy.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            262144});
            this.nudStageMoveBy.Name = "nudStageMoveBy";
            this.nudStageMoveBy.Size = new System.Drawing.Size(74, 20);
            this.nudStageMoveBy.TabIndex = 12;
            this.nudStageMoveBy.Value = new decimal(new int[] {
            8,
            0,
            0,
            262144});
            this.nudStageMoveBy.ValueChanged += new System.EventHandler(this.nudStageMoveBy_ValueChanged);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(10, 22);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(72, 32);
            this.btnHome.TabIndex = 6;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnMoveByPos
            // 
            this.btnMoveByPos.Location = new System.Drawing.Point(314, 102);
            this.btnMoveByPos.Name = "btnMoveByPos";
            this.btnMoveByPos.Size = new System.Drawing.Size(72, 32);
            this.btnMoveByPos.TabIndex = 5;
            this.btnMoveByPos.Text = "Move By (+)";
            this.btnMoveByPos.UseVisualStyleBackColor = true;
            this.btnMoveByPos.Click += new System.EventHandler(this.btnMoveByPos_Click);
            // 
            // btnMoveByNeg
            // 
            this.btnMoveByNeg.Location = new System.Drawing.Point(236, 102);
            this.btnMoveByNeg.Name = "btnMoveByNeg";
            this.btnMoveByNeg.Size = new System.Drawing.Size(72, 32);
            this.btnMoveByNeg.TabIndex = 2;
            this.btnMoveByNeg.Text = "Move By (-)";
            this.btnMoveByNeg.UseVisualStyleBackColor = true;
            this.btnMoveByNeg.Click += new System.EventHandler(this.btnMoveByNeg_Click);
            // 
            // btnStageStop
            // 
            this.btnStageStop.Location = new System.Drawing.Point(98, 66);
            this.btnStageStop.Name = "btnStageStop";
            this.btnStageStop.Size = new System.Drawing.Size(84, 32);
            this.btnStageStop.TabIndex = 4;
            this.btnStageStop.Text = "Stop";
            this.btnStageStop.UseVisualStyleBackColor = true;
            this.btnStageStop.Click += new System.EventHandler(this.btnStageStop_Click);
            // 
            // tmrMain
            // 
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 591);
            this.Controls.Add(this.pnControl);
            this.Controls.Add(this.gbConnection);
            this.Controls.Add(this.rtbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Spectrometer Acquisition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.pnControl.ResumeLayout(false);
            this.gbSpectrometer.ResumeLayout(false);
            this.gbSpectrometer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegrationUs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenterWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaveInc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWaveRange)).EndInit();
            this.gbStage.ResumeLayout(false);
            this.gbStage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStageRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStageMoveBy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.Button btnStageDisconnect;
        private System.Windows.Forms.Button btnStageConnect;
        private System.Windows.Forms.Button btnStageRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSpectrometer;
        private System.Windows.Forms.ComboBox cbStage;
        private System.Windows.Forms.Panel pnControl;
        private System.Windows.Forms.GroupBox gbSpectrometer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudWaveInc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudWaveRange;
        private System.Windows.Forms.Button btnSpectrumFull;
        private System.Windows.Forms.Button btnSpectrumRange;
        private System.Windows.Forms.GroupBox gbStage;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnMoveByPos;
        private System.Windows.Forms.Button btnMoveByNeg;
        private System.Windows.Forms.Button btnStageStop;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudStageMoveBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.TextBox txtHomed;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudCenterWave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudStageRange;
        private System.Windows.Forms.Button btnContFwd;
        private System.Windows.Forms.Button btnContBack;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudIntegrationUs;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Button btnSpecDisconnect;
        private System.Windows.Forms.Button btnSpecConnect;
        private System.Windows.Forms.Button btnSpecRefresh;
    }
}

