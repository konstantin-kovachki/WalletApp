# Secure Digital Wallet

A simple website for managing digital wallets, built with ASP.NET Core MVC (Version 1).

## What it does

- Register, log in and log out
- Create, view, edit and delete your own wallets
- Choose a currency (EUR, USD, BGN or GBP)
- A wallet number is created automatically
- Each user sees only their own wallets

## Not included yet

Deposits, withdrawals, transfers between wallets, transaction history and currency conversion will be in Version 2. A new wallet always starts with a balance of 0.

## Technologies

C#, ASP.NET Core MVC (.NET 8), Entity Framework Core, SQL Server, ASP.NET Core Identity, Razor and Bootstrap.

## How the project is built

The solution has six projects:

| Project | What it is for |
|---|---|
| `SecureDigitalWallet.Web` | Pages, controllers and app startup |
| `SecureDigitalWallet.Services.Core` | The wallet logic |
| `SecureDigitalWallet.Data` | The database connection and migrations |
| `SecureDigitalWallet.DataModels` | The database tables as C# classes |
| `SecureDigitalWallet.ViewModels` | The models used by forms and pages |
| `SecureDigitalWallet.GCommon` | Shared constants |

A request goes like this: **Browser → Controller → Service → Database**.

## Database

Three tables: **Wallet**, **WalletTransaction** (prepared for later versions) and **CurrencyAccount** (the list of currencies). One currency has many wallets, and one wallet has many transactions.

## How to run it

You need: **Visual Studio**, the **.NET SDK** 8, and **SQL Server**.

**1. Open the project**

Download or clone the repository and open the file `SecureDigitalWallet.sln` in Visual Studio.

**2. Check the database connection**

Open `SecureDigitalWallet.Web/appsettings.json` and find the line with `DefaultConnection`:

```text
"DefaultConnection": "Server=.;Database=SecureDigitalWalletDb;Trusted_Connection=True;Encrypt=False"
```

- If you use a normal local SQL Server, **change nothing**.
- If your server has another name, replace the `.` after `Server=` with it. For example, for SQL Server Express:
  `"Server=.\\SQLEXPRESS;Database=SecureDigitalWalletDb;Trusted_Connection=True;Encrypt=False"`


**3. Choose the startup project**

In Solution Explorer, right-click `SecureDigitalWallet.Web` and choose **Set as Startup Project**. Its name becomes bold.

**4. Create the database**

Open **Tools → NuGet Package Manager → Package Manager Console**. At the top of that window, set **Default project** to `SecureDigitalWallet.Data`. Type this and press Enter:

```text
Update-Database
```

This creates the database and fills in the currency list.

**5. Start the app**

Press **F5**.

## Logins and settings

- No environment variables are needed.
- There are no ready-made users. Click **Register** to create one.
- The password needs at least 6 characters, with an uppercase letter, a lowercase letter, a number and a symbol (for example `Test123!`).

## Screenshots

![Home page](docs/screenshots/home.png)
![Wallets page](docs/screenshots/wallets.png)

## Future plans

Deposits and withdrawals, transfers between wallets, transaction history and currency conversion.