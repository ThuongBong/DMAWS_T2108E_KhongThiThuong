namespace DMAWS_T2108E_KhongThiThuong.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDOB { get; set; }   
        public string EmployeeDepartment { get; set; }
        public virtual ICollection<ProjectEmployee> Employees { get; set;}
    }
}
