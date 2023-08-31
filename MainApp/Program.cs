using System.Data;
using Domain.Models;
using Infrastructure.Services;

var countryService = new CountryService();

while (true)
{
    System.Console.WriteLine();
    System.Console.WriteLine("add           add country");
    System.Console.WriteLine("get           get country or countries");
    System.Console.WriteLine("update        update country");
    System.Console.WriteLine("delete        delete country");
    System.Console.WriteLine();

    string command = Console.ReadLine();

    if (command == "add")
    {
        var country = new Country();
        country.Name = Console.ReadLine();
        System.Console.Write("Enter continent: ");
        country.Continent = Console.ReadLine();
        System.Console.Write("Enter language: ");
        country.Language = Console.ReadLine();
        System.Console.Write("Enter population: ");
        country.Population = Convert.ToInt32(Console.ReadLine());
        countryService.AddCountry(country);
    }
    else if (command == "update")
    {
        var country = new Country();
        System.Console.Write("Enter ID: ");
        country.Id =Convert.ToInt32(Console.ReadLine());
        System.Console.Write("Enter name: ");
        country.Name = Console.ReadLine();
        System.Console.Write("Enter continent: ");
        country.Continent = Console.ReadLine();
        System.Console.Write("Enter language: ");
        country.Language = Console.ReadLine();
        System.Console.Write("Enter population: ");
        country.Population = Convert.ToInt32(Console.ReadLine());
        var res=countryService.UpdateCountry(country);
        System.Console.WriteLine(res.ToString());
    }
}
