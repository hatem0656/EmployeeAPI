﻿using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

       public DbSet<Employee> Employees { get; set; }
       public  DbSet<Address> Addresses { get; set; }


    }
}
