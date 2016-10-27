using System.Configuration;

namespace Shop.Infractructure
{
    public class AppConfig
    {
        private static string productImagesFolder = ConfigurationManager.AppSettings["ProductImages"];

        public static string ProductImagesFolder { get { return productImagesFolder; } }

    }
}