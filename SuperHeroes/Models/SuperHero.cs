namespace SuperHeroes.Models
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string RealName { get; set; }=string.Empty ;
        public List<Power> Powers { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
