﻿using StackOverflow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StackOverflow.Web.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index()
        {
            var model = new PostModel();
            model.LoadModelData();

            return View(model.Posts);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePostModel createPostModel)
        {
            if (ModelState.IsValid)
            {
                await createPostModel.AddPost(User.Identity.Name);
                return RedirectToAction("Index");
            }

            return View(createPostModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            var model = new PostDetailsModel();
            model.GetModelById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Upvote(int id)
        {
            var model = new PostVoteModel();
            var data = await model.Upvote(id, User.Identity.Name);
            dynamic returnData = new
            {
                id,
                point = data.Item2
            };
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Downvote(int id)
        {
            var model = new PostVoteModel();
            var data = await model.Downvote(id, User.Identity.Name);
            dynamic returnData = new
            {
                id,
                point = data.Item2
            };
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptAnswer(PostAnswerAcceptModel model)
        {
            model.AcceptAnswer();
            return RedirectToAction("Details", "Post", new { id = model.PostId });
        }
    }
}