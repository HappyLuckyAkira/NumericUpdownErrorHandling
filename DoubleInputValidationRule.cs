using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
//以下を参考にさせていただいている
//http://oita.oika.me/2014/12/21/binding-to-validation-rule/

namespace WpfAppErrorHandling
{
    class DoubleInputValidationRule : ValidationRule
    {
        public DependencyDouble MinValue { get; set; }
        public DependencyDouble MaxValue { get; set; }

        public DoubleInputValidationRule()
        {
            //既定値
            MinValue = new DependencyDouble { Value = Double.MinValue };
            MaxValue = new DependencyDouble { Value = Double.MaxValue };
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "値がNullです");

            double inputNum;

            if (!Double.TryParse(value.ToString(), out inputNum))
            {
                return new ValidationResult(false, "値の形式が不正です");
            }

            if (inputNum < MinValue.Value || MaxValue.Value < inputNum)
            {
                return new ValidationResult(false, "値が範囲外です");
            }

            return ValidationResult.ValidResult;
        }
    }
}
