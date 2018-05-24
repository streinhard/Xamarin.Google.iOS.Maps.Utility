using System;
using UIKit;
using CoreLocation;
using Google.Maps;
using CoreGraphics;
using System.Collections.Generic;

namespace Sample
{
    public abstract class MapViewController : UIViewController
    {
        private readonly Random _random;

        protected MapView mapView;

        protected double BaseLat = 47.38;
        protected double BaseLong = 8.52;
        protected float BaseZoom = 12;

        public MapViewController()
        {
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            var camera = CameraPosition.FromCamera(BaseLat, BaseLong, BaseZoom);

            mapView = MapView.FromCamera(CGRect.Empty, camera);
            mapView.MapType = MapViewType.Satellite;

            View = mapView;
        }

        protected IList<CLLocationCoordinate2D> GetRandomLocations(int count)
        {
            var cooordinates = new List<CLLocationCoordinate2D>();

            for (var i = 0; i < count; i++)
            {
                var latOffset = (_random.NextDouble() * 2 - 1) / 60;
                var longOffset = (_random.NextDouble() * 2 - 1) / 60;

                var latitude = BaseLat + latOffset;
                var longitude = BaseLong + longOffset;

                cooordinates.Add(new CLLocationCoordinate2D(latitude, longitude));
            }

            return cooordinates;
        }
    }
}
