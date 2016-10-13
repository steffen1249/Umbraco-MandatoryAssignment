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
    public class MessageBoardFormSurfaceController : SurfaceController
    {
        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("MessageBoardForm", new MessageBoardForm());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(MessageBoardForm model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            // This should never happen, since the method @memberShipHelper.GetCurrentMemberId() would only return -1
            // when the user is not logged in, and there is a restriction on the page so that if you're not logged in
            // you should not be able to see the page, but just to be sure.
            if (model.MemberID == -1)
            {
                ModelState.AddModelError(string.Empty, "It seems like you're not logged in");
                return CurrentUmbracoPage();
            }

            //CreateAndSaveMessage(model);

            TempData["success"] = true;

            // Maybe not the prettiest and smartest way to go to somewhere on the same page, but this is what I could
            // find using google for the amount of time I had
            return Redirect(Url.Action("Index", "MessageBoardFormSurfaceController") + "#messages");
        }

        private void CreateAndSaveMessage(MessageBoardForm model)
        {
            var member = Members.GetById(model.MemberID);

            IContent message = Services.ContentService.CreateContent(member.Name, CurrentPage.Id, "Message");

            message.SetValue("messageMemberID", model.MemberID);
            message.SetValue("messageMessage", model.Message);

            // Save and Publish
            Services.ContentService.SaveAndPublishWithStatus(message);
        }
    }
}