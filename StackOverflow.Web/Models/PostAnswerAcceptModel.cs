﻿using Autofac;
using StackOverflow.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverflow.Web.Models
{
    public class PostAnswerAcceptModel
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;

        public int CommentId { get; set; }
        public int PostId { get; set; }

        public PostAnswerAcceptModel()
        {
            _postService = Startup.AutofacContainer.Resolve<IPostService>();
            _commentService = Startup.AutofacContainer.Resolve<ICommentService>();
        }

        public void AcceptAnswer()
        {
            _postService.AcceptAnswer(PostId, CommentId);
            //var post = _postService.Get(PostId);
            //post.HasAcceptedAnswer = true;
            //_postService.Update(post);
            //var comment = _commentService.Get(CommentId);
            //comment.IsAccepted = true;
            //_commentService.Update(comment);
        }
    }
}