using System.Collections.Generic;

namespace KalleFBankALM
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public List<Account> CustomerAccounts { get; set; }
    }
}
