namespace VendasWebMvc.Services;

public class SalesRecordService
{
    private readonly ApplicationDbContext _context;

    public SalesRecordService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SalesRecord>> FindByDate(DateTime? minDate, DateTime? maxDate)
    {
        var result = from obj in _context.SalesRecord select obj;

        if (minDate.HasValue)
        {
            result = result.Where(sr => sr.Date >= minDate);
        }
        if (maxDate.HasValue)
        {
            result = result.Where(sr => sr.Date <= maxDate);
        }
        return await result.Include(sr => sr.Seller).Include(sr => sr.Seller.Department).OrderByDescending(sr => sr.Date).ToListAsync();
    }
    public  async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGrouping(DateTime? minDate, DateTime? maxDate)
    {
        var result = from obj in _context.SalesRecord select obj;
        if (minDate.HasValue)
        {
            result = result.Where(x => x.Date >= minDate.Value);
        }
        if (maxDate.HasValue)
        {
            result = result.Where(x => x.Date <= maxDate.Value);
        }
        return await result
            .Include(x => x.Seller)
            .Include(x => x.Seller.Department)
            .OrderByDescending(x => x.Date)
            .GroupBy(x => x.Seller.Department)
            .ToListAsync();
    }
}
