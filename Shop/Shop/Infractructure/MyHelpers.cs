using System.Data.Entity.Infrastructure.Design;
using System.IO;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using System;
namespace Shop.Infractructure
{
    public static class MyHelpers
    {
        public static string ProductImage(this UrlHelper helper, string image)
        {

            string folder = AppConfig.ProductImagesFolder;
            string path = Path.Combine(folder, image);

            return helper.Content(path);

        }
    }
}