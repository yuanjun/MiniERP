using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class CompanyModel
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        private int company_id;

        /// <summary>
        /// 公司名
        /// </summary>
        private string company_nm;

        /// <summary>
        /// 地址
        /// </summary>
        private string address;

        /// <summary>
        /// 电话
        /// </summary>
        private string phone;

        /// <summary>
        /// 鄂
        /// </summary>
        private string default_lisence_id;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime create_ts;

        /// <summary>
        /// 重置时间
        /// </summary>
        private DateTime upd_ts;

        public int Company_id
        {
            get
            {
                return company_id;
            }

            set
            {
                company_id = value;
            }
        }

        public string Company_nm
        {
            get
            {
                return company_nm;
            }

            set
            {
                company_nm = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Default_lisence_id
        {
            get
            {
                return default_lisence_id;
            }

            set
            {
                default_lisence_id = value;
            }
        }

        public DateTime Create_ts
        {
            get
            {
                return create_ts;
            }

            set
            {
                create_ts = value;
            }
        }

        public DateTime Upd_ts
        {
            get
            {
                return upd_ts;
            }

            set
            {
                upd_ts = value;
            }
        }
    }
}
