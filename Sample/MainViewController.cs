using System;
using CoreGraphics;
using UIKit;

namespace Sample
{
    public class MainViewController : UIViewController
    {
        public MainViewController()
        {
            Title = "Google Maps Utilities";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null);

            var width = View.Frame.Width;

            var clusterButton = new UIButton(UIButtonType.System);
            clusterButton.SetTitle("Clustering", UIControlState.Normal);
            clusterButton.TouchUpInside += OnShowClustering;
            clusterButton.Frame = new CGRect(0, 100, width, 50);
            View.Add(clusterButton);

            var heatmapButton = new UIButton(UIButtonType.System);
            heatmapButton.SetTitle("Heatmap", UIControlState.Normal);
            heatmapButton.TouchUpInside += OnShowHeatmap;
            heatmapButton.Frame = new CGRect(0, 150, width, 50);
            View.Add(heatmapButton);

            var geoJsonButton = new UIButton(UIButtonType.System);
            geoJsonButton.SetTitle("GeoJSON", UIControlState.Normal);
            geoJsonButton.TouchUpInside += OnShowGeoJson;
            geoJsonButton.Frame = new CGRect(0, 200, width, 50);
            View.Add(geoJsonButton);

            var kmlButton = new UIButton(UIButtonType.System);
            kmlButton.SetTitle("KML", UIControlState.Normal);
            kmlButton.TouchUpInside += OnShowKml;
            kmlButton.Frame = new CGRect(0, 250, width, 50);
            View.Add(kmlButton);


        }

        void OnShowClustering(object sender, EventArgs e)
        {
            var clusterController = new ClusterViewController();
            NavigationController.PushViewController(clusterController, true);
        }


        void OnShowHeatmap(object sender, EventArgs e)
        {
            var heatmapController = new HeatmapViewController();
            NavigationController.PushViewController(heatmapController, true);
        }

        void OnShowGeoJson(object sender, EventArgs e)
        {
            var geoJsonController = new GeoJSONViewController();
            NavigationController.PushViewController(geoJsonController, true);
        }

        private void OnShowKml(object sender, EventArgs e)
        {
            var kmlController = new KMLViewController();
            NavigationController.PushViewController(kmlController, true);
        }
    }
}
