using System;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using Google.Maps;
using UIKit;

namespace GoogleMapUtility
{

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

    // @protocol GMUCluster <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface GMUCluster
    {
        // @required @property (readonly, nonatomic) CLLocationCoordinate2D position;
        [Abstract]
        [Export("position")]
        CLLocationCoordinate2D Position { get; }

        // @required @property (readonly, nonatomic) NSUInteger count;
        [Abstract]
        [Export("count")]
        nuint Count { get; }

        // @required @property (readonly, nonatomic) NSArray<id<GMUClusterItem>> * _Nonnull items;
        [Abstract]
        [Export("items")]
        GMUClusterItem[] Items { get; }
    }
}