using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2108E_KhongThiThuong.Model
{
    public class ProjectEmployee
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150)]
        public string Tasks { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual Project Projects { get; set; }
    }
}
