using EmployeeAPI.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [MaxLength(20)]
        [NoSpaces]
        public string Name { get; set; }

        [Range(20,100)]
        public int Age { get; set; }

        [NotEmpty]
        public ICollection<Address> Addresses { get; set; }


    }
}
