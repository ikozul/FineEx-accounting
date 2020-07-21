using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FineEx.BusinessLayer.Models.CompanyModels;
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
            return RedirectToAction("Edit", "Company", new { Id = model.Id});
        }

        public PartialViewResult _Edit(CompanyViewModel model)
        {
            return PartialView(model);
        }


    }
}