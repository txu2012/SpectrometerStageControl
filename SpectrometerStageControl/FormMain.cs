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
        public FormMain()
        {
            InitializeComponent();
        }

        public void UpdateScreen() { }
    }
}
