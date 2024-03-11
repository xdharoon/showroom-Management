using ShowroomManagementAPI.DTOs;

namespace ShowroomManagementAPI.Repositoires
{
    public interface IEmployee
    {

        public Task<ResponseDTO> AddEmployee(EmployeeDTO employeeDTO);
    }
}
