using System.ComponentModel.DataAnnotations;

namespace Interworks.API.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }
}