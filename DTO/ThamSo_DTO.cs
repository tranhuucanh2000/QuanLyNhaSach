using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DTO
{
    public class ThamSo_DTO
    {

        /// <summary>
        ///     ''' Số lượng nhập tối thiểu mỗi khi nhập sách về
        ///     ''' </summary>
        private int SoLuongNhapToiThieu;

        /// <summary>
        ///     ''' Số lượng tồn tối đa cho phép nhập sách
        ///     ''' </summary>
        private int SoLuongTonToiDa;


        private int SoLuongTonToiThieu;
        private double SoTienNoToiDa;
        private bool SuDungQD4;

        public int SoLuongNhapToiThieu1
        {
            get
            {
                return SoLuongNhapToiThieu;
            }
            set
            {
                SoLuongNhapToiThieu = value;
            }
        }

        public int SoLuongTonToiDa1
        {
            get
            {
                return SoLuongTonToiDa;
            }
            set
            {
                SoLuongTonToiDa = value;
            }
        }

        public int SoLuongTonToiThieu1
        {
            get
            {
                return SoLuongTonToiThieu;
            }
            set
            {
                SoLuongTonToiThieu = value;
            }
        }

        public double SoTienNoToiDa1
        {
            get
            {
                return SoTienNoToiDa;
            }
            set
            {
                SoTienNoToiDa = value;
            }
        }

        public bool SuDungQD41
        {
            get
            {
                return SuDungQD4;
            }
            set
            {
                SuDungQD4 = value;
            }
        }
    }

}
