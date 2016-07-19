using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class EmployeeModel
    {
        private int eID;

        private string employee_nm;

        private string user_nm;

        private string user_pw;

        private string role;

        private DateTime create_ts;

        private DateTime update_ts;

        public int EID
        {
            get
            {
                return eID;
            }

            set
            {
                eID = value;
            }
        }

        public string Employee_nm
        {
            get
            {
                return employee_nm;
            }

            set
            {
                employee_nm = value;
            }
        }

        public string User_nm
        {
            get
            {
                return user_nm;
            }

            set
            {
                user_nm = value;
            }
        }

        public string User_pw
        {
            get
            {
                return user_pw;
            }

            set
            {
                user_pw = value;
            }
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
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

        public DateTime Update_ts
        {
            get
            {
                return update_ts;
            }

            set
            {
                update_ts = value;
            }
        }
    }
}
