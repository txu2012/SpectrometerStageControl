
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.Title = "Wavelength";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            chartArea1.AxisY.Title = "Intensity";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(6, 36);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1288, 654);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chIntensities";
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
            // FormChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 697);
            this.Controls.Add(this.cbStart);
            this.Controls.Add(this.chart1);
            this.Name = "FormChart";
            this.Text = "FormChart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChart_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.CheckBox cbStart;
    }
}