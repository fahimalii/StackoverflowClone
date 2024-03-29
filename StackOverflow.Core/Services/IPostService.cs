﻿using StackOverflow.Core.DTO;
using StackOverflow.Core.Entities;
using System.Collections.Generic;

namespace StackOverflow.Core.Services
{
    public interface IPostService
    {
        IList<PostModelDTO> GetAll(bool includeDeleted = false);
        PostModelDTO GetById(int id);
        Post Get(int id, bool includeDeleted = false);
        void Create(Post post);
        void Update(Post post);
        void Delete(int id);
        (string message, long points) UpvotePost(ApplicationUser user, int postId);
        (string message, long points) DownvotePost(ApplicationUser user, int postId);
        void AcceptAnswer(int postId, int commentId);
        void MarkDuplicate(int postId);
        void HidePost(int postId);
        void RemoveMarkDuplicate(int postId);
        void ShowPost(int postId);
    }
}
