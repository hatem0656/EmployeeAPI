using EmployeeAPI.Models;
using EmployeeAPI.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public ICollection<AddressDto> Addresses { get; set; }
    }
}
