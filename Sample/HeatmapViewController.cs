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
        private HeatmapTileLayer _heatmapLayer;

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
            _heatmapLayer = new HeatmapTileLayer
            {
                MinimumZoomIntensity = 10,
                MaximumZoomIntensity = 20,

                Radius = 60,
                Opacity = 0.5f
            };
        }

        private void UpdateHeatmap()
        {
            var p = GetRandomLocations(200).Select(r => new WeightedLatLng(r, 1));

            _heatmapLayer.WeightedData = p.ToArray();
            _heatmapLayer.Map = mapView;
        }
    }
}
