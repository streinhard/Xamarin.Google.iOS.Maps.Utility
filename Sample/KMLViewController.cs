using System;
using Foundation;
using Google.Maps.Utility;

namespace Sample
{
    public class KMLViewController : MapViewController
    {
        public KMLViewController()
        {
            Title = "KML Sample";
            BaseLat = 37.422;
            BaseLong = -122.0844666;
            BaseZoom = 17;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var path = NSBundle.MainBundle.PathForResource("KML_Sample", "kml");
            var url = new NSUrl(path, isDir: false);
            var parser = new KMLParser(url);
            parser.Parse();

            var renderer = new GeometryRenderer(mapView, parser.Placemarks, parser.Styles);
            renderer.Render();
        }
    }
}
