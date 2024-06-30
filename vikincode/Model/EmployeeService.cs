using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vikincode.Model
{
    public class EmployeeService
    {
        private static List<Employee> _employeesList;

        public EmployeeService()
        {
            _employeesList = new List<Employee>()
            {
                new Employee
                {
                    Id = 101,
                    Name = "Siva",
                    Job = "Developer",
                    Department = "IT"
                }
            };
        }

        public List<Employee> GetAll()
        {
            return _employeesList;
        }

        public bool Add(Employee newEmployee)
        {
            _employeesList.Add(newEmployee);
            return true;
        }

        public bool Update(Employee employeeToUpdate)
        {
            bool isUpdated = false;
            for (int i = 0; i < _employeesList.Count; i++)
            {
                if (_employeesList[i].Id == employeeToUpdate.Id)
                {
                    _employeesList[i].Name = employeeToUpdate.Name;
                    _employeesList[i].Job = employeeToUpdate.Job;
                    _employeesList[i].Department = employeeToUpdate.Department;
                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for (int i = 0; i < _employeesList.Count; i++)
            {
                if (_employeesList[i].Id == id)
                {
                    _employeesList.RemoveAt(i);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }
    }
}
