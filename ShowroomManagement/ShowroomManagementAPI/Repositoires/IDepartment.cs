using ShowroomManagementAPI.DTOs;

namespace ShowroomManagementAPI.Repositoires
{
    public interface IDepartment
    {
        public Task<ResponseDTO> GetDepartment();

        public Task<ResponseDTO> AddDepartment(DepartmentDTO departmentDTO);

        public  Task<ResponseDTO> DeleteDepartment(int Id);

        public Task<ResponseDTO> GetDeparmtById(int Id);

        public Task<ResponseDTO> UpdateDepartment(DepartmentDTO departmentDTO);
        
    }
}
