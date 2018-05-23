using System;
using Google.Maps;
using Google.Maps.Utility;

namespace Sample
{
    public class ClusterViewController : MapViewController
    {
        private GMUClusterManager clusterManager;

        public ClusterViewController()
        {
            Title = "Clustering";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitClustering();
            AddClusterItems();
            clusterManager.Cluster();
        }

        private void InitClustering()
        {
            var iconGenerator = new GMUDefaultClusterIconGenerator();
            var algorithm = new GMUNonHierarchicalDistanceBasedAlgorithm();
            var renderer = new GMUDefaultClusterRenderer(mapView, iconGenerator);

            clusterManager = new GMUClusterManager(mapView, algorithm, renderer);
        }

        private void AddClusterItems()
        {
            int i = 0;

            foreach (var p in GetRandomLocations(200))
            {
                var item = new POIItem
                {
                    Location = p,
                    Name = $"Item {i++}"
                };

                clusterManager.AddItem(item);
            }
        }
    }
}
