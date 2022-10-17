using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AccountBalance.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        public  MoneyAccount MoneyAccounts { get; set; }
       
        
    }
}
