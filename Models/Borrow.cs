using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Models
{
    public class Borrow
    {
        public int ID { get; set; }

        [ForeignKey("Books")]
        [Display(Name = "Title Book")]
        //[Required(ErrorMessage = " Title is  Required")]
        public int BookID { get; set; }

        [ForeignKey("Readers")]
        //[Required(ErrorMessage = " Name is  Required")]
        public int ReaderID { get; set; }

        //[Required(ErrorMessage = " BrwDate is  Required")]
        [DataType(DataType.DateTime)]
        public DateTime BrwDate { get; set; }

        //[Required(ErrorMessage = " Returned Date is  Required")]
        [DataType(DataType.DateTime)]
        public DateTime ReturnedDate { get; set; }

        [Required]
        public int BrwDuration { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime ReturnedIn { get; set; }

        public int NumOfDaysLate { get; set; }

       
        public virtual Book Books { get; set; }        
        public virtual Reader Readers{ get; set; }

    }
}