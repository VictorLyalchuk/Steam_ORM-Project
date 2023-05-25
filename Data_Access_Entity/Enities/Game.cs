using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Entity.Entities
{
    public class Game
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int CostPrice { get; set; }
        public int Price { get; set; }
        public int Raiting { get; set; }
        public int CountOfSell { get; set; }
        public string OriginalGame { get; set; }
        public int DeveloperID { get; set; }
        public Developer _Developer { get; set; }
        public int PublisherID { get; set; }
        public Publisher _Publisher { get; set; }
        public int GenreID { get; set; }
        public Genre _Genre { get; set; }
        public int TagID { get; set; }
        public Tag _Tag { get; set; }
        public List<SupportedLanguage> _SupportedLanguages { get; set; }
        public List<ClientGame> _ClientGame { get; set; }
    }

}
