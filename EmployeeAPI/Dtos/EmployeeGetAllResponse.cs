namespace EmployeeAPI.Dtos
{
    public class EmployeeGetAllResponse
    {
        public IEnumerable<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();

        public int CurrentPage { get; set; } 
        public int TotalPages { get; set; }


    }
}
