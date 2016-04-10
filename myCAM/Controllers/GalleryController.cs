using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using myCAM.DAL;
using myCAM.Models;
using myCAM.Queries;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace myCAM.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ////public ActionResult Index()
        ////{
        ////    return View();
        ////}

        // GET: Gallery/5
        public async Task<ActionResult> Index(int id)
        {
            var galleryModel = await RetrieveGalleryViewModel(id);
            return View(galleryModel);
        }

        public async Task<ActionResult> My()
        {
            IEnumerable<GalleryViewModel> myGalleries = await GetMyGalleries();
            return View(myGalleries);
        }

        public async Task<PartialViewResult> AddToGalleryDialog()
        {
            var myGalleries = await GetMyGalleries(true);
            return PartialView(myGalleries);
        }

        private async Task<IEnumerable<GalleryViewModel>> GetMyGalleries(bool skipItemData = false)
        {
            var currentUserId = User.Identity.GetUserId();
            ////var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            ////var currentUser = manager.FindById(currentUserId);

            var context = new ApplicationDbContext();
            var galleriesQuery = from g in context.Galleries
                                 where g.ApplicationUserId == currentUserId
                                 select new GalleryViewModel
                                 {
                                     GalleryId = g.GalleryId,
                                     Title = g.Title,
                                     Description = g.Description,
                                     Items = g.GalleryItems.Select(gi => new GalleryItemInfo
                                     {
                                         ItemId = gi.ItemId,
                                         Note = gi.Note
                                     })
                                 };
            var galleries = await galleriesQuery.ToListAsync();
            if (skipItemData)
            {
                return galleries;
            }

            var surl = await GetSurl();
            foreach (var galleryViewModel in galleries)
            {
                await GetItemDataForGallery(galleryViewModel, surl);
            }
            return galleries;
        }

        private async Task<GalleryViewModel> RetrieveGalleryViewModel(int galleryId)
        {
            var context = new ApplicationDbContext();
            var currentUserId = User.Identity.GetUserId();

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
            var surl = await GetSurl();
            await GetItemDataForGallery(gallery, surl);

            return gallery;
        }

        private static async Task GetItemDataForGallery(GalleryViewModel gallery, string surl)
        {
            foreach (var galleryItemInfo in gallery.Items)
            {
                galleryItemInfo.GoodItemData = await GetItemData(surl, galleryItemInfo.ItemId);
            }
        }

        private static async Task<GoodItemData> GetItemData(string surl, int itemId)
        {
            var request = new ImageDataRequest(itemId);
            var rawData = await request.GetItemData(surl);
            var goodData = GoodItemData.CreateFromItemInformation(rawData);
            return goodData;
            ////galleryItemInfo.Name = goodData.Name;
            ////galleryItemInfo.Artist = goodData.Artist;
            ////galleryItemInfo.ImageUrl = goodData.ImageUrl;
        }

        public static Task<string> GetSurl()
        {
            return SurlRequest.GetSurl(ConfigurationManager.AppSettings["CamApiUserName"],
                ConfigurationManager.AppSettings["CamApiPassword"]);
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
