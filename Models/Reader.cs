using Final.Models;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Reader
    {
        public int ID { get; set; }

        [Required(ErrorMessage = " Name  Required")]
        [UniqueName]
        public string Name { get; set; }

        [Required(ErrorMessage = " ISBN  Required")]
        public string ISBN { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        //public virtual List<Book> Books { get; set; }
    }
}
