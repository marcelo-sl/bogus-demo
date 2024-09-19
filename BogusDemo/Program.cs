using Bogus;
using BogusDemo;
using System.Text.Json;

var employeeFaker = new Faker<Employee>()
    .StrictMode(true)
    .RuleFor(e => e.Id, f => Guid.NewGuid())
    .RuleFor(e => e.Name, f => f.Name.FullName())
    .RuleFor(e => e.Email, (f, c) => f.Internet.Email(c.Name))
    .RuleFor(e => e.Department, f => f.Commerce.Department());

foreach (var employee in employeeFaker.GenerateForever())
{
    var employeeJson = JsonSerializer.Serialize(employee);
    Console.WriteLine(employeeJson);
    await Task.Delay(1000);
}


