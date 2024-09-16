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

    public enum enumBen
    {
        Cam = 0,
        Vang = 1
    }

    public enum enumHuong
    {
        CungChieuimDongHo = 0,
        NguocChieuKimDongHo = 1
    }

    public struct KichCo
    {
        public const int Sodem = 2;
        public const int SoTuong = 2;
        public const int SoO = 5;
        public const int SoLinhTrenO = 5;
        public const int GiaTuong = 10;
        public const int GiaLinh = 1;
        public const int NLinh = 5;
        public const int ChuVi = 12;
    }


    public partial class FrmCoAnQuan : Form
    {
        private static int CellLeft = 300;
        private static int CellTop = 180;
        private static int CellWidth = 100;
        private static int CellHeight = 120;
        private static int DoubleHeight = CellHeight * 2;
        private enumBen BenDi = enumBen.Cam;
        private bool DaChonLinh = false;
        private int ViTriXuatPhat = 0;
        private int ViTriKeTiep = 0;
        private int SoLinhDangDi = 0;
        private enumHuong HuongDangDi = enumHuong.CungChieuimDongHo;
        private int[] SoTuongDuoc = new int[2] { 0, 0 };
        private int[] SoLinhDuoc = new int[2] { 0, 0 };
        private int SoLinhMoiO = KichCo.SoLinhTrenO;
        public FrmCoAnQuan()
        {
          
            InitializeComponent();
        }

       
        private string TenBen(enumBen ben)
        {
            if (ben == enumBen.Cam)
                return "Cam";
            else
                return "Vàng";
        }
        private void TaoKhungTuong(enumBen ben)
        {
            Button btn = new Button();
            btn.Location = new Point(CellLeft + (int)ben * CellWidth * (KichCo.SoO + 1), CellTop);
            btn.Size = new Size(CellWidth, DoubleHeight);
            btn.ImageList = AnhTuong;
            btn.ImageKey = "BanNguyet" + ((ben == enumBen.Cam) ? "Trai" : "Phai") + ".PNG";
            btn.Name = "BanNguyet" + ((int)ben).ToString("0");
            btn.Click += new EventHandler(btnTuong_Click);
            Controls.Add(btn);

        }
        private void TaoKhungLinh(enumBen ben, int col)
        {
            Button btn = new Button();
            btn.Location = new Point(CellLeft + CellWidth * (col + 1), CellTop + (int)ben * CellHeight);
            btn.Size = new Size(CellWidth, CellHeight);
            btn.ImageList = AnhCo;
            btn.ImageKey = "KhungLinh" + ((int)ben).ToString("0") + "00.PNG";
            btn.Name = "btn" + ((int)ben).ToString() + col.ToString("0");
            btn.Click += new EventHandler(btnLinh_Click);
            Controls.Add(btn);

        }
        private void VeSoOTuong(enumBen ben, int Sotuong, int Solinh)
        {
            Button btn = (Button)Controls["BanNguyet" + ((int)ben).ToString()];
            btn.ImageKey = "BanNguyet" + ((ben == enumBen.Cam) ? "Trai" : "Phai") + Sotuong.ToString("0") + Solinh.ToString("00") + ".PNG";
        }

        private void VeSoOLinh(enumBen ben, int col, int Solinh)
        {
            Button btn = (Button)Controls["btn" + ((int)ben).ToString() + col.ToString("0")];
            btn.ImageKey = "KhungLinh" + ((int)ben).ToString("0") + Solinh.ToString("00") + ".PNG";
        }

       

        private void btnTuong_Click(object sender, EventArgs e) //button Tuong
        {
            if (DaChonLinh)
            { // Chọn ô đích đến là tướng
                Button btn = (Button)sender;
                enumBen ben = (enumBen)int.Parse(btn.Name.Substring(9, 1));
                int SoTuong = int.Parse(btn.ImageKey.Substring(13, 1));
                int SoLinh = int.Parse(btn.ImageKey.Substring(14, 2));
                if (SoLinhDangDi > 0)
                {
                    ViTriKeTiep = (ben == enumBen.Cam) ? 0 : 6;
                    if (ViTriKeTiep == (ViTriXuatPhat + 1) % KichCo.ChuVi || ViTriKeTiep == ViTriXuatPhat - 1)
                        VongLap(); // sẽ gọi đệ quy
                    hienThiDiem();
                }
                else
                    DoiBen();
                hienThiDiem();
            }
        }

        
        private void TaoKhungBanCo()
        {
           
            foreach (enumBen ben in new enumBen[] { enumBen.Cam, enumBen.Vang })
            {
                TaoKhungTuong(ben);
                VeSoOTuong(ben, 1, 0);
                for (int col = 0; col <= KichCo.SoO - 1; col++)
                {
                    TaoKhungLinh(ben, col);
                    VeSoOLinh(ben, col, SoLinhMoiO);
                }
            }
           lbThongBao.Text = "Bắt đầu";
        }

        private void DoiBen()
        {
            BenDi = ((BenDi == enumBen.Cam) ? enumBen.Vang : enumBen.Cam);
            
            DaChonLinh = false;;
            enumBen ben = new enumBen();
            if (KiemCon2Bien() == false) ThuHoiTanQuan(ben); KiemConLinh();
        }

        private void TangLenMot(ToaDo td)
        {
            if (td.TuongLinh == 0)
            {
                Button btn = (Button)Controls["BanNguyet" + td.TrenDuoi.ToString("0")];
                int SoTuong = int.Parse(btn.ImageKey.Substring(13, 1));
                int SoLinh = int.Parse(btn.ImageKey.Substring(14, 2));
                btn.ImageKey = "BanNguyet" + ((td.TrenDuoi == 0) ? "Trai" : "Phai") + SoTuong.ToString("0") + (SoLinh + 1).ToString("00") + ".PNG";
            }
            else
            {
                Button btn = (Button)Controls["btn" + td.TrenDuoi.ToString("0") + td.Cot.ToString("0")];
                int SoLinh = int.Parse(btn.ImageKey.Substring(10, 2));
                btn.ImageKey = "KhungLinh" + td.TrenDuoi.ToString("0") + (SoLinh + 1).ToString("00") + ".PNG";
            }
        }

        private int SoTuongCoMat(ToaDo td)
        {
            if (td.TuongLinh == 0)
            {
                Button btn = (Button)Controls["BanNguyet" + td.TrenDuoi.ToString("0")];
                return int.Parse(btn.ImageKey.Substring(13, 1));
            }
            else
                return 0;
        }

        private int SoLinhCoMat(ToaDo td)
        {
            if (td.TuongLinh == 0)
            {
                Button btn = (Button)Controls["BanNguyet" + td.TrenDuoi.ToString("0")];
                return int.Parse(btn.ImageKey.Substring(14, 2));
            }
            else
            {
                Button btn = (Button)Controls["btn" + td.TrenDuoi.ToString("0") + td.Cot.ToString("0")];
                return int.Parse(btn.ImageKey.Substring(10, 2));
            }
        }

        private void VongLap()
        {
            HuongDangDi = (ViTriKeTiep == (ViTriXuatPhat + 1) % KichCo.ChuVi) ? enumHuong.CungChieuimDongHo : enumHuong.NguocChieuKimDongHo;
            QuyDao qd = new QuyDao(ViTriXuatPhat, HuongDangDi);
            for (int i = 1; i <= SoLinhDangDi; i++)
            {
                TangLenMot(qd[i]);
            }
            ToaDo OTiepSuc = qd[SoLinhDangDi + 1];
            if (OTiepSuc.TuongLinh != 0)
            {
                int solinhtiep = SoLinhCoMat(OTiepSuc);
                if (solinhtiep > 0)
                {
                    if (HuongDangDi == enumHuong.CungChieuimDongHo)
                    {
                        ViTriXuatPhat = (ViTriXuatPhat + SoLinhDangDi + 1) % KichCo.ChuVi;
                        ViTriKeTiep = (ViTriKeTiep + SoLinhDangDi + 1) % KichCo.ChuVi;
                    }
                    else
                    {
                        ViTriXuatPhat = (ViTriXuatPhat + KichCo.ChuVi - SoLinhDangDi - 1) % KichCo.ChuVi;
                        ViTriKeTiep = (ViTriKeTiep + KichCo.ChuVi - SoLinhDangDi - 1) % KichCo.ChuVi;
                    }
                    enumBen ben = (enumBen)qd[SoLinhDangDi + 1].TrenDuoi;
                    int col = qd[SoLinhDangDi + 1].Cot;
                    SoLinhDangDi = solinhtiep;
                    VeSoOLinh(ben, col, 0);
                    VongLap();
                }

                else
                {
                    if (SoTuongCoMat(qd[SoLinhDangDi + 2]) > 0 || SoLinhCoMat(qd[SoLinhDangDi + 2]) > 0)
                    {
                        bool TiepTucThu = false;
                        do
                        {
                            
                            SoTuongDuoc[(int)BenDi] += SoTuongCoMat(qd[SoLinhDangDi + 2]);
                            SoLinhDuoc[(int)BenDi] += SoLinhCoMat(qd[SoLinhDangDi + 2]);
                           
                            enumBen ben = (enumBen)qd[SoLinhDangDi + 2].TrenDuoi;
                            int col = qd[SoLinhDangDi + 2].Cot;
                            if (qd[SoLinhDangDi + 2].TuongLinh == 0) VeSoOTuong(ben, 0, 0); VeSoOLinh(ben, col, 0);
                            if (qd[SoLinhDangDi + 3].TuongLinh != 0 && SoLinhCoMat(qd[SoLinhDangDi + 3]) == 0 && (SoTuongCoMat(qd[SoLinhDangDi + 4]) > 0 || SoLinhCoMat(qd[SoLinhDangDi + 4]) > 0))
                            {
                                if (HuongDangDi == enumHuong.CungChieuimDongHo)
                                {
                                    ViTriXuatPhat = (ViTriXuatPhat + SoLinhDangDi + 2) % KichCo.ChuVi;
                                    ViTriKeTiep = (ViTriKeTiep + SoLinhDangDi + 2) % KichCo.ChuVi;
                                }
                                else
                                {
                                    ViTriXuatPhat = (ViTriXuatPhat + KichCo.ChuVi - SoLinhDangDi - 2) %
                                    KichCo.ChuVi;
                                    ViTriKeTiep = (ViTriKeTiep + KichCo.ChuVi - SoLinhDangDi - 2) %
                                    KichCo.ChuVi;
                                }
                                HuongDangDi = (ViTriKeTiep == (ViTriXuatPhat + 1) % KichCo.ChuVi)
                                ? enumHuong.CungChieuimDongHo : enumHuong.NguocChieuKimDongHo;
                                qd = new QuyDao(ViTriXuatPhat, HuongDangDi);
                                SoLinhDangDi = 0; // Tận thu chiến lợi phẩm
                            }
                            else TiepTucThu = false;
                        }
                        while (TiepTucThu);
                    }
                    DoiBen();
                }
            }
            else
            {
                SoLinhDangDi = 0;
                DoiBen();
            }
        }


        private bool KiemCon2Bien()
        {
            int TriGia = 0;
            for (int ben = 0; ben < 2; ben++)
            {
                Button btn = (Button)Controls["BanNguyet" + ben.ToString("0")];
                int SoTuong = int.Parse(btn.ImageKey.Substring(13, 1));
                int SoLinh = int.Parse(btn.ImageKey.Substring(14, 2));
                TriGia += SoTuong * GiaTuong() + SoLinh * KichCo.GiaLinh;
            }
            return (TriGia > 0);
        }
        string soMuLinh = "5";
        private int GiaTuong()
        {
            return int.Parse(soMuLinh) * 2 * KichCo.GiaLinh;
        }
        private void mnuSoLinhO_TextChanged(object sender, EventArgs e)
        {
            int SoLinh = 0;
            if (int.TryParse(soMuLinh, out SoLinh))
            {
                SoLinhMoiO = SoLinh;
                enumBen ben = new enumBen();
                DoiBanMoi(ben);
            }
        }

        private void KiemConLinh()
        {
            foreach (enumBen ben in new enumBen[] { enumBen.Cam, enumBen.Vang })
            {
                int SoLinhBen = 0;
                for (int col = 0; col < KichCo.SoO; col++)
                    SoLinhBen += SoLinhCoMat(new ToaDo(1, (int)ben, col));
                if (SoLinhBen == 0)
                    RaMoiO1Linh(ben);
            }
        }

        private void RaMoiO1Linh(enumBen ben)
        {
            for (int col = 0; col < KichCo.SoO; col++)
                VeSoOLinh(ben, col, 1);
            SoLinhDuoc[(int)ben] -= KichCo.SoO;
           lbThongBao.Text = "Bên " + ben.ToString() + " phải ra " + KichCo.SoO + " lính";
        }

        private int SoDiem(enumBen ben)
        {
            return SoTuongDuoc[(int)ben] * GiaTuong() + SoLinhDuoc[(int)ben] * KichCo.GiaLinh;
        }

        private void KetQuaThangThua()
        {
            string ThongBao = "Bên nguoi choi 1 có " + SoDiem(enumBen.Cam).ToString() + " điểm\n" + "Bên Bên nguoi choi 2 có " + SoDiem(enumBen.Vang).ToString() + " điểm\n";
            if (SoDiem(enumBen.Cam) != SoDiem(enumBen.Vang))
                ThongBao +=
                ((SoDiem(enumBen.Cam) > SoDiem(enumBen.Vang)) ? "Bên nguoi choi 1 " : "Bên nguoi choi 2 ")
                + " thắng " + Math.Abs(SoDiem(enumBen.Cam) - SoDiem(enumBen.Vang)) + " điểm";
            else
                ThongBao += "Hai bên hòa nhau";
            MessageBox.Show(ThongBao, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            enumBen ben = new enumBen();
            DoiBanMoi(ben);
        }

        private void ThuHoiTanQuan(enumBen Ben)
        {
            int[] SoLinhBen = new int[2] { 0, 0 };
            foreach (enumBen ben in new enumBen[] { enumBen.Cam, enumBen.Vang })
            {
                for (int col = 0; col < KichCo.SoO; col++)
                {
                    SoLinhBen[(int)ben] += SoLinhCoMat(new ToaDo(1, (int)ben, col));
                    VeSoOLinh(ben, col, 0);
                }
                SoLinhDuoc[(int)ben] += SoLinhBen[(int)ben];
               
            }
        
            KetQuaThangThua();
        }

        private void DoiBanMoi(enumBen Ben)
        {
            foreach (enumBen ben in new enumBen[] { enumBen.Cam, enumBen.Vang })
            {
                for (int col = 0; col < KichCo.SoO; col++)
                    VeSoOLinh(ben, col, SoLinhMoiO);
                VeSoOTuong(ben, 1, 0);
                SoTuongDuoc[(int)ben] = 0;
                SoLinhDuoc[(int)ben] = 0;
               
            }
            
        }

        private void hienThiDiem()
        {
            lbKqDo.Text = String.Format("{0}", SoDiem(enumBen.Cam));
            lbKqXanh.Text = String.Format("{0}", SoDiem(enumBen.Vang));
            if (BenDi == enumBen.Cam)
                lbThongBao.Text = "Toi Luoc Nguoi Choi 1 ";
            else
                lbThongBao.Text = "Toi Luoc Nguoi Choi 2 ";
        }
        private void btnLinh_Click(object sender, EventArgs e) //button Linh
        {
            Button btn = (Button)sender;
            enumBen ben = (enumBen)int.Parse(btn.Name.Substring(3, 1));
            if (ben == BenDi) { 
                if (!DaChonLinh)
                { // Chọn ô xuất phát
                    DaChonLinh = true;
                    int col = int.Parse(btn.Name.Substring(4, 1));
                    int SoLinh = int.Parse(btn.ImageKey.Substring(10, 2));
                    ViTriXuatPhat = ben == enumBen.Cam ? (1 + col) : (KichCo.ChuVi - 1 - col);
                    SoLinhDangDi = SoLinh;
                    VeSoOLinh(ben, col, 0);
                    hienThiDiem();

                }
                else
                {
                    int col = int.Parse(btn.Name.Substring(4, 1));
                    int SoLinh = int.Parse(btn.ImageKey.Substring(10, 2));
                    if (SoLinhDangDi > 0)
                    {
                        lbKqDo.Text = String.Format("{0}", SoDiem(enumBen.Cam));
                        lbKqXanh.Text = String.Format("{0}", SoDiem(enumBen.Vang));
                        ViTriKeTiep = ben == enumBen.Cam ? (1 + col) : (KichCo.ChuVi - 1 - col);
                        if (ViTriKeTiep == (ViTriXuatPhat + 1) % KichCo.ChuVi
                        || ViTriKeTiep == (ViTriXuatPhat - 1) % KichCo.ChuVi)
                            VongLap(); // sẽ gọi đề quy
                        hienThiDiem();
                    }
                    else
                    {
                        DoiBen();
                        hienThiDiem();
                    }
                }
                hienThiDiem();
            }
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            lbTen2.Text =  frmPlayer2.player2;
            lbTen1.Text =  frmPlayer.player1;

            if (frmPlayer.anhPlayer1 == "Co_O_An_Quan.Properties.Resources.player1_1") picAnhNguoiChoi1.Image = Co_O_An_Quan.Properties.Resources.player1_1;
            if (frmPlayer.anhPlayer1 == "Co_O_An_Quan.Properties.Resources.player2_1") picAnhNguoiChoi1.Image = Co_O_An_Quan.Properties.Resources.player2_1;
            if (frmPlayer.anhPlayer1 == "Co_O_An_Quan.Properties.Resources.player31") picAnhNguoiChoi1.Image = Co_O_An_Quan.Properties.Resources.player31;
            if (frmPlayer.anhPlayer1 == "Co_O_An_Quan.Properties.Resources.Player4_1") picAnhNguoiChoi1.Image = Co_O_An_Quan.Properties.Resources.Player4_1;
            if (frmPlayer.anhPlayer1 == "Co_O_An_Quan.Properties.Resources.Player5_1") picAnhNguoiChoi1.Image = Co_O_An_Quan.Properties.Resources.Player5_1;
            if (frmPlayer.anhPlayer1 == "Co_O_An_Quan.Properties.Resources.Player6_1") picAnhNguoiChoi1.Image = Co_O_An_Quan.Properties.Resources.Player6_1;


            if (frmPlayer2.anhPlayer2 == "Co_O_An_Quan.Properties.Resources.player1_1") picnguoichoi2.Image = Co_O_An_Quan.Properties.Resources.player1_1;
            if (frmPlayer2.anhPlayer2 == "Co_O_An_Quan.Properties.Resources.player2_1") picnguoichoi2.Image = Co_O_An_Quan.Properties.Resources.player2_1;
            if (frmPlayer2.anhPlayer2 == "Co_O_An_Quan.Properties.Resources.player31") picnguoichoi2.Image = Co_O_An_Quan.Properties.Resources.player31;
            if (frmPlayer2.anhPlayer2 == "Co_O_An_Quan.Properties.Resources.Player4_1") picnguoichoi2.Image = Co_O_An_Quan.Properties.Resources.Player4_1;
            if (frmPlayer2.anhPlayer2 == "Co_O_An_Quan.Properties.Resources.Player5_1") picnguoichoi2.Image = Co_O_An_Quan.Properties.Resources.Player5_1;
            if (frmPlayer2.anhPlayer2 == "Co_O_An_Quan.Properties.Resources.Player6_1") picnguoichoi2.Image = Co_O_An_Quan.Properties.Resources.Player6_1;
            TaoKhungBanCo();
        }

        private void bthome_Click(object sender, EventArgs e)
        {
            Hide();
            frmStart s = new frmStart();
            s.ShowDialog();
            Close();
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            TaoKhungBanCo();
        }
    }
}
