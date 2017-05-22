using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorshipExceptions
{
    public class AnimalContext: DbContext
    {
        public AnimalContext() : base("name=AnimalConnection") { }
        public DbSet<Animal> Animals { get; set; }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public AnimalType Type { get; set; }
        public GenderType Gender { get; set; }
    }

    public enum AnimalType { fish, cat, dog, turtle, horse, bird }
    public enum GenderType { Male, Female }
}
