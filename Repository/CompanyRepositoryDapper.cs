using Dapper;
using DapperTutorial.Data;
using DapperTutorial.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperTutorial.Repository
{
    public class CompanyRepositoryDapper : ICompanyRepository
    {
        private IDbConnection db;
        public CompanyRepositoryDapper(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company AddCompany(Company company)
        {
            var sql = "INSERT INTO Companies (Name, Address, City, State, PostalCode) VALUES(@Name, @Address, @City, @State, @PostalCode);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = db.Query<int>(sql, new { @Name = company.Name, @Address = company.Address, @City = company.City, @State = company.State, @PostalCode = company.PostalCode }).Single();

            company.CompanyId = id;
            return company;
        }

        public void DeleteCompany(int id)
        {
            var sql = "Delete from companies where CompanyId =@Id";
            db.Execute(sql,new { id});

        }

        public Company EditCompany(Company company)
        {
            var sql = "UPDATE Companies SET Name = @Name, Address = @Address, City = @City, State = @State, PostalCode = @PostalCode WHERE CompanyId = @CompanyId";
            db.Execute(sql, company);
            return company;
        }

        public Company Find(int id)
        {
            var sql = "select * from Companies where CompanyId = @CompanyId";
            return db.Query<Company>(sql,new{ @CompanyId = id }).Single();
        }

        public List<Company> GetAll()
        {
            var sql = "select * from Companies";
            return db.Query<Company>(sql).ToList();
        }
    }
}
