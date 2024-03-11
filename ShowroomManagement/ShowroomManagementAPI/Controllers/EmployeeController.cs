using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowroomManagementAPI.DTOs;
using ShowroomManagementAPI.Repositoires;

namespace ShowroomManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        public IEmployee service;

        public EmployeeController(IEmployee employee)
        {
            this.service = employee;
        }
        [HttpPost("AddEmployee")]
        public async Task<string> AddEmployee([FromForm]EmployeeDTO employeeDTO)
        {
            return JsonConvert.SerializeObject(await service.AddEmployee(employeeDTO));
                
                
                }
    }
}
