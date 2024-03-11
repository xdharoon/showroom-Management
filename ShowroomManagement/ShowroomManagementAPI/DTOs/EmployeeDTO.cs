using Microsoft.AspNetCore.Http;

namespace ShowroomManagementAPI.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public string Cnic { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public int DepartmentId { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
