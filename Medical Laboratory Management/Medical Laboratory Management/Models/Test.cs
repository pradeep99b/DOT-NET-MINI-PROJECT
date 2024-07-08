namespace Medical_Laboratory_Management.Models
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public decimal Price { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
