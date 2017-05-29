using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MentorshipExceptions
{

    [Serializable]
    public class AnimalNotFoundException : ApplicationException
    {
        public int notFoundId { get; set; }

        public AnimalNotFoundException() { }

        public AnimalNotFoundException(string message) : base(message) { }
        public AnimalNotFoundException(string message, int id) : base(message)
        {
            notFoundId = id;
        }

        public AnimalNotFoundException(string message, Exception inner, int id) : base(message, inner) { notFoundId = id; }

        protected AnimalNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    class Program
    {

        static void Main(string[] args)
        {
            AnimalContext db = new AnimalContext();
            db.Animals.Add(new Animal() { Name = "sharik", Age = 4, Gender = GenderType.Male, Type = AnimalType.dog, Id = 1 });
            db.SaveChanges();
            int id = 90;
            var one = db.Animals.Find(id);
            try
            {
                try
                {
                    if (one == null)
                    {
                        throw new AnimalNotFoundException("Animal not found!", new Exception("dsdssd"), id);
                    }
                }
                catch (AnimalNotFoundException ae)
                {
                    throw;
                }
            }
            catch(Exception e)
            {
                Console.Write(e);
            }
        }
    }
}
