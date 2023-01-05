using VendasWebMvc.Services.Exceptions;

namespace VendasWebMvc.Services;

public class DepartmentService
{
    private readonly ApplicationDbContext _context;

    public DepartmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> FindAll()
    {
        return await _context.Departments.OrderBy(d => d.Name).ToListAsync();
    }
    public async Task<Department> FindById(int id)
    {
        return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
    }
    public async Task Inserir(Department dept)
    {
        _context.Departments.Add(dept);
        await _context.SaveChangesAsync();
    }
    public async Task Remove(int id)
    {
        var result = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(result);
        await _context.SaveChangesAsync();
    }
    public async Task Update(Department dept)
    {
        if (!await _context.Departments.AnyAsync(d => d.Id == dept.Id))
            throw new NotFoundException("Id não encontrado");
        try
        {
            _context.Departments.Update(dept);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {

            throw new DbConcurrencyException(e.Message);
        }
    }

}
