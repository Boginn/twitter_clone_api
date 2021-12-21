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
            //Tweets = new List<Tweet> { get; set; };
            //Replies = new List<Reply> { get; set; };
        }

        public int Id { get; set; }

        public int Likes { get; set; }

        public string Date { get; set; }



        public virtual int? UserId { get; set; }
        
        public virtual int? TweetId { get; set; }

        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

    }
}
