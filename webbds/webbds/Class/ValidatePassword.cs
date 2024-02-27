using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webbds.Class
{
    internal abstract class PasswordValidationStrategy
    {
        public abstract string Validate(string password);
    }

    class MinLengthValidation : PasswordValidationStrategy
    {
        public override string Validate(string password)
        {
            return (password.Length >= 8) ? "" : "Mật khẩu phải trên 8 chữ số \n";
        }
    }

    class UppercaseValidation : PasswordValidationStrategy
    {
        public override string Validate(string password)
        {
            return password.Any(char.IsUpper) ? "" : "Mật khẩu phải có chữ in hoa \n";
        }
    }

    class LowercaseValidation : PasswordValidationStrategy
    {
        public override string Validate(string password)
        {
            return password.Any(char.IsLower) ? "" : "Mật khẩu phải có chữ thường \n";
        }
    }

    class HasNumberValidation : PasswordValidationStrategy
    {
        public override string Validate(string password)
        {
            return password.Any(char.IsDigit) ? "" : "Mật khẩu phải có kí tự số \n";
        }
    }

    class PasswordValidator
    {
        private PasswordValidationStrategy strategy;

        public void setValidationStrategy(PasswordValidationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string ValidatePassword(string password)
        {
            return strategy.Validate(password);
        }
    }
}