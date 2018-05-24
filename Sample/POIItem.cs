using System;
using CoreLocation;
using Google.Maps.Utility;
namespace Sample
{
    public class POIItem : ClusterItem
    {
        public string Name { get; set; }
        public CLLocationCoordinate2D Location { get; set; }

        public override CLLocationCoordinate2D Position => Location;
    }
}
