namespace Medical_Laboratory_Management.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public State State { get; set; }
        public ICollection<User> Users { get; set; }
    }

}
