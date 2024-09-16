using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Co_O_An_Quan
{
    public class ToaDo
    {
        private int tuonglinh, trenduoi, cot;

        public ToaDo()
        {
            tuonglinh = 0;
            trenduoi = 0;
            cot = 0;
        }

        public ToaDo(int tl, int td, int ct)
        {
            tuonglinh = tl;
            trenduoi = td;
            cot = ct;
        }

        public int TuongLinh
        {
            set { tuonglinh = value; }
            get { return tuonglinh; }
        }

        public int TrenDuoi
        {
            set { trenduoi = value; }
            get { return trenduoi; }
        }

        public int Cot
        {
            set { cot = value; }
            get { return cot; }
        }
    }
}
