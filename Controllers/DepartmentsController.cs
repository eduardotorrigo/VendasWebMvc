using System.Diagnostics;
using VendasWebMvc.Models.ViewModels;
namespace VendasWebMvc.Controllers;

public class DepartmentsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly DepartmentService _departmentService;

    public DepartmentsController(ApplicationDbContext context, DepartmentService departmentService)
    {
        _context = context;
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _departmentService.FindAll();
        return View(result);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department dept)
    {
        await _departmentService.Inserir(dept);
        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

        var result = await _departmentService.FindById(id.Value);
        if (result == null)
            return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _departmentService.Remove(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });

        var result = await _departmentService.FindById(id.Value);
        if (result == null)
            return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

        return View(result);
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });

        var result = await _departmentService.FindById(id.Value);
        if (result == null)
            return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Department dept)
    {
        if (id != dept.Id)
            return RedirectToAction(nameof(Error), new { message = "Id divergente" });
        try
        {
            await _departmentService.Update(dept);
            return RedirectToAction(nameof(Index));
        }
        catch (ApplicationException e)
        {

            return RedirectToAction(nameof(Error), new { message = e.Message });
        }
    }
    public IActionResult Error(string message)
    {
        var viewModel = new ErrorViewModel
        {
            Message = message,
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
        return View(viewModel);
    }
}
