using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.BusinessLayer.Models.CompanyModels;
using FineEx.BusinessLayer.Models.ItemModels;
using FineEx.BusinessLayer.Models.UserModels;
using FineEx.BusinessLayer.Services.CompanyService;
using FineEx.DataLayer.Context;
using FineEx.Resources.Company;

namespace FineEx.Controllers
{
    public class CompanyController : BaseController
    {
        private CompanyService _companyService = new CompanyService();
        private CompanyControlPanelModel _companyControlPanel;

        [HttpGet]
        [Route("company")]
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View(_companyService.GetCompanies(App.UserId));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Edit(int id)
        {
            SetCompanyInSession(id);
            _companyControlPanel = new CompanyControlPanelModel(id);
            return View(_companyControlPanel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CompanyViewModel model)
        {
            if (_companyService.ValidateInput(model))
            {
                _companyService.UpdateCompany(model);
            }
            return RedirectToAction("Edit", "Company", new { Id = model.Id });
        }

        public PartialViewResult _Edit(CompanyViewModel model)
        {
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var userViewModel = new UserViewModel(App.Db.Users.Single(x => x.Id == id));
            return View(userViewModel);
        }


        public ActionResult EditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateUser();
                return RedirectToAction("Index", "Company");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult CreateUser()
        {
            var userCreateModel = new UserCreateModel {CompanyId = App.CompanyId};
            return View(userCreateModel);
        }

        public ActionResult CreateUser(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreateUser();
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditItem(int id)
        {
            var itemViewModel = new ItemViewModel(App.Db.Items.Single(x => x.Id == id));
            return View(itemViewModel);
        }


        public ActionResult EditItem(ItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UpdateItem();
                return RedirectToAction("Index", "Company");
            }
            return View(model);
        }
    }
}