using BSIGeneralAffairBLL;
using BSIGeneralAffairBLL.DTO.Proposal;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using MVCBSIGeneralAffairCosmetic.Models;
using System.Diagnostics;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProposalBLL _proposalBLL;

        public HomeController(ILogger<HomeController> logger, IProposalBLL proposalBLL)
        {
            _logger = logger;
            _proposalBLL = proposalBLL;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            List<ProposalDTO> proposals = new List<ProposalDTO>();
            
            DashboardBLL _dashboardBLL = new DashboardBLL();
            var dashboard = _dashboardBLL.GetDashboard();
            ViewBag.DashboardData = dashboard;
            if (Auth.CheckRole("Manager GA,Staff Asset,Staff Procurement", user.UserRole) == true)
            {
                proposals = (List<ProposalDTO>)_proposalBLL.GetWaitingProposal(user.Employee.EmployeeIDNumber);
            }
            return View(proposals);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Default()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
