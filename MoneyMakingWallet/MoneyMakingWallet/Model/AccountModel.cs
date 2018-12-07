namespace IDMONEY.IO.Model
{
    public class AccountModel : Account
    {
    }

    public class Account
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string PrivateKey { get; set; }
        public AccountType Type { get; set; }
        public Balance Balance { get; set; }
    }
}
