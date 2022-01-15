using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models.DTO
{
    [NotMapped]
    public class UserDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Handle { get; set; }
        public string Color { get; set; }


        public List<Follow> Follows{ get; set; } = new List<Follow>();

        public List<Tweet> Tweets { get; set; } = new List<Tweet>();
        public List<Reply> Replies { get; set; } = new List<Reply>();

        public List<TweetLike> TweetLikes { get; set; } = new List<TweetLike>();
        public List<ReplyLike> ReplyLikes { get; set; } = new List<ReplyLike>();
    }
}
