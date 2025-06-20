
namespace SpectrometerStageControl
{
    partial class FormChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.cbStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblXPos = new System.Windows.Forms.Label();
            this.lblYPos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbNormalize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Wavelength";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            chartArea1.AxisY.Title = "Intensity";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorY.Interval = 0.1D;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 36);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1288, 654);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chIntensities";
            this.chart1.CursorPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_CursorPositionChanging);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // cbStart
            // 
            this.cbStart.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbStart.Location = new System.Drawing.Point(4, 6);
            this.cbStart.Name = "cbStart";
            this.cbStart.Size = new System.Drawing.Size(80, 23);
            this.cbStart.TabIndex = 1;
            this.cbStart.Text = "Start";
            this.cbStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbStart.UseVisualStyleBackColor = true;
            this.cbStart.CheckedChanged += new System.EventHandler(this.cbStart_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(144, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X Pos :";
            // 
            // lblXPos
            // 
            this.lblXPos.AutoSize = true;
            this.lblXPos.BackColor = System.Drawing.Color.White;
            this.lblXPos.Location = new System.Drawing.Point(184, 38);
            this.lblXPos.Name = "lblXPos";
            this.lblXPos.Size = new System.Drawing.Size(13, 13);
            this.lblXPos.TabIndex = 3;
            this.lblXPos.Text = "0";
            // 
            // lblYPos
            // 
            this.lblYPos.AutoSize = true;
            this.lblYPos.BackColor = System.Drawing.Color.White;
            this.lblYPos.Location = new System.Drawing.Point(254, 38);
            this.lblYPos.Name = "lblYPos";
            this.lblYPos.Size = new System.Drawing.Size(13, 13);
            this.lblYPos.TabIndex = 5;
            this.lblYPos.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(214, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y Pos :";
            // 
            // cbNormalize
            // 
            this.cbNormalize.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbNormalize.Location = new System.Drawing.Point(88, 6);
            this.cbNormalize.Name = "cbNormalize";
            this.cbNormalize.Size = new System.Drawing.Size(80, 23);
            this.cbNormalize.TabIndex = 6;
            this.cbNormalize.Text = "Normalize";
            this.cbNormalize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbNormalize.UseVisualStyleBackColor = true;
            this.cbNormalize.CheckedChanged += new System.EventHandler(this.cbNormalize_CheckedChanged);
            // 
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 697);
            this.Controls.Add(this.cbNormalize);
            this.Controls.Add(this.lblYPos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblXPos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbStart);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormChart";
            this.Text = "Spectrum";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChart_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.CheckBox cbStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblXPos;
        private System.Windows.Forms.Label lblYPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbNormalize;
    }
}