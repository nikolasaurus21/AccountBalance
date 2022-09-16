using AccountBalance.Models;

namespace AccountBalance.Data
{
    public class MoneyHistoryDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public HistoryType HistoryType { get; set; }

        public int MoneyAccId { get; set; }
    } 
}
