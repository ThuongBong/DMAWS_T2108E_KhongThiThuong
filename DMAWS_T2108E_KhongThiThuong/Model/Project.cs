using System.ComponentModel.DataAnnotations;

namespace DMAWS_T2108E_KhongThiThuong.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150)]
        public string ProjectName { get; set; }
        [Required]
        public DateTime ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
