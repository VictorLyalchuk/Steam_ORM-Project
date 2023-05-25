namespace Data_Access_Entity.Entities
{
    public class ClientGame
    {
        public int ClientID { get; set; }
        public Client _Client { get; set; }
        public int GameID { get; set; }
        public Game _Game { get; set; }

    }
}