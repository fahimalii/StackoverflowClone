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
            Id(e => e.Id).GeneratedBy.Identity();
            Map(e => e.IsUpvoted);
            References(x => x.ApplicationUser);
            References(x => x.Comment);
        }
    }
}