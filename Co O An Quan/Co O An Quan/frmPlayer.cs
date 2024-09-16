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
    public partial class frmPlayer : Form
    {

        public static String player1 = "";
        public static String anhPlayer1 = "";
        public frmPlayer()
        {
          
            
            InitializeComponent();
        }

        private void btTroVeStart_Click(object sender, EventArgs e)
        {
            Hide();
            frmStart s = new frmStart();
            s.ShowDialog();
            Close();
        }

        private void btDenPlayer2_Click(object sender, EventArgs e)
        {
            txtPlayer1.Focus();
            player1 = txtPlayer1.Text ;
            Hide();
            frmPlayer2 p2 = new frmPlayer2();
            p2.ShowDialog();
            Close();
        }

        

        private void tbAnh1_Click(object sender, EventArgs e)
        {
            picPlayer1.Image = Co_O_An_Quan.Properties.Resources.player1_1;
            anhPlayer1 = "Co_O_An_Quan.Properties.Resources.player1_1";
        }

        private void btAnh2_Click(object sender, EventArgs e)
        {
            picPlayer1.Image = Co_O_An_Quan.Properties.Resources.player2_1;
            anhPlayer1 = "Co_O_An_Quan.Properties.Resources.player2_1";
        }

        private void btAnh3_Click(object sender, EventArgs e)
        {
            picPlayer1.Image = Co_O_An_Quan.Properties.Resources.player31;
            anhPlayer1 = "Co_O_An_Quan.Properties.Resources.player31";
        }

        private void btAnh5_Click(object sender, EventArgs e)
        {
            picPlayer1.Image = Co_O_An_Quan.Properties.Resources.Player5_1;
            anhPlayer1 = "Co_O_An_Quan.Properties.Resources.Player5_1";
        }

        private void btAnh4_Click(object sender, EventArgs e)
        {
            picPlayer1.Image = Co_O_An_Quan.Properties.Resources.Player4_1;
            anhPlayer1 = "Co_O_An_Quan.Properties.Resources.Player4_1";
        }

        private void btAnh6_Click(object sender, EventArgs e)
        {
            picPlayer1.Image = Co_O_An_Quan.Properties.Resources.Player6_1;
            anhPlayer1 = "Co_O_An_Quan.Properties.Resources.Player6_1";
        }
        private void frmPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
