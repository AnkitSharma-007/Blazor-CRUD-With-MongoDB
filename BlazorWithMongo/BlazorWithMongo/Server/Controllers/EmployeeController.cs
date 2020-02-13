using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWithMongo.Server.Interface;
using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorWithMongo.Server.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee objemployee;

        public EmployeeController(IEmployee _objemployee)
        {
            objemployee = _objemployee;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return objemployee.GetAllEmployees();
        }

        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            objemployee.AddEmployee(employee);
        }

        [HttpGet("{id}")]
        public Employee Get(string id)
        {
            return objemployee.GetEmployeeData(id);
        }

        [HttpPut]
        public void Put([FromBody]Employee employee)
        {
            objemployee.UpdateEmployee(employee);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            objemployee.DeleteEmployee(id);
        }

        [HttpGet("GetCities")]
        public List<Cities> GetCities()
        {
            return objemployee.GetCityData();
        }
    }
}
