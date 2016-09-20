using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Entities
{
    [Table("BlogTypes")]
    public class BlogType
    {
        [Key]
        public int Id { get; set; }

        public string TypeName { get; set; }
    }
}
