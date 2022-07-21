using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2);
            //RuleFor(u => u.Email).Must(EMailControl);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
        }

        //private bool EMailControl(string arg)
        //{
        //    string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
        //    + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
        //    + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
        //    + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
        //    + @"[a-zA-Z]{2,}))$";
        //    Regex reStrict = new Regex(patternStrict);
        //    bool isStrictMatch = reStrict.IsMatch(arg);
        //    return isStrictMatch;
        //}
    }
}
