using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AccountBalance.Models
{
    public class MoneyAccount
    {
        [Key]
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Expences { get; set; }
        public decimal Saved { get; set; }
        public decimal Salary { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        
        public ICollection<MoneyHistory> MoneyHistories { get; set; } = new List<MoneyHistory>();
       
    }
}
