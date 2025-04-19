using System.ComponentModel.DataAnnotations;

namespace WebCoreApi_Login_Net8.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; } 
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Username { get; set; }
       public string Password { get; set; }
        public int IsActive { get; set; } = 1;
        public DateTime CreateOn { get; set; } = DateTime.Now;
    }
}
