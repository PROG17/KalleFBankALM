using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KalleFBankALM.Models;

namespace KalleFBankALM.ViewModels
{
    public class TransferViewModel
    {
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public decimal TransferAmount { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
        public string Message { get; set; }
    }
}
