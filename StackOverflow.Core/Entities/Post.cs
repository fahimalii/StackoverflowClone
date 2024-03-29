﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Core.Entities
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual bool HasAcceptedAnswer { get; set; }
        public virtual bool IsDuplicate { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<PostPoint> PostPoints { get; set; }
        public virtual ICollection<Comment> Comments{ get; set; }

    }
}
