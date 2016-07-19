using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model
{
    public class ServiceModel
    {
        private string plate_id;

        private string owner_nm;

        private string card_id;

        private string card_type;

        private decimal balance_card;

        private string per_user_card;

        private string year_card;

        private DateTime member_start_ts;

        private DateTime member_end_ts;

        private DateTime create_ts;

        private DateTime update_ts;

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

        public string Card_id
        {
            get
            {
                return card_id;
            }

            set
            {
                card_id = value;
            }
        }

        public decimal Balance_card
        {
            get
            {
                return balance_card;
            }

            set
            {
                balance_card = value;
            }
        }

        public string Per_user_card
        {
            get
            {
                return per_user_card;
            }

            set
            {
                per_user_card = value;
            }
        }

        public string Year_card
        {
            get
            {
                return year_card;
            }

            set
            {
                year_card = value;
            }
        }

        public DateTime Member_start_ts
        {
            get
            {
                return member_start_ts;
            }

            set
            {
                member_start_ts = value;
            }
        }

        public DateTime Member_end_ts
        {
            get
            {
                return member_end_ts;
            }

            set
            {
                member_end_ts = value;
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
