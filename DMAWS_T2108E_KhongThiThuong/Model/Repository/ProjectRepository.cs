using DMAWS_T2108E_KhongThiThuong.DbContextConnection;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2108E_KhongThiThuong.Model.Repository
{
    public class ProjectRepository
    {
            private readonly ApplicationDbContext _dbContext;

            public ProjectRepository(ApplicationDbContext dbContext)
            {
                _dbContext = dbContext;
            }

        //Tìm kiếm dự án theo tên dự án và trạng thái (đang trong tiến trình hoặc đã hoàn thành)
             public List<Project> SearchProjects(string projectName, bool inProgress)
            {
                var now = DateTime.Now;

                var projects = _dbContext.Projects
                    .Where(p => p.ProjectName.Contains(projectName) &&
                        (inProgress ? (p.ProjectEndDate == null || p.ProjectEndDate >= now) : (p.ProjectEndDate != null && p.ProjectEndDate < now)))
                    .ToList();

                return projects;
            }

        //Lấy thông tin chi tiết dự án và hiển thị danh sách nhân viên trong dự án đó
             public Project GetProjectDetails(int projectId)
             {
                var project = _dbContext.Projects
                    .Include(p => p.ProjectEmployees)
                    .ThenInclude(pe => pe.Employees)
                    .FirstOrDefault(p => p.ProjectId == projectId);

                return project;
              }
    }
}
