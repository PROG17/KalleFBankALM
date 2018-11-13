using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KalleFBankALM.ViewModels;

namespace KalleFBankALM.Controllers
{
    public class TransferController : Controller
    {
        private IBankRepository _bankRepository;

        public TransferController(IBankRepository bankRepo)
        {
            _bankRepository = bankRepo;
        }

        public IActionResult MakeTransfer()
        {
            return View(new TransferViewModel());
        }

        [HttpPost]
        public IActionResult MakeTransfer(TransferViewModel model)
        {
            return View(_bankRepository.Transfer(model));
        }
    }
}