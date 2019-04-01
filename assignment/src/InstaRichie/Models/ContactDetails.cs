using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace StartFinance.Models
{
    class ContactDetails
    {
        [PrimaryKey, AutoIncrement]
        public int ContactID { get; set; }

        [NotNull]
        public string ContactFirstName { get; set; }

        [NotNull]
        public double ContactLastName { get; set; }

        [NotNull]
        public double ContactCompanyName { get; set; }

        public double ContactMobilePhone { get; set; }
    }
}
