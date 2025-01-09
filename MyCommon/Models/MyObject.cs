using MyCommon.Enums;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security;

namespace MyCommon.Models
{
    public partial class MyObject
    {
        [Display(Name = "Server address", GroupName = "Objects")]
        [Required(ErrorMessage = "Not specified.")]
        public EndPoint EndPoint { get; set; }

        [Display(Name = "Password", GroupName = "Objects")]
        [Required(ErrorMessage = "Not specified.")]
        public SecureString Password { get; set; }

        [Display(Order = 3, GroupName = "Test")]
        [Required(ErrorMessage = "Not specified.")]
        public string Login { get; set; }

        [Display(Order = 2, GroupName = "Test")]
        [Range(0, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Required(ErrorMessage = "Not specified.")]
        public int Integer { get; set; }

        [Display(Order = 1, GroupName = "Test")]
        public EnumA EnumA { get; set; }

        [Display(Order = 4, GroupName = "Test")]
        public EnumB EnumB { get; set; }

        [Display(Order = 1, GroupName = "Sub")]
        public MySubObject MySubObject { get; set; } = new MySubObject();

        public override string ToString()
        {
            return $"override ToString: {Login}";
        }
    }
}
