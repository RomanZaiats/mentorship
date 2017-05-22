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
    public class UserNotFoundException : ApplicationException
    {
        private string _userNotFoundName;
        public string UserNotFoundName
        {
            get
            {
                return _userNotFoundName;
            }
            set
            {
                _userNotFoundName = value;
            }
        }

        public UserNotFoundException() { }

        public UserNotFoundException(string message) : base(message) { }

        public UserNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected UserNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    class Program
    {

        static void Main(string[] args)
        {
            AnimalContext db = new AnimalContext();
            db.Animals.Add(new Animal() { Name = "name1", Age = 4, Gender = GenderType.Male, Type = AnimalType.dog, Id = 1 });
            db.SaveChanges();
        }
    }
}
