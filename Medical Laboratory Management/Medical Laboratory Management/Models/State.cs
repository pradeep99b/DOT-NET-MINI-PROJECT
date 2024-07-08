namespace Medical_Laboratory_Management.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public ICollection<City> Cities { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
