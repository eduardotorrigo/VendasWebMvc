using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Controllers;

public class DepartmentsController : Controller
{
    private readonly ApplicationDbContext _context;

    public DepartmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Departments.ToList());
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
