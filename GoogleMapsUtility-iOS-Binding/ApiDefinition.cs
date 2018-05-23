using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Google.Maps.Utility
{
    // @protocol GMUClusterAlgorithm <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IGMUClusterAlgorithm
    {
        // @required -(void)addItems:(NSArray<id> * _Nonnull)items;
        [Abstract]
        [Export("addItems:")]
        void AddItems(NSObject[] items);

        // @required -(void)removeItem:(id _Nonnull)item;
        [Abstract]
        [Export("removeItem:")]
        void RemoveItem(NSObject item);

        // @required -(void)clearItems;
        [Abstract]
        [Export("clearItems")]
        void ClearItems();

        // @required -(NSArray<id> * _Nonnull)clustersAtZoom:(float)zoom;
        [Abstract]
        [Export("clustersAtZoom:")]
        NSObject[] ClustersAtZoom(float zoom);
    }

    // @interface GMUGridBasedClusterAlgorithm : NSObject <GMUClusterAlgorithm>
    [BaseType(typeof(NSObject))]
    interface GMUGridBasedClusterAlgorithm : IGMUClusterAlgorithm
    {
    }

    // @interface GMUNonHierarchicalDistanceBasedAlgorithm : NSObject <GMUClusterAlgorithm>
    [BaseType(typeof(NSObject))]
    interface GMUNonHierarchicalDistanceBasedAlgorithm : IGMUClusterAlgorithm
    {
    }

    // @interface GMUSimpleClusterAlgorithm : NSObject <GMUClusterAlgorithm>
    [BaseType(typeof(NSObject))]
    interface GMUSimpleClusterAlgorithm : IGMUClusterAlgorithm
    {
    }

    // @protocol GMUClusterItem <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMUClusterItem
    {
        // @required @property (readonly, nonatomic) CLLocationCoordinate2D position;
        [Abstract]
        [Export("position")]
        CLLocationCoordinate2D Position { get; }
    }

    // @protocol GMUClusterManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMUClusterManagerDelegate
    {
        // @optional -(BOOL)clusterManager:(GMUClusterManager * _Nonnull)clusterManager didTapCluster:(id _Nonnull)cluster;
        [Export("clusterManager:didTapCluster:")]
        bool DidTapCluster(GMUClusterManager clusterManager, NSObject cluster);

        // @optional -(BOOL)clusterManager:(GMUClusterManager * _Nonnull)clusterManager didTapClusterItem:(id<GMUClusterItem> _Nonnull)clusterItem;
        [Export("clusterManager:didTapClusterItem:")]
        bool DidTapClusterItem(GMUClusterManager clusterManager, GMUClusterItem clusterItem);
    }

    // @interface GMUClusterManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface GMUClusterManager
    {
        // -(instancetype _Nonnull)initWithMap:(id)mapView algorithm:(id<GMUClusterAlgorithm> _Nonnull)algorithm renderer:(id _Nonnull)renderer __attribute__((objc_designated_initializer));
        [Export("initWithMap:algorithm:renderer:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSObject mapView, IGMUClusterAlgorithm algorithm, NSObject renderer);

        // @property (readonly, nonatomic) id<GMUClusterAlgorithm> _Nonnull algorithm;
        [Export("algorithm")]
        IGMUClusterAlgorithm Algorithm { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        GMUClusterManagerDelegate Delegate { get; }

        // @property (readonly, nonatomic, weak) id<GMUClusterManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; }

        [Wrap("WeakMapDelegate")]
        [NullAllowed]
        NSObject MapDelegate { get; }

        // @property (readonly, nonatomic, weak) id _Nullable mapDelegate;
        [NullAllowed, Export("mapDelegate", ArgumentSemantic.Weak)]
        NSObject WeakMapDelegate { get; }

        // -(void)setDelegate:(id<GMUClusterManagerDelegate> _Nullable)delegate mapDelegate:(id _Nullable)mapDelegate;
        [Export("setDelegate:mapDelegate:")]
        void SetDelegate([NullAllowed] GMUClusterManagerDelegate @delegate, [NullAllowed] NSObject mapDelegate);

        // -(void)addItem:(id<GMUClusterItem> _Nonnull)item;
        [Export("addItem:")]
        void AddItem(GMUClusterItem item);

        // -(void)addItems:(NSArray<id<GMUClusterItem>> * _Nonnull)items;
        [Export("addItems:")]
        void AddItems(GMUClusterItem[] items);

        // -(void)removeItem:(id<GMUClusterItem> _Nonnull)item;
        [Export("removeItem:")]
        void RemoveItem(GMUClusterItem item);

        // -(void)clearItems;
        [Export("clearItems")]
        void ClearItems();

        // -(void)cluster;
        [Export("cluster")]
        void Cluster();
    }

    // @interface GMUGradient : NSObject
    [BaseType(typeof(NSObject))]
    interface GMUGradient
    {
        // @property (readonly, nonatomic) NSUInteger mapSize;
        [Export("mapSize")]
        nuint MapSize { get; }

        // @property (readonly, nonatomic) NSArray<UIColor *> * _Nonnull colors;
        [Export("colors")]
        UIColor[] Colors { get; }

        // @property (readonly, nonatomic) NSArray<NSNumber *> * _Nonnull startPoints;
        [Export("startPoints")]
        NSNumber[] StartPoints { get; }

        // -(instancetype _Nonnull)initWithColors:(NSArray<UIColor *> * _Nonnull)colors startPoints:(NSArray<NSNumber *> * _Nonnull)startPoints colorMapSize:(NSUInteger)mapSize;
        [Export("initWithColors:startPoints:colorMapSize:")]
        IntPtr Constructor(UIColor[] colors, NSNumber[] startPoints, nuint mapSize);

        // -(NSArray<UIColor *> * _Nonnull)generateColorMap;
        [Export("generateColorMap")]
        UIColor[] GenerateColorMap { get; }
    }

    // @interface GMUWeightedLatLng : NSObject
    [BaseType(typeof(NSObject))]
    interface GMUWeightedLatLng
    {
        // @property (readonly, nonatomic) float intensity;
        [Export("intensity")]
        float Intensity { get; }

        // -(instancetype _Nonnull)initWithCoordinate:(CLLocationCoordinate2D)coordinate intensity:(float)intensity;
        [Export("initWithCoordinate:intensity:")]
        IntPtr Constructor(CLLocationCoordinate2D coordinate, float intensity);
    }

    // @interface GMUHeatmapTileLayer
    [BaseType(typeof(SyncTileLayer))]
    interface GMUHeatmapTileLayer
    {
        // @property (copy, nonatomic) NSArray<GMUWeightedLatLng *> * _Nonnull weightedData;
        [Export("weightedData", ArgumentSemantic.Copy)]
        GMUWeightedLatLng[] WeightedData { get; set; }

        // @property (nonatomic) NSUInteger radius;
        [Export("radius")]
        nuint Radius { get; set; }

        // @property (nonatomic) GMUGradient * _Nonnull gradient;
        [Export("gradient", ArgumentSemantic.Assign)]
        GMUGradient Gradient { get; set; }

        // @property (nonatomic) NSUInteger minimumZoomIntensity;
        [Export("minimumZoomIntensity")]
        nuint MinimumZoomIntensity { get; set; }

        // @property (nonatomic) NSUInteger maximumZoomIntensity;
        [Export("maximumZoomIntensity")]
        nuint MaximumZoomIntensity { get; set; }
    }
}