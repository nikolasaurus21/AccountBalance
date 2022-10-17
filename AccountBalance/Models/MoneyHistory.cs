using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AccountBalance.Models
{
    public class MoneyHistory
    {
        [Key]
        public int Id { get; set; }

        
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public HistoryType HistoryType { get; set; }

        public MoneyAccount MoneyAccount { get; set; }
        public int? MoneyAccId { get; set; }
        
        

    }
}
