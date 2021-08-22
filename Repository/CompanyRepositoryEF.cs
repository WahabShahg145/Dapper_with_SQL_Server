using DapperTutorial.Data;
using DapperTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTutorial.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepositoryEF(ApplicationDbContext db)
        {
            _db = db;
        }
        public Company AddCompany(Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return company;
        }

        public void DeleteCompany(int id)
        {
            var Company = _db.Companies.FirstOrDefault(x => x.CompanyId == id);
            _db.Companies.Remove(Company);
            _db.SaveChanges();
            return;
        }

        public Company EditCompany(Company company)
        {
           _db.Companies.Update(company);
            _db.SaveChanges();
            return company;
        }

        public Company Find(int id)
        {
            return _db.Companies.FirstOrDefault(x => x.CompanyId == id);
        }

        public List<Company> GetAll()
        {
            return _db.Companies.ToList();
        }
    }
}
