using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;

namespace Client
{
    public partial class Form1 : Form
    {
        public static HttpClient client;
        public static string local = "http://localhost:5164/api/Employee";
        public Form1()
        {
            client = new HttpClient();
            InitializeComponent();
        }
        public List <Employee> getEmployees()
        {
            List<Employee> employees = new List<Employee>();

            for (int i = 1; i <= 10; i++)
            {
                Employee employee = new Employee();
                employee.EmployeeId = i;
                employee.LastName = "Last Name " + i;
                employee.FirstName = "First Name " + i;
                employee.Title = "Title " + i;
                employees.Add(employee);
            }
          return employees;

        }
        private void btAddList_Click(object sender, EventArgs e)
        {
           List<Employee> employees = getEmployees();
           int status = Task.Run(() => AddListEmployee(employees)).Result;

        }

        internal static async Task<int> AddListEmployee(List<Employee> employees)
        {
            string url = $"{local}/addList";
            string json = JsonSerializer.Serialize(employees);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return 200;
            }
            return -1;
        }



    }
}