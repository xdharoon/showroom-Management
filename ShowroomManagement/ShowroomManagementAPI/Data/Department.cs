using System.ComponentModel.DataAnnotations;

namespace ShowroomManagementAPI.Data
{
    public class Department
    {
        [Key]
        public  int Id { get; set; }
        public String Name { get; set; }
        public  string Description { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}
