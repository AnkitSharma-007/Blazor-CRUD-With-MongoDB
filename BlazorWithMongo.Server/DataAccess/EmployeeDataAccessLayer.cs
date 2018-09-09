using BlazorWithMongo.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithMongo.Server.DataAccess
{
    public class EmployeeDataAccessLayer
    {
        EmployeeDBContext db = new EmployeeDBContext();

        //To Get all employees details       
        public List<Employee> GetAllEmployees()
        {
            try
            {
                return db.EmployeeRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record       
        public void AddEmployee(Employee employee)
        {
            try
            {
                db.EmployeeRecord.InsertOne(employee);
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular employee      
        public Employee GetEmployeeData(string id)
        {
            try
            {
                FilterDefinition<Employee> filterEmployeeData = Builders<Employee>.Filter.Eq("Id", id);

                return db.EmployeeRecord.Find(filterEmployeeData).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee      
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                db.EmployeeRecord.ReplaceOne(filter: g => g.Id == employee.Id, replacement: employee);
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee      
        public void DeleteEmployee(string id)
        {
            try
            {
                FilterDefinition<Employee> employeeData = Builders<Employee>.Filter.Eq("Id", id);
                db.EmployeeRecord.DeleteOne(employeeData);
            }
            catch
            {
                throw;
            }
        }
        // To get the list of Cities  
        public List<Cities> GetCityData()
        {
            try
            {
                return db.CityRecord.Find(_ => true).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}