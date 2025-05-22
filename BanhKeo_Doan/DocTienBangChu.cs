using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanhKeo_Doan
{
    public class DocTienBangChu
    {
        private readonly string[] ChuSo = { " không ", " một ", " hai ", " ba ", " bốn ", " năm ", " sáu ", " bảy ", " tám ", " chín " };
        private readonly string[] Tien = { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };

        private string DocSo3ChuSo(int baso)
        {
            int tram = baso / 100;
            int chuc = (baso % 100) / 10;
            int donvi = baso % 10;
            string KetQua = "";

            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if (chuc == 0 && donvi != 0) KetQua += " linh";
            }

            if (chuc != 0 && chuc != 1)
            {
                KetQua += ChuSo[chuc] + " mươi";
            }
            else if (chuc == 1)
            {
                KetQua += " mười";
            }

            switch (donvi)
            {
                case 1:
                    KetQua += (chuc != 0 && chuc != 1) ? " mốt" : ChuSo[donvi];
                    break;
                case 5:
                    KetQua += (chuc == 0) ? ChuSo[donvi] : " lăm";
                    break;
                default:
                    if (donvi != 0) KetQua += ChuSo[donvi];
                    break;
            }

            return KetQua.Trim();
        }

        public string Doc(decimal SoTien)
        {
            if (SoTien == 0) return "Không đồng";

            bool soAm = SoTien < 0;
            SoTien = Math.Abs(SoTien);
            if (SoTien > 8999999999999999) return ""; // Số quá lớn

            long so = (long)SoTien;
            long[] ViTri = new long[6];
            ViTri[5] = so / 1000000000000000;
            so %= 1000000000000000;
            ViTri[4] = so / 1000000000000;
            so %= 1000000000000;
            ViTri[3] = so / 1000000000;
            so %= 1000000000;
            ViTri[2] = so / 1000000;
            so %= 1000000;
            ViTri[1] = so / 1000;
            ViTri[0] = so % 1000;

            int lan = Array.FindLastIndex(ViTri, x => x > 0);
            string KetQua = "";

            for (int i = lan; i >= 0; i--)
            {
                string tmp = DocSo3ChuSo((int)ViTri[i]);
                if (!string.IsNullOrEmpty(tmp))
                {
                    KetQua += tmp + Tien[i] + " ";
                }
            }

            KetQua = KetQua.Trim();
            KetQua = char.ToUpper(KetQua[0]) + KetQua.Substring(1);
            KetQua += " đồng";

            return soAm ? "Âm " + KetQua : KetQua;
        }
    }

}
