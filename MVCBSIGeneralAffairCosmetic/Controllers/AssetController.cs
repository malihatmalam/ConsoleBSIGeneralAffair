using BSIGeneralAffairBLL;
using BSIGeneralAffairBLL.DTO.Asset;
using BSIGeneralAffairBLL.DTO.User;
using BSIGeneralAffairBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBSIGeneralAffairCosmetic.Helpers;
using System.Text.Json;

namespace MVCBSIGeneralAffairCosmetic.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetBLL _assetBLL;
        private readonly IBrandBLL _brandBLL;
        private readonly ICategoryBLL _categoryBLL;
        public AssetController(IAssetBLL assetBLL, IBrandBLL brandBLL, ICategoryBLL categoryBLL)
        {
            _assetBLL = assetBLL;
            _brandBLL = brandBLL;
            _categoryBLL = categoryBLL;
        }
        // GET: AssetController
        [HttpGet]
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            if (TempData["message"] != null)
            {
                ViewData["message"] = TempData["message"];
            }
            var assets = _assetBLL.GetAll();
            return View(assets);
        }

        // GET: AssetController/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.BrandOptions = _brandBLL.GetAll();
            ViewBag.CategoryOptions = _categoryBLL.GetAll();
            return View();
        }

        // POST: AssetController/Create
        [HttpPost]
        public ActionResult Store(AssetCreateDTO asset)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var _asset = _assetBLL.GetAssetByNumberAsset(asset.AssetNumber);
                if (_asset.AssetNumber != null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Nomor asset yang anda masukan sudah ada !</div>";
                    ViewBag.BrandOptions = _brandBLL.GetAll();
                    ViewBag.CategoryOptions = _categoryBLL.GetAll();
                    return View("Create");
                }
                _assetBLL.Insert(asset);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data asset berhasil ditambahkan !</div>";
                ViewBag.BrandOptions = _brandBLL.GetAll();
                ViewBag.CategoryOptions = _categoryBLL.GetAll();
                //return RedirectToAction("Index", "Asset");
                return RedirectToAction("Edit", "Asset", new { assetNumber = asset.AssetNumber });
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                ViewBag.BrandOptions = _brandBLL.GetAll();
                ViewBag.CategoryOptions = _categoryBLL.GetAll();
                return View("Create");
            }
        }

        [HttpGet]// GET: AssetController/Edit/5
        public ActionResult Edit(string assetNumber)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.BrandOptions = _brandBLL.GetAll();
            ViewBag.CategoryOptions = _categoryBLL.GetAll();
            AssetDTO asset = _assetBLL.GetAssetByNumberAsset(assetNumber);
            ViewBag.asset = asset;
            int assetID = (int)asset.AssetID;
            if (asset.AssetID != null)
            {
                ViewBag.HandsoverData = _assetBLL.GetHandsoverHistoryAsset(assetID);
            }
            var _userBLL = new UserBLL();
            ViewBag.UserOptions = _userBLL.GetAll();
            return View();
        }

        // POST: AssetController/Edit/5
        [HttpPost]
        public ActionResult Update(AssetUpdateDTO asset)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                _assetBLL.Update(asset);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data asset berhasil diperbaharui !</div>";
                ViewBag.BrandOptions = _brandBLL.GetAll();
                ViewBag.CategoryOptions = _categoryBLL.GetAll();
                ViewBag.asset = _assetBLL.GetAssetByNumberAsset(asset.AssetNumber);
                return RedirectToAction("Edit", "Asset", new { assetNumber = asset.AssetNumber });
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                ViewBag.BrandOptions = _brandBLL.GetAll();
                ViewBag.CategoryOptions = _categoryBLL.GetAll();
                ViewBag.asset = _assetBLL.GetAssetByNumberAsset(asset.AssetNumber);
                return RedirectToAction("Edit", "Asset", new { assetNumber = asset.AssetNumber });
            }
        }

        // GET: AssetController/Delete/5
        [HttpGet]
        public ActionResult Delete(string assetNumber)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda harus login terlebih dahulu !</div>";
                return RedirectToAction("Login", "User");
            }
            var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            if (Auth.CheckRole("Manager GA,Staff Asset", user.UserRole) == false)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Anda tidak memiliki hak akses !</div>";
                return RedirectToAction("Index", "Home");
            }
            try
            {
                var model = _assetBLL.GetAssetByNumberAsset(assetNumber);
                if (model == null)
                {
                    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Asset tidak ditemukan !</div>";
                    return RedirectToAction("Index", "Asset");
                }
                _assetBLL.Delete(assetNumber);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data Asset berhasil dihapus !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
                return RedirectToAction("Index", "Asset");
            }
            return RedirectToAction("Index", "Asset");
        }

        [HttpPost]
        [Route("Asset/Handsover")]
        public ActionResult Handsover(int userID, int assetID, string handsoverDate, string assetNumber)
        {
            try
            {
                _assetBLL.HandsoverAsset(userID, assetID, handsoverDate);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Handsover telah berhasi ditambahkan !</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = $"<div class='alert alert-danger'><strong>Error!</strong>{ex.Message}</div>";
            }
            return RedirectToAction("Edit", "Asset", new { assetNumber = assetNumber });
        }
    }
}
