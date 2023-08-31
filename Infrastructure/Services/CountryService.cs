using Dapper;
using Npgsql;
using Domain.Models;
namespace Infrastructure.Services;

public class CountryService
{
    string connectionString = "Server=localhost;Port=5432;Database=Country;User Id=postgres;Password=1983;";

    public string AddCountry(Country country)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            string sql = $"insert into Countries(name, continent, language, population) values('{country.Name}', '{country.Continent}', '{country.Language}', '{country.Population}')";
            var response  = conn.Execute(sql);
            if (response == 1)
            {
                return "Country added!";
            }
            return "Error";
        }
    }
    public List<Country> GetCountries(string name)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select id as Id, name as Name, continent as Continent, language as Language, population as Population from Country";
            if (name != null)
            {
                sql += $"where lower(name) like '%{name.ToLower()}%'";
            }
            var result = conn.Query<Country>(sql);
            return result.ToList();
        }
    }
    public string UpdateCountry(Country country)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"update countries set name = '{country.Name}', continent = '{country.Continent}', language = '{country.Language}', population = {country.Population} where id={country.Id}";
            var res=conn.Execute(sql);
            if(res==0)return "Error";
            return "Succesfuly updated!";
        }
    }
    public string DeleteCountry(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"delete from Country where '{id}' = id";
            var response = conn.Execute(sql);
            if (response == 1)
            {
                return "Deleted succesfully!";
            }
            return "Error";
        }
    }
}
