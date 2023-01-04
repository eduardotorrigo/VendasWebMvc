using VendasWebMvc.Services.Exceptions;

namespace VendasWebMvc.Services;

public class SellerService
{
    private readonly ApplicationDbContext _context;
    public SellerService(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Seller> FindAll()
    {
        return _context.Sellers.OrderBy(d => d.Name).ToList();
    }
    public void Insert(Seller obj)
    {
        _context.Sellers.Add(obj);
        _context.SaveChanges();
    }
    public Seller FindById(int id)
    {
        return _context.Sellers.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
    }
    public void Delete(int id)
    {
        var result = _context.Sellers.Find(id);
        _context.Sellers.Remove(result);
        _context.SaveChanges();
    }
    public void Update(Seller seller)
    {
        if (!_context.Sellers.Any(s => s.Id == seller.Id))
            throw new NotFoundException("Id não encontrado");
        try
        {
            _context.Sellers.Update(seller);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {

            throw new DbConcurrencyException(e.Message);
        }

    }
}
