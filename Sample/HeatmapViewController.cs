using System;
using UIKit;
using Google.Maps;
using Google.Maps.Utility;
using CoreGraphics;
using System.Collections.Generic;
using CoreLocation;
using System.Linq;

namespace Sample
{
    public class HeatmapViewController : MapViewController
    {
        private GMUHeatmapTileLayer _heatmapLayer;

        public HeatmapViewController()
        {
            Title = "Heatmap";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitHeatmap();
            UpdateHeatmap();
        }

        private void InitHeatmap()
        {
            _heatmapLayer = new GMUHeatmapTileLayer();

            _heatmapLayer.MinimumZoomIntensity = 10;
            _heatmapLayer.MaximumZoomIntensity = 20;

            _heatmapLayer.Radius = 60;
            _heatmapLayer.Opacity = 0.5f;
        }

        private void UpdateHeatmap()
        {
            var p = GetRandomLocations(200).Select(r => new GMUWeightedLatLng(r, 1));

            _heatmapLayer.WeightedData = p.ToArray();
            _heatmapLayer.Map = mapView;
        }
    }
}
