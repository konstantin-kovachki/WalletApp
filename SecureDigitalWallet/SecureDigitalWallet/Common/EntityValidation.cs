namespace SecureDigitalWallet.Common
{
    public static class EntityValidation
    {
        //CurrencyAccount
        public const int CurrencyMaxLength = 3;
        public const int CurrencyNameMaxLength = 50;

        //Wallet
        public const int WalletNumberMaxLength = 20;
        public const int WalletCurrencyMaxLength = 3;

        //Transaction
        public const int TransactionDescriptionMaxLength = 200;
    }
}
