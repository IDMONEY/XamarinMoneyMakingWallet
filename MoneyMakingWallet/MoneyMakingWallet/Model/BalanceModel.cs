namespace IDMONEY.IO.Model
{
    public class BalanceModel : Balance
    {
    }

    public class Balance
    {
        public Balance()
        {
            this.Available = 0;
            this.Blocked = 0;
        }

        public decimal Available { get; set; }

        public decimal Blocked { get; set; }
    }
}
