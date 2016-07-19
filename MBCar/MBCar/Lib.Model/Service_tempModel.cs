using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class Service_tempModel
    {
        private int service_id;

        private string service_nm;

        private string service_parrents_nm;

        private int count;

        private decimal amount;

        private DateTime start_ts;

        private DateTime end_ts;

        public int Service_id
        {
            get
            {
                return service_id;
            }

            set
            {
                service_id = value;
            }
        }

        public string Service_nm
        {
            get
            {
                return service_nm;
            }

            set
            {
                service_nm = value;
            }
        }

        public string Service_parrents_nm
        {
            get
            {
                return service_parrents_nm;
            }

            set
            {
                service_parrents_nm = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public DateTime Start_ts
        {
            get
            {
                return start_ts;
            }

            set
            {
                start_ts = value;
            }
        }

        public DateTime End_ts
        {
            get
            {
                return end_ts;
            }

            set
            {
                end_ts = value;
            }
        }
    }
}
