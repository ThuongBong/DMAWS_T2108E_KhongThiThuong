using DMAWS_T2108E_KhongThiThuong.DbContextConnection;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2108E_KhongThiThuong.Model.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Tìm kiếm nhân viên theo tên và khoảng thời gian ngày sinh:
        public List<Employee> SearchEmployees(string employeeName, DateTime employeeDOBFromDate, DateTime employeeDOBToDate)
        {
            var employees = _dbContext.Emloyees
                .Where(e => e.EmployeeName.Contains(employeeName) && e.EmployeeDOB >= employeeDOBFromDate && e.EmployeeDOB <= employeeDOBToDate)
                .ToList();

            return employees;
        }

        //Lấy thông tin chi tiết nhân viên và hiển thị danh sách dự án của nhân viên đó:
        public Employee GetEmployeeDetails(int employeeId)
        {
            var employee = _dbContext.Emloyees
                .Include(e => e.ProjectEmployees)
                .ThenInclude(pe => pe.Projects)
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            return employee;
        }
    }
}
