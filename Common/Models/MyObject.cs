using Common.Enums;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security;

namespace Common.Models
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

        private int? _nullableInt;
        public int? NullableInt
        {
            get => _nullableInt;
            set => _nullableInt = value;
        }

        [RelayCommand]
        public void Test()
        {
            int a = 0;
        }

        public override string ToString()
        {
            return $"override ToString: {Login}";
        }
    }
}
