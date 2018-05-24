using System;
using Google.Maps.Utility;
using Foundation;
namespace Sample
{
    public class GeoJSONViewController : MapViewController
    {
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

            RenderGeoJson();
        }

        private void RenderGeoJson()
        {
            var path = NSBundle.MainBundle.PathForResource("GeoJSON_Sample", "geojson");
            var url = new NSUrl(path, isDir: false);
            var parser = new GeoJSONParser(url);
            parser.Parse();

            var renderer = new GeometryRenderer(mapView, parser.Features);
            renderer.Render();
        }
    }
}
