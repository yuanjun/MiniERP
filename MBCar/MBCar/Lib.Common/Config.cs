using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Lib.Common
{
    [Serializable]
    public class Config
    {
        //数据库链接
        public static string MBDBConnStr = ConfigurationManager.AppSettings["serverAddress"];
    }
}
