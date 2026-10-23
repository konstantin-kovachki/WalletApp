using Microsoft.AspNetCore.Mvc;
using SecureDigitalWallet.Services.Core;
using SecureDigitalWallet.Services.Core.Contracts;
using SecureDigitalWallet.ViewModels;
using System.Diagnostics;

namespace SecureDigitalWallet.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWalletService walletService;

        public HomeController(IWalletService walletService)
        {
            this.walletService = walletService;
        }

        public async Task<IActionResult> Index()
        {
            var wallets = await walletService.GetLatestWalletsAsync(3);

            var model = wallets
                .Select(w => new WalletIndexViewModel
            {
                Id = w.Id,
                Name = w.Name,
                WalletNumber = w.WalletNumber,
                Currency = w.Currency,
                Balance = w.Balance,
                CreatedAt = w.CreatedAt
            });

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
