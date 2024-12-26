using AspnetCoreMvcFull.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetCoreMvcFull.Controllers
{
  public class CompanyController : Controller
  {
    // GET: CompanyController
    public ActionResult Index()
    {
      Company _company = new Company();
      _company.Id = 1;
      _company.Name = "PT Test";
      return View(_company);
    }

    // GET: CompanyController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: CompanyController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: CompanyController/Create
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

    // GET: CompanyController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: CompanyController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
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

    // GET: CompanyController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: CompanyController/Delete/5
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