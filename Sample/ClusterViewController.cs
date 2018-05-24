using System;
using Google.Maps;
using Google.Maps.Utility;

namespace Sample
{
    public class ClusterViewController : MapViewController
    {
        private ClusterManager clusterManager;

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
            var iconGenerator = new DefaultClusterIconGenerator();
            var algorithm = new NonHierarchicalDistanceBasedAlgorithm();
            var renderer = new DefaultClusterRenderer(mapView, iconGenerator);

            clusterManager = new ClusterManager(mapView, algorithm, renderer);
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
