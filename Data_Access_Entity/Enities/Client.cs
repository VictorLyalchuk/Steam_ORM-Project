using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Access_Entity.Entities
{
    public class Client
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Login { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        public int? AccountID { get; set; }
        public Account _Account { get; set; }
        public List<ClientGame> _ClientGame { get; set; }
    }
}