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
    public partial class frmStart : Form
    {
      
        
       
        public frmStart()
        {
            InitializeComponent();
        }

        private void btThongTin_Click(object sender, EventArgs e)
        {
            
            InformationAboutCoAnQuan f = new InformationAboutCoAnQuan();
            f.ShowDialog();
           

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            Hide();
            frmPlayer p = new frmPlayer();
            p.ShowDialog();
             Close();
        }
        private void frmStart_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
