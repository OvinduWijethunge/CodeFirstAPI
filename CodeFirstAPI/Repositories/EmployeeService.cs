using CodeFirstAPI.IRepositories;
using CodeFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstAPI.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeContext _context;
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }




        public ResponseModel DeleteEmployee(int employeeId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employee _temp = GetEmployeeDetailsById(employeeId);
                if (_temp != null)
                {
                    _context.Remove<Employee>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Employee Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public Employee GetEmployeeDetailsById(int empId)
        {
            Employee emp;
            try
            {
                emp = _context.Find<Employee>(empId);
            }
            catch (Exception)
            {
                throw;
            }
            return emp;
        }

        public List<Employee> GetEmployeesList()
        {
            List<Employee> empList;
            try
            {
                empList = _context.Set<Employee>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return empList;
        }

        public ResponseModel SaveEmployee(Employee employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                _context.Add<Employee>(employeeModel);
                model.Messsage = "Employee Inserted Successfully";
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel UpdateEmployee(Employee employeeModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employee _temp = GetEmployeeDetailsById(employeeModel.EmployeeId);
                if (_temp != null)
                {
                    _temp.Designation = employeeModel.Designation;
                    _temp.EmployeeFirstName = employeeModel.EmployeeFirstName;
                    _temp.EmployeeLastName = employeeModel.EmployeeLastName;
                    _temp.Salary = employeeModel.Salary;
                    _context.Update<Employee>(_temp);
                    model.Messsage = "Employee Update Successfully";
                }
                else
                {
                    
                    model.Messsage = "Employeee is not in our data base";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
