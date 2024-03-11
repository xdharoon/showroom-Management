using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowroomManagementAPI.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public string Cnic { get; set; }
        public string Address{ get; set; }
        public string Contact { get; set; }

        public string ProfileImagePath { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
