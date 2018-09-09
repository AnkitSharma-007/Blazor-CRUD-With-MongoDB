using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using BlazorWithMongo.Shared.Models;

namespace BlazorWithMongo.Client.Pages
{
    public class EmployeeDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Http { get; set; }

        protected List<Employee> empList;
        protected List<Cities> cityList = new List<Cities>();

        protected Employee emp = new Employee();
        protected string modalTitle { get; set; }
        protected Boolean isDelete = false;
        protected Boolean isAdd = false;

        protected string SearchString { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetEmployee();
            await GetCities();
        }

        protected async Task GetEmployee()
        {
            empList = await Http.GetJsonAsync<List<Employee>>("api/Employee/Index");
        }

        protected async Task GetCities()
        {
            cityList = await Http.GetJsonAsync<List<Cities>>("api/Employee/GetCities");
        }

        protected void AddEmp()
        {
            emp = new Employee();
            this.modalTitle = "Add Employee";
            this.isAdd = true;
        }

        protected async Task EditEmployee(string ID)
        {
            emp = await Http.GetJsonAsync<Employee>("/api/Employee/Details/" + ID);
            this.modalTitle = "Edit Employee";
            this.isAdd = true;
        }

        protected async Task SaveEmployee()
        {
            if (emp.Id != null)
            {
                await Http.SendJsonAsync(HttpMethod.Put, "api/Employee/Edit", emp);
            }
            else
            {
                await Http.SendJsonAsync(HttpMethod.Post, "/api/Employee/Create", emp);

            }
            this.isAdd = false;
            await GetEmployee();
        }

        protected async Task DeleteConfirm(string ID)
        {
            emp = await Http.GetJsonAsync<Employee>("/api/Employee/Details/" + ID);
            this.isDelete = true;
        }

        protected async Task DeleteEmployee(string ID)
        {
            await Http.DeleteAsync("api/Employee/Delete/" + ID);

            this.isDelete = false;
            await GetEmployee();
        }
        protected void closeModal()
        {
            this.isAdd = false;
            this.isDelete = false;
        }
    }
}