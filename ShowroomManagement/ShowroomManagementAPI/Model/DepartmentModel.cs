using Microsoft.EntityFrameworkCore;
using ShowroomManagementAPI.Data;
using ShowroomManagementAPI.DTOs;
using ShowroomManagementAPI.Repositoires;

namespace ShowroomManagementAPI.Model
{
    public class DepartmentModel : IDepartment
    {
        private readonly ApplicationDbContext Dbcontext;

        public DepartmentModel(ApplicationDbContext dbcontext)
        {
            this.Dbcontext = dbcontext;
        }

        public async Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO)
        {
          var response = new ResponseDTO();

            try
            {
                var department = new Department()
                {
                    Name = departmentDTO.Name,
                    Description = departmentDTO.Description,
                };
                await Dbcontext.Departments.AddAsync(department);
                await Dbcontext.SaveChangesAsync();
                response.Response = "Department created Successfully ";

            }
            catch(Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDTO> DeleteDepartment(int Id)
        {
            var response = new ResponseDTO();
             
            try
            {
                var department = await Dbcontext.Departments.Where(x=>x.Id==Id).FirstOrDefaultAsync();

                Dbcontext.Departments.Remove(department);
                await Dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseDTO> GetDeparmtById(int Id)
        {
            var response = new ResponseDTO();

            try
            {
                var department = await Dbcontext.Departments.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (department == null)
                {
                    response.SatutsCode = 404;
                }
                else
                {
                    response.Response = department;
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<ResponseDTO> GetDepartment()
        {

            var response = new ResponseDTO();

            try
            {
                response.Response = await Dbcontext.Departments.ToListAsync();
            }
            catch(Exception ex)
                {
              response.ErrorMessage = ex.Message;
            }
            return response;
        }

       

        public async Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO)
        {
            var response = new ResponseDTO();

            try
            {
                var record = await Dbcontext.Departments.Where(x => x.Id == departmentDTO.Id).FirstOrDefaultAsync();
                record.Name = departmentDTO.Name;
                record.Description = departmentDTO.Description;
                 Dbcontext.Departments.Update(record);
             await    Dbcontext.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        
    }
}
