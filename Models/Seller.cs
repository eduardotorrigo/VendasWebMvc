using System.ComponentModel.DataAnnotations;

namespace VendasWebMvc.Models;

public class Seller
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 60 caracteres")]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = "E-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "Entre com e-mail válido")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Data de nascimento é obrigatório")]
    [Display(Name = "Nascimento")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Salário base é obrigatório")]
    [Range (100.0, 50000.0, ErrorMessage = "Salário base de ser entre 100,00 e 50.000,00")]
    [Display(Name = "Salário Base")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    public double BaseSalary { get; set; }
    public int DepartmentId { get; set; }

    [Required(ErrorMessage = "Departamento é obrigatório")]
    [Display(Name = "Departamento")]
    public Department Department { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

    public Seller()
    {
    }
    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }
    public void AddSales(SalesRecord sr)
    {
        Sales.Add(sr);
    }
    public void RemoveSales(SalesRecord sr)
    {
        Sales.Remove(sr);
    }
    public double TotalSales(DateTime initial, DateTime final)
    {
        return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
    }
}
