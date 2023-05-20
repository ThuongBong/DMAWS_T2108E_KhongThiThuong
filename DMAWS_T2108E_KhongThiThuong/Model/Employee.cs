using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2108E_KhongThiThuong.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(150)]
        public string EmployeeName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [MinimumAge(16)]
        public DateTime EmployeeDOB { get; set; }
        [Required]
        [StringLength(150)]
        public string EmployeeDepartment { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
