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
            //Tweets = new List<Tweet> { get; set; };
            //Replies = new List<Reply> { get; set; };
        }

        public int Id { get; set; }


        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

        [Required]
        public virtual int UserId { get; set; }

        public int Likes { get; set; }

        public string Trending { get; set; }

        public string Date { get; set; }






        // public List<User> Users { get; set; } = new List<User>();

        public List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
