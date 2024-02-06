using System.Net.NetworkInformation;

namespace ShowroomManagementAPI.DTOs
{
    public class ResponseDTO
    {
        public int SatutsCode { get; set; }
        public String ErrorMessage { get; set; }
        public dynamic Response{ get; set; }

    }
}
