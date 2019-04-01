using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    interface IContactDetailsRepository
    {
        void AddContact();
        void UpdateContact();
        void DeleteContact();
    }
}
