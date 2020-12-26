using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Result
    {
        private bool flag;
        private string appMessage;
        private string sysMessage;
        private object obj;

        public bool FlagResult
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }

        public string ApplicationMessage
        {
            get
            {
                return appMessage;
            }
            set
            {
                appMessage = value;
            }
        }

        public string SystemMessage
        {
            get
            {
                return sysMessage;
            }
            set
            {
                sysMessage = value;
            }
        }

        public object Obj1
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        public Result()
        {
            this.flag = true;
            this.appMessage = string.Empty;
            this.sysMessage = string.Empty;
            this.obj = null;
        }


        public Result(bool flag)
        {
            this.flag = flag;
            this.obj = null;
            this.appMessage = string.Empty;
            this.sysMessage = string.Empty;
        }

        /// <summary>
        ///     ''' 
        ///     ''' </summary>
        ///     ''' <param name="flag"></param>
        ///     ''' <param name="x">Đối tượng object cần trả về</param>

        public Result(bool flag, object x)
        {
            this.flag = flag;
            this.obj = x;
            this.appMessage = string.Empty;
            this.sysMessage = string.Empty;
        }

        public void StackTrace()
        {
            System.Console.WriteLine(flag);
            System.Console.WriteLine(appMessage);
            System.Console.WriteLine(sysMessage);
        }

        /// <summary>
        ///     ''' 
        ///     ''' </summary>
        ///     ''' <param name="flag"></param>
        ///     ''' <param name="x">Đối tượng object cần trả về</param>
        ///     ''' <param name="appMes">Thông báo của phần mềm</param>
        public Result(bool flag, object x, string appMes)
        {
            this.flag = flag;
            this.obj = x;
            this.appMessage = appMes;
            this.sysMessage = string.Empty;
        }

        /// <summary>
        ///     ''' 
        ///     ''' </summary>
        ///     ''' <param name="flag"></param>
        ///     ''' <param name="x">Đối tượng object cần trả về</param>
        ///     ''' <param name="appMes">Thông báo của phần mềm</param>
        ///     ''' <param name="sysMes">Thông báo Hệ thống</param>
        public Result(bool flag, object x, string appMes, string sysMes)
        {
            this.flag = flag;
            this.obj = x;
            this.appMessage = appMes;
            this.sysMessage = sysMes;
        }
    }

}
