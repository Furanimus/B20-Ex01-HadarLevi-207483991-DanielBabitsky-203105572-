using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace B20_Ex01_Hadar_207483991_Daniel_203105572
{
    public partial class FormTextFill : Form
    {
        public string UserInput { get; set; }

        public bool IsCanceled { get; set; }

        public FormTextFill()
        {
            IsCanceled = true;
            InitializeComponent();
        }

        private void m_SubmitBtn_Click_1(object sender, EventArgs e)
        {
            UserInput = m_TextField.Text;
            IsCanceled = false;
            this.Dispose();
        }

        private void m_CancelBtn_Click_1(object sender, EventArgs e)
        {
            IsCanceled = true;
            this.Dispose();
        }
    }
}
