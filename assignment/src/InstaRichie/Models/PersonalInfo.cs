using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace StartFinance.Models
{
    public class PersonalInfo
    {
        [PrimaryKey, AutoIncrement]
        public int PersonalId { get; private set; }

        [NotNull]
        public string FirstName { get; set; }

        [NotNull]
        public string LastName { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string EmailAddress { get; set; }

        public string MobilePhone { get; set; }
    }
}
