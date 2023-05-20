using Microsoft.AspNetCore.Mvc;

namespace DMAWS_T2108E_KhongThiThuong.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
