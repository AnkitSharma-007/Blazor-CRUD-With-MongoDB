using BlazorWithMongo.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithMongo.Server.Interface
{
    public interface IEmployee
    {
        public List<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);
        public Employee GetEmployeeData(string id);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(string id);
        public List<Cities> GetCityData();

    }
}
