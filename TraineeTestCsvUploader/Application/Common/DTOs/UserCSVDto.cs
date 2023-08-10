using CsvHelper;

namespace Application.Common.DTOs
{
    public class UserCSVDto
    {
        [CsvHelper.Configuration.Attributes.Name("Name")]
        public string Name { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Date of birth")]
        public string DateOfBirth { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Married")]
        public bool Married { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Phone")]
        public string Phone { get; set; }

        [CsvHelper.Configuration.Attributes.Name("Salary")]
        public decimal Salary { get; set; }
    }
}
