using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myCAM.DAL;
using myCAM.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace myCAM.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gallery/5
        public ActionResult Index(int id)
        {
            var galleryModel = RetrieveGalleryViewModel(id);
            return View(galleryModel);
        }

        private GalleryViewModel RetrieveGalleryViewModel(int galleryId)
        {
            var context = new ApplicationDbContext();
            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(currentUserId);

            var galleryQuery = context.Galleries.Where(x => x.GalleryId == galleryId).Select(g => new GalleryViewModel
            {
                Title = g.Title,
                Description = g.Description,
                Items = g.GalleryItems.Select(gi => new GalleryItemInfo
                {
                    ItemId = gi.ItemId,
                    Note = gi.Note
                })
            });

            var gallery = galleryQuery.Single();
            return gallery;
            ////var galleries = from user in context.Users
            ////                where user.Id == currentUserId
            ////                let userGalleryModels = from g in user.Galleries
            ////                                        select new 
            ////                select new GalleryViewModel
            ////                {
            ////                    Title = 
            ////                };
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gallery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gallery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gallery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gallery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
