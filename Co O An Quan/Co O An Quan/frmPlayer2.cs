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
    public partial class frmPlayer2 : Form
    {

        public static String player2 = "";
        public static String anhPlayer2 = "";
        public frmPlayer2()
        {
            InitializeComponent();
        }

        private void btDenTroChoi_Click(object sender, EventArgs e)
        {
            txtPlayer2.Focus();
            player2 =txtPlayer2.Text ;
            Hide();
            FrmCoAnQuan c = new FrmCoAnQuan();
            c.ShowDialog();
            Close();
        }
       

        private void btTroVePlayer_Click(object sender, EventArgs e)
        {
            Hide();
            frmPlayer p = new frmPlayer();
            p.ShowDialog();
            Close();
        }
private void tbAnh7_Click(object sender, EventArgs e)
        {
            picPlayer2.Image = Co_O_An_Quan.Properties.Resources.player1_1;
            anhPlayer2 = "Co_O_An_Quan.Properties.Resources.player1_1";
        }
        private void btAnh8_Click(object sender, EventArgs e)
        {
            picPlayer2.Image = Co_O_An_Quan.Properties.Resources.player2_1;
            anhPlayer2 = "Co_O_An_Quan.Properties.Resources.player2_1";
        }

        private void btAnh9_Click(object sender, EventArgs e)
        {
            picPlayer2.Image = Co_O_An_Quan.Properties.Resources.player31;
            anhPlayer2 = "Co_O_An_Quan.Properties.Resources.player31";
        }

        private void btAnh10_Click(object sender, EventArgs e)
        {
            picPlayer2.Image = Co_O_An_Quan.Properties.Resources.Player5_1;
            anhPlayer2 = "Co_O_An_Quan.Properties.Resources.Player5_1";
        }

        private void btAnh11_Click(object sender, EventArgs e)
        {
            picPlayer2.Image = Co_O_An_Quan.Properties.Resources.Player4_1;
            anhPlayer2 = "Co_O_An_Quan.Properties.Resources.Player4_1";
        }

        private void btAnh12_Click(object sender, EventArgs e)
        {
            picPlayer2.Image = Co_O_An_Quan.Properties.Resources.Player6_1;
            anhPlayer2 = "Co_O_An_Quan.Properties.Resources.Player6_1";
        }

        private void frmPlayer2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

    }
}
