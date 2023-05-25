using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Entity.Entities
{
    public class SupportedLanguage
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string Language { get; set; }
        public List<Game> _Games { get; set; }
    }
}
