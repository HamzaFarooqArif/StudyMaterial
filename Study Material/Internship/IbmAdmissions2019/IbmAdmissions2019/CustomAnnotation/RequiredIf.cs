using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.CustomAnnotation
{
    public class RequiredIfAttribute : ConditionalValidationAttribute
    {
        protected override string ValidationName
        {
            get { return "requiredif"; }
        }
        public RequiredIfAttribute(string dependentProperty, object targetValue)
            : base(new RequiredAttribute(), dependentProperty, targetValue)
        {
        }
        protected override IDictionary<string, object> GetExtraValidationParameters()
        {
            return new Dictionary<string, object>
        {
            { "rule", "required" }
        };
        }
    }
}