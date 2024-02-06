using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using Newtonsoft.Json;
using ShowroomManagementAPI.DTOs;
using ShowroomManagementAPI.Repositoires;

namespace ShowroomManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _Services;


        public DepartmentController(IDepartment Services)
        {
            this._Services = Services;
        }



        [HttpGet("GetDepartment")]
        public async Task<string> GetDepartment()
        {
            var data = await _Services.GetDepartment();
            var Dataconvert = JsonConvert.SerializeObject(data);
            return Dataconvert;


        }

        [HttpPost("AddDepartment")]
        public async Task<string> AddDepartment(DepartmentDTO departmentDTO)
        {
            return JsonConvert.SerializeObject(await _Services.AddDepartment(departmentDTO));
        }

        [HttpGet("GetDepartmentById/{id}")]
        public async Task<string> GetDepartmentById(int Id)
        {
            return JsonConvert.SerializeObject(await _Services.GetDeparmtById(Id));
        }

        [HttpGet("DeleteDepartment/{Id}")]
        public async Task<string> DeleteDepartment(int Id)
        {
            return JsonConvert.SerializeObject(await _Services.DeleteDepartment(Id));
        }

        [HttpPost("UpdateDepartment")]
        public async Task<string> UpdateDepartment(DepartmentDTO departmentDTO)
        {

            return JsonConvert.SerializeObject(await _Services.UpdateDepartment(departmentDTO));
        }
    }
}
