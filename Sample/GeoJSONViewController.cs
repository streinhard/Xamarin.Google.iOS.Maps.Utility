using System;
using Google.Maps.Utility;
using Foundation;
namespace Sample
{
    public class GeoJSONViewController : MapViewController
    {
        //@37.4220041,-122.0862515,17z

        public GeoJSONViewController()
        {
            Title = "GeoJSON Sample";
            BaseLat = 41.352;
            BaseLong = -96.418;
            BaseZoom = 3;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var path = NSBundle.MainBundle.PathForResource("GeoJSON_Sample", "geojson");
            var url = new NSUrl(path, isDir: false);
            var parser = new GMUGeoJSONParser(url);
            parser.Parse();

            var renderer = new GMUGeometryRenderer(mapView, parser.Features);
            renderer.Render();
        }
    }
}
