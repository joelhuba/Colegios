using System.Text.Json.Serialization;

namespace Colegios.Core.DTOs
{
    public class AuthUserDTO
    {
        public int? IdUser { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public DateTime birthday { get; set; }
        public string PhoneNumber { get; set; }
        public int IdRol { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Status { get; set; }
        public string UserName { get; set; }
        public string? Password { get; set; }

        [JsonIgnore]
        public string? PasswordSalt { get; set; }
    }
}
