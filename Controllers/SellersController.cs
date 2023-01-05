using System.Diagnostics;
using VendasWebMvc.Models.ViewModels;

namespace VendasWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;
    private readonly DepartmentService _departmentService;

    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
        _sellerService = sellerService;
        _departmentService = departmentService;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _sellerService.FindAll();
        return View(list);
    }
    public async Task<IActionResult> Create()
    {
        var department = await _departmentService.FindAll();
        var viewModel = new SellerViewModel { Departments = department };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Seller seller)
    {
        if (!ModelState.IsValid)//Caso o javascript não funcione
        {
            var department = await _departmentService.FindAll();
            var viewModel = new SellerViewModel { Seller = seller, Departments = department };
            return View(viewModel);
        }

        await _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

        var result = await _sellerService.FindById(id.Value);
        if (result == null)
            return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _sellerService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return RedirectToAction(nameof(Error), new { message = "Id não informado" });
        var result = await _sellerService.FindById(id.Value);
        return View(result);
    }
    public async Task<IActionResult> Edit(int? id)
    {
        var result = await _sellerService.FindById(id.Value);
        if (result == null)
            return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

        List<Department> department = await _departmentService.FindAll();
        var viewModel = new SellerViewModel { Seller = result, Departments = department };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, Seller seller)
    {
        if (ModelState.IsValid)//Caso o javascript não funcione
        {
            var department = await _departmentService.FindAll();
            var viewModel = new SellerViewModel { Seller = seller, Departments = department };
            return View(viewModel);
        }

        if (id != seller.Id)
            return RedirectToAction(nameof(Error), new { message = "Id divergente" });

        try
        {
            await _sellerService.Update(seller);
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
