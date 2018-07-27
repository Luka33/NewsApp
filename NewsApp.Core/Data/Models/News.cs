using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsApp.Core.Data.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Name can not be longer then 200 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required", AllowEmptyStrings = false)]
        [StringLength(2000, ErrorMessage = "Description can not be longer then 2000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Category can not be longer then 200 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Author is required", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "Author can not be longer then 200 characters")]
        public string Author { get; set; }

        public DateTime CreatedTimestamp { get; set; }
    }
}
