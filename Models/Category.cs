using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required(ErrorMessage = " Category is  Required")]
        [MaxLength(150, ErrorMessage = "Name must be less than 150 letters")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 letters")]
        public string CatgName { get; set; }


        public virtual List<Book> Books { get; set; }
    }
}
