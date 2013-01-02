using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Areas.Admin.Models;
using ToolDepot.Filters;
using ToolDepot.Helpers;

namespace ToolDepot.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LeftMenu()
        {
            return PartialView();
        }

        public ActionResult UploadPic(UploadImageModel model, string returnAsText = "0")
        {
            //var customer = _workContext.CurrentCustomer;

            if (ModelState.IsValid)
            {
                //Prepare the needed variables
                Bitmap original = null;
                string filename = "";
                string filenameWithExtension = "";

                if (model.File != null)
                {
                    filename = Path.GetFileNameWithoutExtension(model.File.FileName);
                    filenameWithExtension = filename + ".png";
                    original = Bitmap.FromStream(model.File.InputStream) as Bitmap;
                }

                //If we had success so far
                if (original != null)
                {
                    var img = ImageHelper.CreateImage(original, model.X, model.Y, model.Width, model.Height);
                    var relativePath = "/Images/UserImages/";
                    var targetDirectory = Server.MapPath("~" + relativePath);
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    relativePath += "/" + filenameWithExtension;
                    var serverFileFullPath = targetDirectory + "/" + filenameWithExtension;
                    img.Save(serverFileFullPath, System.Drawing.Imaging.ImageFormat.Png);
                    
                    var ret = new {result = "success", src = relativePath};

                    if (returnAsText == "0")
                    {
                        return Json(ret);
                    }

                    // Fix for IE
                    return Json(ret, "text/html");
                }
            }

            var errorRet = new
                               {
                                   result = "error",
                                   msg =
                                       "Problem uploading image. If problem persists please contact program administrator."
                               };

            if (returnAsText == "0")
            {
                return Json(errorRet);
            }
            else
            {
                return Json(errorRet, "text/html");
            }
        }
    }
}
