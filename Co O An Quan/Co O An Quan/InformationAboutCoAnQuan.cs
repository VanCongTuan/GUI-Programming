using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Co_O_An_Quan
{
    public partial class InformationAboutCoAnQuan : Form
    {
        public InformationAboutCoAnQuan()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
          
            Close();
        }

        private void InformationAboutCoAnQuan_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            ;
            Close();
        }
    }
}
