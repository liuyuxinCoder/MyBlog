using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Model.Entities
{
    [Table("BlogInfos")]
    public class BlogInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [ForeignKey("BlogUser")]
        public int UserId { get; set; }

        public virtual BlogUser BlogUser { get; set; }

        public string Content { get; set; }

        [ForeignKey("BlogType")]
        public int TypeId { get; set; }

        public virtual BlogType BlogType { get; set; }
    }
}
