using ShowroomManagementAPI.Data;
using ShowroomManagementAPI.DTOs;
using ShowroomManagementAPI.Repositoires;
using System.Reflection.Metadata.Ecma335;

namespace ShowroomManagementAPI.Model
{
    public class EmployeeModel : IEmployee
    {
        private readonly ApplicationDbContext dbContext;
        private IWebHostEnvironment webHostEnvironment;

        public EmployeeModel(ApplicationDbContext Context ,IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = Context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<ResponseDTO> AddEmployee(EmployeeDTO employeeDTO)
        {
            var response = new  ResponseDTO();
            try
            {
                string path = "";
                if (employeeDTO.ProfileImage != null)
                {
                    var fileName = employeeDTO.ProfileImage.FileName;
                    path = Path.Combine(webHostEnvironment.WebRootPath,"uploads");
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await employeeDTO.ProfileImage.CopyToAsync(stream);
                    }

                }

                var employee = new Employee()
                {
                    Name  = employeeDTO.Name,
                    Email = employeeDTO.Email,
                    Cnic  = employeeDTO.Cnic,
                    Address = employeeDTO.Address,
                    Contact = employeeDTO.Contact,
                    DepartmentId = employeeDTO.DepartmentId,
                    ProfileImagePath= path
                };

                await dbContext.Employees.AddAsync(employee);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
        
    }
}
