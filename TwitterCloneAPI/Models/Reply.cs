using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models
{
    public class Reply
    {
        public Reply()
        {

        }

        public int Id { get; set; }

        public string Recipient { get; set; }

        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

        [Required]
        public virtual int? UserId { get; set; }

        [Required]
        public virtual int? TweetId { get; set; }

        [Required]
        public string Date { get; set; }



        public List<ReplyLike> ReplyLikes { get; set; } = new List<ReplyLike>();

    }
}
