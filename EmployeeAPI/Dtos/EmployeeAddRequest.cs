using EmployeeAPI.Models;
using EmployeeAPI.Validation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Dtos
{
    public class EmployeeAddRequest
    {

        [MaxLength(20)]
        [NoSpaces]
        public string Name { get; set; }

        [Range(20, 100)]
        public int Age { get; set; }

        [NotEmpty]
        public ICollection<AddressDto> Addresses { get; set; }
    }
}
