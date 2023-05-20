using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2108E_KhongThiThuong.Model
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _miniumAge;

        public MinimumAgeAttribute(int miniumAge)
        {
            _miniumAge = miniumAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_miniumAge) < DateTime.Now;
            }
            return false;
        }
    }
}