using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models
{
    public class ReplyLike
    {
        public int Id { get; set; }

        public virtual int? UserId { get; set; }

        public virtual int? ReplyId { get; set; }
 

    }
}
