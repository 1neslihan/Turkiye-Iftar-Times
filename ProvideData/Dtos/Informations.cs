namespace DataProvider.Dtos
{
    public class Informations
    {
        public string time { get; set; }
        public string hour { get; set; }
        public string min { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public List<Informations> result { get; set; }
    }



}