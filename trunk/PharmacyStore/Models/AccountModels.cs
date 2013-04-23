using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Security;

namespace PharmacyStore.Models
{
    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Ghi nhớ?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "Bạn phải nhập Tên tài khoản.")]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Họ và tên.")]
        [Display(Name = "Họ và tên")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu.")]
        [StringLength(100, ErrorMessage = "{0} phải có ít nhất {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu nhập lại không chính xác.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập địa chỉ Email.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Xác nhận Email")]
        [Compare("Email", ErrorMessage = "Email nhập lại không chính xác.")]
        public string ConfirmEmail { get; set; }

        [MustBeSelected(ErrorMessage = "Bạn phải chọn giới tính.")]
        [DataType(DataType.Text)]
        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Điện thoại")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập ngày sinh.")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập CMND.")]
        [Display(Name = "CMND")]
        public string Identification { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Người giới thiệu")]
        public string UserRefer { get; set; }

        [Display(Name = "Tôi cam kết đồng ý và thực hiện đúng các Quy định của MegaBook.com")]
        [MustBeTrue(ErrorMessage = "Bạn chưa cam kết đồng ý các quy định của MegaBook.com")]
        public bool TermsAccepted { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }

    public class MustBeTrueAttribute : ValidationAttribute, System.Web.Mvc.IClientValidatable // IClientValidatable for client side Validation
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
        // Implement IClientValidatable for client side Validation
        public IEnumerable<System.Web.Mvc.ModelClientValidationRule> GetClientValidationRules(System.Web.Mvc.ModelMetadata metadata, System.Web.Mvc.ControllerContext context)
        {
            return new System.Web.Mvc.ModelClientValidationRule[] { new System.Web.Mvc.ModelClientValidationRule { ValidationType = "checkbox", ErrorMessage = this.ErrorMessage } };
        }
    }
    public class MustBeSelected : ValidationAttribute, System.Web.Mvc.IClientValidatable // IClientValidatable for client side Validation
    {
        public override bool IsValid(object value)
        {
            if (value == null || Convert.ToInt32(value) == 0)
                return false;
            else
                return true;
        }
        // Implement IClientValidatable for client side Validation
        public IEnumerable<System.Web.Mvc.ModelClientValidationRule> GetClientValidationRules(System.Web.Mvc.ModelMetadata metadata, System.Web.Mvc.ControllerContext context)
        {
            return new System.Web.Mvc.ModelClientValidationRule[] { new System.Web.Mvc.ModelClientValidationRule { ValidationType = "dropdown", ErrorMessage = this.ErrorMessage } };
        }
    }
}
