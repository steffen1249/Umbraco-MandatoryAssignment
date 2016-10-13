using MandatoryAssignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;

namespace MandatoryAssignment.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            if (TempData["success"] == null)
            {
                return PartialView("ContactForm", new ContactForm());
            }
            else
            {
                return PartialView("ContactFormSuccess");
            }
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            //CreateAndSendEmail(model);
            CreateAndSaveComment(model);

            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }

        private void CreateAndSaveComment(ContactForm model)
        {
            IContent comment = Services.ContentService.CreateContent(model.Subject, CurrentPage.Id, "Comment");

            comment.SetValue("commentName", model.Name);
            comment.SetValue("commentEmail", model.Email);
            comment.SetValue("commentSubject", model.Subject);
            comment.SetValue("commentMessage", model.Message);

            // Save - I've chosen just to save it and not publish it, because I personally don't see any
            // usecases where you would like to display these information on the site
            Services.ContentService.Save(comment);

            // Save and Publish - To publish them aswell, out comment line below and comment the line above
            //Services.ContentService.SaveAndPublishWithStatus(comment);
        }
    }
}