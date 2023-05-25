using System.ComponentModel.DataAnnotations;

namespace Data_Access_Entity.Entities
{
    public class Account
    {
        public int ID { get; set; }
        [Required, MaxLength(100)] 
        public string AccountType { get; set; }
        public int ClientID { get; set; }
        public Client _Client { get; set; }
    }
}
