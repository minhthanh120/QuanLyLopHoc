using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace QuanLyLopHoc.Utilities
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MailValidatorAttribute : ValidationAttribute, IClientModelValidator
    {
        public MailValidatorAttribute()
        {
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-mail", "Thông tin Email của bạn chưa hợp lệ");
        }

        public override bool IsValid(object value)
        {
            string mail = value.ToString();
            string pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
            return Regex.IsMatch(mail, pattern);
        }
    }
    public interface IClientValidatable
    {
        public bool IsValid(object value);
    }
}
