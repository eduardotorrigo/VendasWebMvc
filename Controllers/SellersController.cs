using VendasWebMvc.Models.ViewModels;
using VendasWebMvc.Services;
using VendasWebMvc.Services.Exceptions;

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

    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }
    public IActionResult Create()
    {
        var department = _departmentService.FindAll();
        var viewModel = new SellerViewModel { Departments = department };
        return View(viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Delete(int? id)
    {
        if (id == null)
            return NotFound();
        var result = _sellerService.FindById(id.Value);
        return View(result);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        _sellerService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Details(int? id)
    {
        if (id == null)
            return NotFound();
        var result = _sellerService.FindById(id.Value);
        return View(result);
    }
    public IActionResult Edit(int? id)
    {
        var result = _sellerService.FindById(id.Value);
        if (result == null)
            return NotFound();

        List<Department> department = _departmentService.FindAll();
        var viewModel = new SellerViewModel { Seller = result, Departments = department };
        return View(viewModel);
    }
    [HttpPost]
    public IActionResult Edit(int id, Seller seller)
    {

        if (id != seller.Id)
            return BadRequest();

        try
        {
            _sellerService.Update(seller);
            return RedirectToAction(nameof(Index));
        }
        catch (NotFoundException)
        {

            return NotFound();
        }
        catch (DbConcurrencyException)
        {
            return BadRequest();
        }

    }

}
