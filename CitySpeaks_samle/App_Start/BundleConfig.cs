using System.Web;
using System.Web.Optimization;

namespace CitySpeaks_samle
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            /*bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));    */        

            bundles.Add(new ScriptBundle("~/bundles/main").Include("~/Scripts/jquery.min.js",
                        "~/Scripts/skel.min.js",
                        "~/Scripts/util.js",
                        "~/Scripts/main.js"
                        ));
                
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/main.css",
                      "~/Content/font-awesome.min.css"
                      ));

            bundles.Add(new StyleBundle("~/Content1/carousel").Include(
                      "~/Content/Carousel/animate.css",
                      "~/Content/Carousel/owl.carousel.min.css",
                      "~/Content/Carousel/owl.theme.default.min.css",
                      "~/Content/Carousel/custom.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                        "~/Scripts/owl.carousel.min.js",
                        "~/Scripts/custom.js"
                        ));
        }
    }
}
