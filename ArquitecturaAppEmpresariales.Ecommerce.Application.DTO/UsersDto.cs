using System.ComponentModel.DataAnnotations;

namespace ArquitecturaAppEmpresariales.Ecommerce.Application.DTO
{
    public class UsersDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //[Required]
        public string UserName { get; set; } = string.Empty;
        //[Required]
        public string Password { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
