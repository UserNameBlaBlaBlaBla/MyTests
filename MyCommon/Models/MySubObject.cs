using MyCommon.ViewModels;

namespace MyCommon.Models
{
    //[TypeConverter(typeof(ExpandableObjectConverter))]
    public partial class MySubObject : BaseViewModel
    {
        private int _myInteger;
        private string _myString;
        private bool _myBool;

        public int MyInteger
        {
            get => _myInteger;
            set { _myInteger = value; RaisePropertyChanged(nameof(MyInteger)); }
        }

        public string MyString
        {
            get => _myString;
            set { _myString = value; RaisePropertyChanged(nameof(MyString)); }
        }

        public bool MyBool
        {
            get => _myBool;
            set { _myBool = value; RaisePropertyChanged(nameof(MyBool)); }
        }
    }
}
