namespace Application.Features.UserFeatures.CreateUserCSV
{
    public class CreateUserCSVResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
