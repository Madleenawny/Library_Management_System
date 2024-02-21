using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required(ErrorMessage = " Title is  Required")]
        [MaxLength(150,ErrorMessage ="title must be less than 150 letter")]
        public string Title { get; set; }

        [Required(ErrorMessage = " Author Name is  Required")]
        [MaxLength(150, ErrorMessage = "Name must be less than 150 letters")]
        [MinLength(3, ErrorMessage = "Name must be more than 3 letters")]
        public string Author { get; set; }
        public string LangOfBook { get; set; }


        [ForeignKey("Category")]
        [Required(ErrorMessage = " Category is  Required")]
        public int CatgID { get; set; }

        public virtual  Category Category { get; set; }

    }
}
