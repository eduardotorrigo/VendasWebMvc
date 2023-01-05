using VendasWebMvc.Services.Exceptions;

namespace VendasWebMvc.Services;

public class SellerService
{
    private readonly ApplicationDbContext _context;
    public SellerService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Seller>> FindAll()
    {
        return await _context.Sellers.Include(s => s.Department).OrderBy(d => d.Name).ToListAsync();
    }
    public async Task Insert(Seller obj)
    {
        _context.Sellers.Add(obj);
        await _context.SaveChangesAsync();
    }
    public async Task<Seller> FindById(int id)
    {
        return await _context.Sellers.Include(s => s.Department).FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task Delete(int id)
    {
        var result = _context.Sellers.Find(id);
        _context.Sellers.Remove(result);
        await _context.SaveChangesAsync();
    }
    public async Task Update(Seller seller)
    {
        if (!await _context.Sellers.AnyAsync(s => s.Id == seller.Id))
            throw new NotFoundException("Id não encontrado");
        try
        {
            _context.Sellers.Update(seller);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {

            throw new DbConcurrencyException(e.Message);
        }

    }
}
