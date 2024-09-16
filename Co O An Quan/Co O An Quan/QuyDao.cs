using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_O_An_Quan
{
    class QuyDao
    {
        public enumBen Ben;
        public enumHuong Huong;
        public ToaDo[] DuongDi;
        private static ToaDo[] ConDuong = new ToaDo[]
        {
            new ToaDo(0, 0, 0),
            new ToaDo(1,0,0), new ToaDo(1,0,1), new ToaDo(1,0,2), new ToaDo(1,0,3),new ToaDo(1,0,4),
            new ToaDo(0,1,0),
            new ToaDo(1,1,4), new ToaDo(1,1,3), new ToaDo(1,1,2), new ToaDo(1,1,1) ,new ToaDo(1,1,0) ,
        };

        public QuyDao()
        {
            Ben = enumBen.Cam;
            Huong = enumHuong.CungChieuimDongHo;
            DuongDi = ConDuong;
        }

        public QuyDao(int vt, enumHuong huong)
        {
            DuongDi = new ToaDo[KichCo.ChuVi];
            if (huong == enumHuong.CungChieuimDongHo)
                for (int i = 0; i < KichCo.ChuVi; i++)
                    DuongDi[i] = ConDuong[(i + vt) % KichCo.ChuVi];
            else
                for (int i = 0; i < KichCo.ChuVi; i++)
                    DuongDi[i] = ConDuong[(KichCo.ChuVi * 2 - i + vt) % KichCo.ChuVi];
        }

        public ToaDo this[int i]
        {
            set { DuongDi[i % DuongDi.Length] = value; }
            get { return DuongDi[i % DuongDi.Length]; }
        }
    }
}
