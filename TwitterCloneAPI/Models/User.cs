using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models
{
    public class User
    {

        public User()
        {
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(18)]
        public string Name { get; set; }
        [Required]
        [MaxLength(18)]
        public string Handle { get; set; }
        public string Color { get; set; }

        public string Password = "a_password_justifies_a_dto";


        public List<Follow> Follows{ get; set; } = new List<Follow>();

        public List<Tweet> Tweets { get; set; } = new List<Tweet>();
        public List<Reply> Replies { get; set; } = new List<Reply>();

        public List<TweetLike> TweetLikes { get; set; } = new List<TweetLike>();
        public List<ReplyLike> ReplyLikes { get; set; } = new List<ReplyLike>();




    }
}
