using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers;

public class DepartmentsController : Controller
{
    public IActionResult Index()
    {
        List<Department> list = new List<Department>();
        list.Add(new Department { Id = 1, Name = "Eletronicos" });
        list.Add(new Department { Id = 1, Name = "Fashion" });
        return View(list);
    }
    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Delete()
    {
        return View();
    }public IActionResult Details(int? id)
    {
        if (id == null)
            return NotFound();

        return View();
    }
    public IActionResult Edit(int? id)
    {
        if (id == null)
            return NotFound();

        return View();
    }

}
