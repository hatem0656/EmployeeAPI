using AutoMapper;
using EmployeeAPI.Dtos;
using EmployeeAPI.IServices;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeGetAllResponse> GetAllEmployees(int page)
        {

            var pageResults = 2f;
            var pageCount = Math.Ceiling(_context.Employees.Count() / pageResults);

            var employees = await _context.Employees
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .Include(employee => employee.Addresses)
                .ToListAsync();

            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            var response = new EmployeeGetAllResponse
            {
                Employees = mappedEmployees,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return response;

        }

        public async Task<EmployeeDto?> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.Include(employee => employee.Addresses).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return null;

            var data = _mapper.Map<EmployeeDto>(employee);

            return data;
        }

        public async Task<EmployeeDto> AddEmployee(EmployeeAddRequest newEmployee)
        {
            var employee = _mapper.Map<Employee>(newEmployee);

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            var data = _mapper.Map<EmployeeDto>(employee);
            return data;

        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeUpdateRequest newEmployee)
        {

            var updatedEmployee = _mapper.Map<Employee>(newEmployee);

            _context.Entry(updatedEmployee).State = EntityState.Modified;

            foreach (var address in updatedEmployee.Addresses)
            {
                if (address.Id == Guid.Empty)
                {
                    _context.Entry(address).State = EntityState.Added;
                }
                else
                {
                    _context.Entry(address).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();

            var data = _mapper.Map<EmployeeDto>(updatedEmployee);
            return data;
        }

        public async Task<Guid> DeleteEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return Guid.Empty;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
