using BlazorWithMongo.Shared.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithMongo.Client.Pages
{
    public class EmployeeDataModel : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        protected List<Employee> empList = new List<Employee>();
        protected Employee emp = new Employee();
        protected string SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await GetEmployeeList();
        }

        protected async Task GetEmployeeList()
        {
            empList = await Http.GetJsonAsync<List<Employee>>("api/Employee");
        }
        protected async Task SearchEmployee()
        {
            await GetEmployeeList();
            if (!string.IsNullOrEmpty(SearchString))
            {
                empList = empList.Where(x => x.Name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }

        protected void DeleteConfirm(string ID)
        {
            emp = empList.FirstOrDefault(x => x.Id == ID);
        }

        protected async Task DeleteEmployee(string empID)
        {
            await Http.DeleteAsync("api/Employee/" + empID);
            await GetEmployeeList();
        }
    }
}
