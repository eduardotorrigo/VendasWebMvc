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
    [HttpPost]
    public IActionResult Create(Department dept)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(dept);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(dept);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var result = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (result == null)
            return NotFound();

        return View(result);
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        if (id != null)
        {
            var result = _context.Departments.Find(id);
            if (result == null)
                return NotFound();

            try
            {
                _context.Remove(result);
                _context.SaveChanges();


            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public IActionResult Details(int? id)
    {
        if (id == null)
            return NotFound();

        var result = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (result == null)
            return NotFound();

        return View(result);
    }
    public IActionResult Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var result = _context.Departments.FirstOrDefault(d => d.Id == id);
        if (result == null)
            return NotFound();

        return View(result);
    }
    [HttpPost]
    public IActionResult Edit(int? id, Department dept)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(dept);
                _context.SaveChanges();
            }
            catch (System.Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(dept);
    }

}
