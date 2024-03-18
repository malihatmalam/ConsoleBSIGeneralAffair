using BSIGeneralAffairBLL;
using BSIGeneralAffairBLL.DTO.Approval;
using BSIGeneralAffairBLL.DTO.Proposal;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using MVCBSIGeneralAffairCosmetic.Helpers;
using System.Globalization;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IProposalBLL _proposalBLL;
        public ProposalController(IProposalBLL proposalBLL)
        {
            _proposalBLL = proposalBLL;
        }
        // GET: ProposalController
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult HistoryIndex(string typeProposal)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            ViewData["type"] = typeProposal;
            var proposals = _proposalBLL.GetHistoryProposal(typeProposal);
            return View(proposals);
        }

        // GET: ProposalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProposalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Edit/5
        public ActionResult Edit(string proposalToken, string typeProposal)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            var _vendorBLL = new VendorBLL();
            var _approvalBLL = new ApprovalBLL();
            ViewBag.ApprovalData = _approvalBLL.GetHistoryApproval(proposalToken);
            ViewBag.VendorOptions = _vendorBLL.GetAll();
            ViewData["type"] = typeProposal;
            var proposal = _proposalBLL.GetByProposalToken(proposalToken);
            if (proposal == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Proposal tidak ditemukan !</div>";
                return RedirectToAction("HistoryIndex", "Proposal", new { typeProposal = typeProposal });
            }
            return View(proposal);
        }

        // POST: ProposalController/Edit/5
        [HttpPost]
        public ActionResult Update(ProposalDTO proposal)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                ProposalUpdateDTO proposalUpdate = new ProposalUpdateDTO();
                proposalUpdate.ProposalToken = proposal.ProposalToken;
                proposalUpdate.VendorID = proposal.VendorID;
                proposalUpdate.ProposalObjective = proposal.ProposalObjective;
                proposalUpdate.ProposalDescription = proposal.ProposalDescription;
                proposalUpdate.ProposalRequireDate = DateTime.ParseExact(proposal.ProposalRequireDate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture).ToString(); 
                proposalUpdate.ProposalBudget = (int)proposal.ProposalBudget;
                proposalUpdate.ProposalNote = proposal.ProposalNote;
                proposalUpdate.ProposalNegotiationNote = proposal.ProposalNegotiationNote;

                _proposalBLL.Update(proposalUpdate);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data proposal berhasil diperbaharui !</div>";
                var _vendorBLL = new VendorBLL();
                var _approvalBLL = new ApprovalBLL();
                ViewBag.ApprovalData = _approvalBLL.GetHistoryApproval(proposalUpdate.ProposalToken);
                ViewBag.VendorOptions = _vendorBLL.GetAll();
                var proposalData = _proposalBLL.GetByProposalToken(proposalUpdate.ProposalToken);
                if (proposalData == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Proposal tidak ditemukan !</div>";
                }
                ViewData["type"] = proposalData.ProposalType;
                return View("Edit", proposalData);
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult ApprovalProcess(string proposalToken)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            var _vendorBLL = new VendorBLL();
            var _approvalBLL = new ApprovalBLL();
            ViewBag.ApprovalData = _approvalBLL.GetHistoryApproval(proposalToken);
            ViewBag.VendorOptions = _vendorBLL.GetAll();
            
            var proposal = _proposalBLL.GetByProposalToken(proposalToken);
            ViewData["type"] = proposal.ProposalType;
            if (proposal == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Proposal tidak ditemukan !</div>";
                return RedirectToAction("Index", "Home");
            }
            return View(proposal);
        }

        [HttpPost]
        [Route("Proposal/ApprovalUpdate")]
        public ActionResult ApprovalUpdate(ProposalDTO proposal)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                ProposalUpdateDTO proposalUpdate = new ProposalUpdateDTO();
                proposalUpdate.ProposalToken = proposal.ProposalToken;
                proposalUpdate.VendorID = proposal.VendorID;
                proposalUpdate.ProposalObjective = proposal.ProposalObjective;
                proposalUpdate.ProposalDescription = proposal.ProposalDescription;
                proposalUpdate.ProposalRequireDate = DateTime.ParseExact(proposal.ProposalRequireDate, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture).ToString();
                proposalUpdate.ProposalBudget = (int)proposal.ProposalBudget;
                proposalUpdate.ProposalNote = proposal.ProposalNote;
                proposalUpdate.ProposalNegotiationNote = proposal.ProposalNegotiationNote;

                _proposalBLL.Update(proposalUpdate);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data proposal berhasil diperbaharui !</div>";
                var _vendorBLL = new VendorBLL();
                var _approvalBLL = new ApprovalBLL();
                ViewBag.ApprovalData = _approvalBLL.GetHistoryApproval(proposalUpdate.ProposalToken);
                ViewBag.VendorOptions = _vendorBLL.GetAll();
                var proposalData = _proposalBLL.GetByProposalToken(proposalUpdate.ProposalToken);
                if (proposalData == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Proposal tidak ditemukan !</div>";
                }
                ViewData["type"] = proposalData.ProposalType;
                return View("ApprovalProcess", proposalData);
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Route("Proposal/Approval")]
        public ActionResult Approval(string ProposalToken, string ApprovalType, string ApprovalReason, string ProposalType) 
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            try
            {
                ApprovalBLL _approvaBLL = new ApprovalBLL();
                ApprovalDataDTO approvalData = new ApprovalDataDTO();
                approvalData.ProposalToken = ProposalToken;
                approvalData.EmployeeIDNumber = user.Employee.EmployeeIDNumber;
                approvalData.ApprovalType = ApprovalType;
                approvalData.ApprovalReason = ApprovalReason;

                _approvaBLL.ApprovalCMS(approvalData);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Approval telah berhasi ditambahkan !</div>";
                
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return RedirectToAction("ApprovalProcess", "Proposal", new { proposalToken = ProposalToken});
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: ProposalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
