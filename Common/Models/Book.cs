using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    //Models will be the data containers/define the data
    //Models will be used to design the database
    public class Book
    {
        [Key]
        [StringLength(17)]
        public string Isbn { get; set; } // 978-0-12-409341-3

        [Required(AllowEmptyStrings = false, ErrorMessage = "Cannot be left blank")]
        /* You dont need required to set a column as non-nullable but it is used for convenience
         * so that when you look at it you will realise it is not nullable.
         Other advantages with Required are the above that are implemented, such as the ErrorMessage 
        and AllowEmptyStrings as false*/
        public string Title { get; set; }
        public int PublishedYear { get; set; }
        public string? Author { get; set; } // ? = it will be set as nullable in the database
        
        [ForeignKey("Category")]
        //The above line needs "public Category Category{get;set;}"
        //The names need to match 
        public int CategoryFK { get; set; }

        public Category Category { get; set; }
        /* 
         *await _context.Books.Select(b => b.Isbn, b.Title, b.Category.Name); 
         */

        public bool Available { get; set; }
    }
}
