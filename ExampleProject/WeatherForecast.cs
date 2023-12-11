using System.ComponentModel.DataAnnotations;

namespace ExampleProject
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public static class Examp
    {

        public static void Run()
        {
            Console.WriteLine(GetProject().FirstOrDefault().Name);
        }
        public static ICollection<Project> GetProject()
        {
            return new List<Project>()
     {
         new Project()
         {
             Id = Guid.NewGuid(),
             Name = "Test",
             Description = "Test",
             //UserId = user.Id,
         },

         new Project()
         {
             Id = Guid.NewGuid(),
             Name = "Test2",
             Description = "Test2",
             //UserId = user.Id,
         },
         new Project()
         {
             Id = Guid.NewGuid(),
             Name = "Test3",
             Description = "Test3",

         },

     };

        }
    }

    public class Project
    {

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(800)]
        public string Description { get; set; }

        public Guid? Id { get; set; }


        public virtual ICollection<Task>? Tasks { get; set; }
    }
}