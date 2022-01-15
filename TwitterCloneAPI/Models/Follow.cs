using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Models
{
    public class Follow
    {


        public int Id { get; set; }

        public virtual int? UserId { get; set; }
        public virtual int? FollowerId { get; set; }



    }
}
