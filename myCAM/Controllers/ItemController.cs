﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using myCAM.DAL;
using myCAM.Queries;

namespace myCAM.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        // GET: Item/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var surl = await GalleryController.GetSurl();
            var request = new ImageDataRequest(id);
            var rawData = await request.GetItemData(surl);
            var goodData = GoodItemData.CreateFromItemInformation(rawData);
            return View(goodData);
        }

        public ActionResult AddToGallery(int itemId, int galleryId)
        {
            var db = new ApplicationDbContext();
            var gallery = db.Galleries.Find(galleryId);
            var itemCount = gallery.GalleryItems.Count();
            if (itemCount >= 5)
            {
                return this.HttpNotFound();
            }

            gallery.GalleryItems.Add(new GalleryItem { GalleryId = galleryId, ItemId = itemId });
            db.SaveChanges();
            return this.Json(new {success = true});
            return this.RedirectToAction("Index", "Gallery", new {id = galleryId});
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
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

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
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

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }



        // POST: Item/Delete/5
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
