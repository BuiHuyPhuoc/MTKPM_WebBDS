using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace webbds.Class
{
    abstract class PasswordValidation
    {
        public string ValidatePassword(string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(CheckLength(password));
            stringBuilder.Append(CheckUppercase(password));
            stringBuilder.Append(CheckLowercase(password));
            stringBuilder.Append(CheckHasNumber(password));
            stringBuilder.Append(CheckHasSpecialCharacter(password));
            return stringBuilder.ToString();
        }

        public virtual string CheckLength(string password)
        {
            return "";
        }
        public virtual string CheckUppercase(string password)
        {
            return "";
        }
        public virtual string CheckLowercase(string password)
        {
            return "";
        }
        public virtual string CheckHasNumber(string password)
        {
            return "";
        }
        public virtual string CheckHasSpecialCharacter(string password)
        {
            return "";
        }
    }

    class PhuocPasswordValidation : PasswordValidation
    {
        public override string CheckLength(string password)
        {
            return (password.Length >= 8) ? "" : "Mật khẩu phải trên 8 kí tự.\n";
        }

        public override string CheckUppercase(string password)
        {
            return password.Any(char.IsUpper) ? "" : "Mật khẩu phải có chữ in hoa \n";
        }

        public override string CheckLowercase(string password)
        {
            return password.Any(char.IsLower) ? "" : "Mật khẩu phải có chữ thường \n";
        }
        public override string CheckHasNumber(string password)
        {
            return password.Any(char.IsDigit) ? "" : "Mật khẩu phải có kí tự số \n";
        }

        public override string CheckHasSpecialCharacter(string password)
        {
            Regex regex = new Regex("[~`!@#$%^&*()\\-_=+\\\\|\\[{\\]};:'\",<.>/?]");
            return regex.IsMatch(password) ? "" : "Mật khẩu phải có kí tự đặc biệt";
        }
    }

    
}