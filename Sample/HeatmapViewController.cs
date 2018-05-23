using System;
using UIKit;
using Google.Maps;
using Google.Maps.Utility;
using CoreGraphics;
using System.Collections.Generic;
using CoreLocation;

namespace Sample
{
    public class HeatmapViewController : UIViewController
    {
        private readonly Random _random;

        private MapView _mapView;
        private GMUHeatmapTileLayer _heatmapLayer;

        private const double BaseLat = 47.38;
        private const double BaseLong = 8.53;

        public HeatmapViewController()
        {
            Title = "Heatmap";
            _random = new Random((int)DateTime.Now.Ticks);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            var camera = CameraPosition.FromCamera(BaseLat, BaseLong, 12);

            _mapView = MapView.FromCamera(CGRect.Empty, camera);
            _mapView.MapType = MapViewType.Satellite;

            View = _mapView;

            AddHeatmap();
            UpdateHeatmap();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        private void AddHeatmap()
        {
            _heatmapLayer = new GMUHeatmapTileLayer();

            _heatmapLayer.MinimumZoomIntensity = 10;
            _heatmapLayer.MaximumZoomIntensity = 20;

            _heatmapLayer.Radius = 60;
            _heatmapLayer.Opacity = 0.5f;
        }

        private void UpdateHeatmap()
        {
            var p = new List<GMUWeightedLatLng>();

            for (var i = 0; i < 100; i++)
            {
                var latOffset = (_random.NextDouble() * 2 - 1) / 60;
                var longOffset = (_random.NextDouble() * 2 - 1) / 60;

                var latitude = BaseLat + latOffset;
                var longitude = BaseLong + longOffset;

                var coord = new CLLocationCoordinate2D(latitude, longitude);

                p.Add(new GMUWeightedLatLng(coord, 1));
            }

            _heatmapLayer.WeightedData = p.ToArray();
            _heatmapLayer.Map = _mapView;
        }
    }
}
