
using EmployeeMvcNew.EmpRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace employeeAPINew.Controllers
{
    [Route("api/Employees")]
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        public IActionResult GetEmployee()
        {
            try
            {
                var employeeRepository = new EmployeeRepository();
                var employee = employeeRepository.GetEmployees();
                return Ok(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
