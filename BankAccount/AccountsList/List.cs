using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class AccountsList
    {
        public List<Account> Accountslist { get; set; }

        public AccountsList()
        {
            Accountslist = new List<Account>();
        }
    }
}
