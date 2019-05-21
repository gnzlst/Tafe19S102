using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace StartFinance.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ContactId { get; private set; }

        [NotNull]
        public string ContactFirstName { get; set; }

        [NotNull]
        public string ContactLastName { get; set; }

        public string ContactCompanyName { get; set; }

        public string ContactMobilePhone { get; set; }
    }
}
