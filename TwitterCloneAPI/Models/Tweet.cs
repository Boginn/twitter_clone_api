using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models
{
    public class Tweet
    {
        public Tweet()
        {

        }

        public int Id { get; set; }


        public string? Hashtag { get; set; }

        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

        [Required]
        public virtual int UserId { get; set; }


        [Required]
        public string Date { get; set; }




        public List<Reply> Replies { get; set; } = new List<Reply>();
        public List<TweetLike> TweetLikes { get; set; } = new List<TweetLike>();

    }
}
