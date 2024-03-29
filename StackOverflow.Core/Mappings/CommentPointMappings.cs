﻿using FluentNHibernate.Mapping;
using StackOverflow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Core.Mappings
{
    class CommentPointMappings : ClassMap<CommentPoint>
    {
        public CommentPointMappings()
        {
            Id(c => c.Id).GeneratedBy.Identity();
            Map(c => c.IsUpvoted);
            References(c => c.ApplicationUser);
            References(c => c.Comment);
        }
    }
}
