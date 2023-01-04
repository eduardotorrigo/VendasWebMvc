namespace VendasWebMvc.Services;

public class DepartmentService
{
    private readonly ApplicationDbContext _context;

    public DepartmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Departments.OrderBy(d => d.Name).ToList();
    }
}
