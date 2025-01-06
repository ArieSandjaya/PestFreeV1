using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PestFree.Data;
using PestFree.Models;
using System;

namespace PestFree.Controllers
{
  public class CompaniesController : Controller
  {
    private readonly AppDbContextcs _context;
    private readonly IServer _server;

    public CompaniesController(AppDbContextcs context, IServer _svr)
    {
      _context = context;
      _server = _svr;
    }
    // GET: CompaniesController
    public async Task<IActionResult> Index()
    {
      var companyLists = await _context.Companies.ToListAsync();
      return View(companyLists);
    }

    // GET: CompaniesController/Details/5
    public IActionResult Details(int id)
    {
      return View();
    }

    // GET: CompaniesController/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: CompaniesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IFormCollection collection)
    {
      try
      {
        Company _company = new Company();
        {
          Guid _guid = Guid.NewGuid();
          var extType = string.Empty;
          var contenType = String.Empty;
          var filePath = string.Empty;
          var virtualPath = string.Empty;

          if (collection.Files["PathImage"] is not null)
          {
            IFormFile? pathImage = collection.Files["PathImage"];

            if(pathImage is not null)
            {
              contenType = pathImage.ContentType;
              if (contenType == "image/jpeg" || contenType == "image/jpg" || contenType == "image/png")
              {
                extType = pathImage is not null ? pathImage.FileName.Split('.').Last() : string.Empty;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\images\\company", $"{_guid.ToString().Replace("-", "")}.{extType}");
                virtualPath = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/uploads/images/company/{_guid.ToString().Replace("-", "")}.{extType}";
                //_company.PathImage = filePath;
              }
              using (var stream = System.IO.File.Create(filePath))
              {
                await pathImage.CopyToAsync(stream);
              }
            }
          }
          _company.PathImage = virtualPath;
          _company.Name = collection["Name"].ToString();
          _company.Address = collection["Address"].ToString();
          _company.Phone = collection["Phone"].ToString();
          _company.IsActive = Convert.ToBoolean(collection["IsActive"][0]);

        }

        if (ModelState.IsValid)
        {
          _context.Companies.Add(_company);
          await _context.SaveChangesAsync();
        }
          
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CompaniesController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
      var _company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
      return View(_company);
    }

    // POST: CompaniesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, IFormCollection collection)
    {
      try
      {
        Guid _guid = Guid.NewGuid();
        var extType = string.Empty;
        var contenType = String.Empty;
        var filePath = string.Empty;
        var virtualPath = string.Empty;

        var _company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

        if (ModelState.IsValid && _company is not null)
        {
          if (collection.Files["PathImage"] is not null)
          {
            IFormFile? pathImage = collection.Files["PathImage"];

            if (pathImage is not null)
            {
              contenType = pathImage.ContentType;
              if (contenType == "image/jpeg" || contenType == "image/jpg" || contenType == "image/png")
              {
                extType = pathImage is not null ? pathImage.FileName.Split('.').Last() : string.Empty;
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\images\\company", $"{_guid.ToString().Replace("-", "")}.{extType}");
                virtualPath = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}/uploads/images/company/{_guid.ToString().Replace("-", "")}.{extType}";
                _company.PathImage = virtualPath;
              }
              using (var stream = System.IO.File.Create(filePath))
              {
                await pathImage.CopyToAsync(stream);
              }
            }
          }

          _company.Name = collection["Name"].ToString();
          _company.Address = collection["Address"].ToString();
          _company.Phone = collection["Phone"].ToString();
          _company.IsActive = Convert.ToBoolean(collection["IsActive"][0]);

          _context.Update(_company);
          await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: CompaniesController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
      var _company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
      return View(_company);
    }

    // POST: CompaniesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, IFormCollection collection)
    {
      try
      {
        var _company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        _context.Companies.Remove(_company);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
      }
      catch(Exception ex)
      {
        return View(ex.Message);
      }
    }
  }
}
