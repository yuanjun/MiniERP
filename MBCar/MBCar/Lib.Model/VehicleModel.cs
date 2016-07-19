using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class VehicleModel
    {
        private string plate_id;

        private int control_No;

        private int membership;

        private string owner_nm;

        private string phone;

        private string model;

        private string color;

        private DateTime lisence_dt;

        private DateTime register_dt;

        private DateTime isurance_due_dt;

        private string vIN;

        private int mileage;

        private string notes;

        private string owner_doc;

        private DateTime update_ts;

        private DateTime create_ts;

        public string Plate_id
        {
            get
            {
                return plate_id;
            }

            set
            {
                plate_id = value;
            }
        }

        public int Control_No
        {
            get
            {
                return control_No;
            }

            set
            {
                control_No = value;
            }
        }

        public int Membership
        {
            get
            {
                return membership;
            }

            set
            {
                membership = value;
            }
        }

        public string Owner_nm
        {
            get
            {
                return owner_nm;
            }

            set
            {
                owner_nm = value;
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

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public DateTime Lisence_dt
        {
            get
            {
                return lisence_dt;
            }

            set
            {
                lisence_dt = value;
            }
        }

        public DateTime Register_dt
        {
            get
            {
                return register_dt;
            }

            set
            {
                register_dt = value;
            }
        }

        public DateTime Isurance_due_dt
        {
            get
            {
                return isurance_due_dt;
            }

            set
            {
                isurance_due_dt = value;
            }
        }

        public string VIN
        {
            get
            {
                return vIN;
            }

            set
            {
                vIN = value;
            }
        }

        public int Mileage
        {
            get
            {
                return mileage;
            }

            set
            {
                mileage = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        public string Owner_doc
        {
            get
            {
                return owner_doc;
            }

            set
            {
                owner_doc = value;
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
    }
}
