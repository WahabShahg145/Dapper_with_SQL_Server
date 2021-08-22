using DapperTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTutorial.Repository
{
    public interface ICompanyRepository
    {
        Company Find(int id);

        List<Company> GetAll();

        Company AddCompany(Company company);

        Company EditCompany(Company company);

        void DeleteCompany(int id);
    }
}
