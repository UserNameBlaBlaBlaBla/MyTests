using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security;

namespace EremexPropertyGridTest.Models
{
    public partial class MyObject
    {
        [Display(Name = "Server address", GroupName = "Objects")]
        [Required(ErrorMessage = "Not specified.")]
        public EndPoint EndPoint { get; set; }

        [Display(Name = "Password", GroupName = "Objects")]
        [Required(ErrorMessage = "Not specified.")]
        public SecureString Password { get; set; }

        [Display(Name = "Login", GroupName = "String")]
        [Required(ErrorMessage = "Not specified.")]
        public string Login { get; set; }

        [Display(Name = "Integer", GroupName = "Primitive types")]
        [Range(0, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "Not specified.")]
        public int Integer { get; set; }
    }
}
