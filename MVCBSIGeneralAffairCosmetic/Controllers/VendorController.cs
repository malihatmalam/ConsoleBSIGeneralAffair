using BSIGeneralAffairBLL.DTO.Brand;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.DTO.Vendor;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendorBLL _vendorBLL;
        public VendorController(IVendorBLL vendorBLL)
        {
            _vendorBLL = vendorBLL;
        }


        [HttpGet]// GET: VendorController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            if (TempData["message"] != null)
            {
                ViewData["message"] = TempData["message"];
            }
            var vendors = _vendorBLL.GetAll();
            return View(vendors);
        }

        // GET: VendorController/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: VendorController/Create
        [HttpPost]
        public ActionResult Create(VendorCreateDTO vendor)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var _vendor = _vendorBLL.GetByName(vendor.VendorName);
                if (_vendor.ToList().Count() > 0)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Vendor yang anda masukan sudah ada !</div>";
                    return View();
                }
                _vendorBLL.Insert(vendor);
                return RedirectToAction("Index", "Vendor");
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            var vendor = _vendorBLL.GetByVendorID(id);
            if (vendor == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Vendor tidak ditemukan !</div>";
                return RedirectToAction("Index", "Vendor");
            }
            var model = new VendorUpdateDTO
            {
                VendorID = id,
                VendorName = vendor.VendorName,
                VendorAddress = vendor.VendorAddress
            };
            return View(model);
        }

        // POST: VendorController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VendorUpdateDTO vendor)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                _vendorBLL.Update(vendor);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Vendor berhasil update !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Vendor");
        }

        // GET: VendorController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Procurement", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var model = _vendorBLL.GetByVendorID(id);
                if (model == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Vendor tidak ditemukan !</div>";
                    return RedirectToAction("Index", "Vendor");
                }
                _vendorBLL.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Vendor berhasil dihapus !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return View();
            }
            return RedirectToAction("Index", "Vendor");
        }
    }
}
