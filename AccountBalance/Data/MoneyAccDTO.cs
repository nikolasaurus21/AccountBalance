namespace AccountBalance.Data
{
    public class MoneyAccDTO
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Expences { get; set; }
        public decimal Saved { get; set; }
        public decimal Salary { get; set; }
        public int UserId { get; set; }
        
    }
}
