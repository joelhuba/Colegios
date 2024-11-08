using System.Text.Json.Serialization;

namespace Colegios.Core.DTOs
{
    public class UserDTO
    {
        public int? IdUser { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdRol {  get; set; } 
        public bool Status { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }

    }
}
