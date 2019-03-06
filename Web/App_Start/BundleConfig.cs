using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #region Template Design
            bundles.Add(new ScriptBundle("~/template/js").Include(
                       "~/Scripts/jquery-3.3.1.min.js",
                       "~/Scripts/popper.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/stellar.js",
                       "~/Content/vendors/lightbox/simpleLightbox.min.js",
                       "~/Content/vendors/nice-select/js/jquery.nice-select.min.js",
                       "~/Content/vendors/isotope/imagesloaded.pkgd.min.js",
                       "~/Content/vendors/isotope/isotope-min.js",
                       "~/Content/vendors/owl-carousel/owl.carousel.min.js",
                       "~/Scripts/jquery.ajaxchimp.min.js",
                       "~/Content/vendors/flipclock/timer.js",
                       "~/Content/vendors/counter-up/jquery.waypoints.min.js",
                       "~/Content/vendors/counter-up/jquery.counterup.js",
                       "~/Scripts/mail-script.js",
                       "~/Scripts/gmaps.min.js",
                       "~/Scripts/theme.js"
                      ));

            bundles.Add(new StyleBundle("~/template/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/vendors/linericon/style.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/vendors/owl-carousel/owl.carousel.min.css",
                      "~/Content/vendors/lightbox/simpleLightbox.css",
                      "~/Content/vendors/nice-select/css/nice-select.css",
                      "~/Content/vendors/animate-css/animate.css",
                      "~/Content/css/style.css",
                      "~/Content/css/responsive.css"
                     ));

            #endregion
        }
    }
}
