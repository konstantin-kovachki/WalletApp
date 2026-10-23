using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureDigitalWallet.Services.Core.Contracts;
using SecureDigitalWallet.Services.Core.DTOs.Requests;
using SecureDigitalWallet.ViewModels;
using System.Security.Claims;

namespace SecureDigitalWallet.Web.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletService walletService;

        public WalletController(IWalletService walletService)
        {
            this.walletService = walletService;
        }

        public async Task<IActionResult> Index()
        {
            var wallets = await walletService
                .GetAllWalletsAsync(GetUserId());

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

        public async Task<IActionResult> Details(int id)
        {
            var wallet = await walletService
                .GetWalletDetailsAsync(id, GetUserId());

            if (wallet == null)
            {
                return NotFound();
            }

            var model = new WalletDetailsViewModel
            {
                Id = wallet.Id,
                Name = wallet.Name,
                WalletNumber = wallet.WalletNumber,
                Currency = wallet.Currency,
                Balance = wallet.Balance,
                CreatedAt = wallet.CreatedAt,
                Transactions = wallet.Transactions
                    .Select(t => new TransactionViewModel
                    {
                        CreatedAt = t.CreatedAt,
                        Type = t.Type,
                        Amount = t.Amount,
                        Description = t.Description
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new WalletCreateViewModel
            {
                CurrencyAccounts = await GetCurrencyOptionsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WalletCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string name = model.Name.Trim();
                string walletNumber = model.WalletNumber.Trim();

                if (await walletService.WalletNumberExistsAsync(model.WalletNumber))
                {
                    ModelState.AddModelError(nameof(model.WalletNumber), "A wallet with this number already exists.");
                }
                else
                {

                    var dto = new WalletCreateDto
                    {
                        UserId = GetUserId(),
                        Name = model.Name,
                        WalletNumber = model.WalletNumber,
                        CurrencyAccountId = model.CurrencyAccountId
                    };

                    bool created = await walletService.CreateWalletAsync(dto);

                    if (created)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError(nameof(model.CurrencyAccountId), "Please select a valid currency.");
                }
            }
            model.CurrencyAccounts = await GetCurrencyOptionsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var wallet = await walletService.GetWalletByIdAsync(id, GetUserId());

            if (wallet == null)
            {
                return NotFound();
            }

            var model = new WalletEditViewModel
            {
                Id = wallet.Id,
                Name = wallet.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WalletEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new WalletEditDto
            {
                Id = model.Id,
                UserId = GetUserId(),
                Name = model.Name.Trim()
            };

            bool edited = await walletService.EditWalletAsync(dto);

            if (!edited)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var wallet = await walletService.GetWalletByIdAsync(id, GetUserId());

            if (wallet == null)
            {
                return NotFound();
            }

            var model = new WalletDeleteViewModel
            {
                Id = wallet.Id,
                Name = wallet.Name,
                WalletNumber = wallet.WalletNumber,
                Currency = wallet.Currency,
                Balance = wallet.Balance
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await walletService.DeleteWalletAsync(id, GetUserId());
            return RedirectToAction(nameof(Index));
        }

        private async Task<IEnumerable<CurrencyAccountViewModel>> GetCurrencyOptionsAsync()
        {
            var currencies = await walletService.GetAllCurrencyAccountsAsync();

            return currencies.Select(c => new CurrencyAccountViewModel
            {
                Id = c.Id,
                Currency = c.Currency,
                Name = c.Name
            });
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        }
    }
}
