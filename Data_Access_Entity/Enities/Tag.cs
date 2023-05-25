using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Entity.Entities
{
    public class Tag
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public List<Game> _Games { get; set; }
    }
}
