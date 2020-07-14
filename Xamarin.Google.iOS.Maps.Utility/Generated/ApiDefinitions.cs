using System;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

// @protocol GMUClusterItem <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUClusterItem
{
	// @required @property (readonly, nonatomic) CLLocationCoordinate2D position;
	[Abstract]
	[Export ("position")]
	CLLocationCoordinate2D Position { get; }
}

// @protocol GMUCluster <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUCluster
{
	// @required @property (readonly, nonatomic) CLLocationCoordinate2D position;
	[Abstract]
	[Export ("position")]
	CLLocationCoordinate2D Position { get; }

	// @required @property (readonly, nonatomic) NSUInteger count;
	[Abstract]
	[Export ("count")]
	nuint Count { get; }

	// @required @property (readonly, nonatomic) NSArray<id<GMUClusterItem>> * _Nonnull items;
	[Abstract]
	[Export ("items")]
	GMUClusterItem[] Items { get; }
}

// @protocol GMUClusterManagerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUClusterManagerDelegate
{
	// @optional -(BOOL)clusterManager:(GMUClusterManager * _Nonnull)clusterManager didTapCluster:(id<GMUCluster> _Nonnull)cluster;
	[Export ("clusterManager:didTapCluster:")]
	bool DidTapCluster (GMUClusterManager clusterManager, GMUCluster cluster);

	// @optional -(BOOL)clusterManager:(GMUClusterManager * _Nonnull)clusterManager didTapClusterItem:(id<GMUClusterItem> _Nonnull)clusterItem;
	[Export ("clusterManager:didTapClusterItem:")]
	bool DidTapClusterItem (GMUClusterManager clusterManager, GMUClusterItem clusterItem);
}

// @interface GMUClusterManager : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface GMUClusterManager
{
	// -(instancetype _Nonnull)initWithMap:(id)mapView algorithm:(id _Nonnull)algorithm renderer:(id _Nonnull)renderer __attribute__((objc_designated_initializer));
	[Export ("initWithMap:algorithm:renderer:")]
	[DesignatedInitializer]
	IntPtr Constructor (NSObject mapView, NSObject algorithm, NSObject renderer);

	// @property (readonly, nonatomic) id _Nonnull algorithm;
	[Export ("algorithm")]
	NSObject Algorithm { get; }

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	GMUClusterManagerDelegate Delegate { get; }

	// @property (readonly, nonatomic, weak) id<GMUClusterManagerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; }

	[Wrap ("WeakMapDelegate")]
	[NullAllowed]
	NSObject MapDelegate { get; }

	// @property (readonly, nonatomic, weak) id _Nullable mapDelegate;
	[NullAllowed, Export ("mapDelegate", ArgumentSemantic.Weak)]
	NSObject WeakMapDelegate { get; }

	// -(void)setDelegate:(id<GMUClusterManagerDelegate> _Nullable)delegate mapDelegate:(id _Nullable)mapDelegate;
	[Export ("setDelegate:mapDelegate:")]
	void SetDelegate ([NullAllowed] GMUClusterManagerDelegate @delegate, [NullAllowed] NSObject mapDelegate);

	// -(void)addItem:(id<GMUClusterItem> _Nonnull)item;
	[Export ("addItem:")]
	void AddItem (GMUClusterItem item);

	// -(void)addItems:(NSArray<id<GMUClusterItem>> * _Nonnull)items;
	[Export ("addItems:")]
	void AddItems (GMUClusterItem[] items);

	// -(void)removeItem:(id<GMUClusterItem> _Nonnull)item;
	[Export ("removeItem:")]
	void RemoveItem (GMUClusterItem item);

	// -(void)clearItems;
	[Export ("clearItems")]
	void ClearItems ();

	// -(void)cluster;
	[Export ("cluster")]
	void Cluster ();
}

// @protocol GMUClusterAlgorithm <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUClusterAlgorithm
{
	// @required -(void)addItems:(NSArray<id<GMUClusterItem>> * _Nonnull)items;
	[Abstract]
	[Export ("addItems:")]
	void AddItems (GMUClusterItem[] items);

	// @required -(void)removeItem:(id<GMUClusterItem> _Nonnull)item;
	[Abstract]
	[Export ("removeItem:")]
	void RemoveItem (GMUClusterItem item);

	// @required -(void)clearItems;
	[Abstract]
	[Export ("clearItems")]
	void ClearItems ();

	// @required -(NSArray<id<GMUCluster>> * _Nonnull)clustersAtZoom:(float)zoom;
	[Abstract]
	[Export ("clustersAtZoom:")]
	GMUCluster[] ClustersAtZoom (float zoom);
}

// @interface GMUGridBasedClusterAlgorithm : NSObject <GMUClusterAlgorithm>
[BaseType (typeof(NSObject))]
interface GMUGridBasedClusterAlgorithm : IGMUClusterAlgorithm
{
}

// @interface GMUNonHierarchicalDistanceBasedAlgorithm : NSObject <GMUClusterAlgorithm>
[BaseType (typeof(NSObject))]
interface GMUNonHierarchicalDistanceBasedAlgorithm : IGMUClusterAlgorithm
{
}

// @interface GMUSimpleClusterAlgorithm : NSObject <GMUClusterAlgorithm>
[BaseType (typeof(NSObject))]
interface GMUSimpleClusterAlgorithm : IGMUClusterAlgorithm
{
}

// @protocol GMUClusterIconGenerator <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUClusterIconGenerator
{
	// @required -(UIImage *)iconForSize:(NSUInteger)size;
	[Abstract]
	[Export ("iconForSize:")]
	UIImage IconForSize (nuint size);
}

// @interface GMUDefaultClusterIconGenerator : NSObject <GMUClusterIconGenerator>
[BaseType (typeof(NSObject))]
interface GMUDefaultClusterIconGenerator : IGMUClusterIconGenerator
{
	// -(instancetype _Nonnull)initWithBuckets:(NSArray<NSNumber *> * _Nonnull)buckets;
	[Export ("initWithBuckets:")]
	IntPtr Constructor (NSNumber[] buckets);

	// -(instancetype _Nonnull)initWithBuckets:(NSArray<NSNumber *> * _Nonnull)buckets backgroundImages:(NSArray<UIImage *> * _Nonnull)backgroundImages;
	[Export ("initWithBuckets:backgroundImages:")]
	IntPtr Constructor (NSNumber[] buckets, UIImage[] backgroundImages);

	// -(instancetype _Nonnull)initWithBuckets:(NSArray<NSNumber *> * _Nonnull)buckets backgroundColors:(NSArray<UIColor *> * _Nonnull)backgroundColors;
	[Export ("initWithBuckets:backgroundColors:")]
	IntPtr Constructor (NSNumber[] buckets, UIColor[] backgroundColors);

	// -(UIImage * _Nonnull)iconForSize:(NSUInteger)size;
	[Export ("iconForSize:")]
	UIImage IconForSize (nuint size);
}

// @protocol GMUClusterRenderer <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUClusterRenderer
{
	// @required -(void)renderClusters:(NSArray<id<GMUCluster>> * _Nonnull)clusters;
	[Abstract]
	[Export ("renderClusters:")]
	void RenderClusters (GMUCluster[] clusters);

	// @required -(void)update;
	[Abstract]
	[Export ("update")]
	void Update ();
}

// @protocol GMUClusterRendererDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUClusterRendererDelegate
{
	// @optional -(GMSMarker * _Nullable)renderer:(id<GMUClusterRenderer> _Nonnull)renderer markerForObject:(id _Nonnull)object;
	[Export ("renderer:markerForObject:")]
	[return: NullAllowed]
	GMSMarker Renderer (GMUClusterRenderer renderer, NSObject @object);

	// @optional -(void)renderer:(id<GMUClusterRenderer> _Nonnull)renderer willRenderMarker:(GMSMarker * _Nonnull)marker;
	[Export ("renderer:willRenderMarker:")]
	void Renderer (GMUClusterRenderer renderer, GMSMarker marker);

	// @optional -(void)renderer:(id<GMUClusterRenderer> _Nonnull)renderer didRenderMarker:(GMSMarker * _Nonnull)marker;
	[Export ("renderer:didRenderMarker:")]
	void Renderer (GMUClusterRenderer renderer, GMSMarker marker);
}

// @interface GMUDefaultClusterRenderer : NSObject <GMUClusterRenderer>
[BaseType (typeof(NSObject))]
interface GMUDefaultClusterRenderer : IGMUClusterRenderer
{
	// @property (nonatomic) BOOL animatesClusters;
	[Export ("animatesClusters")]
	bool AnimatesClusters { get; set; }

	// @property (nonatomic) int zIndex;
	[Export ("zIndex")]
	int ZIndex { get; set; }

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	GMUClusterRendererDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<GMUClusterRendererDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(instancetype _Nonnull)initWithMapView:(GMSMapView * _Nonnull)mapView clusterIconGenerator:(id<GMUClusterIconGenerator> _Nonnull)iconGenerator;
	[Export ("initWithMapView:clusterIconGenerator:")]
	IntPtr Constructor (GMSMapView mapView, GMUClusterIconGenerator iconGenerator);

	// -(BOOL)shouldRenderAsCluster:(id<GMUCluster> _Nonnull)cluster atZoom:(float)zoom;
	[Export ("shouldRenderAsCluster:atZoom:")]
	bool ShouldRenderAsCluster (GMUCluster cluster, float zoom);
}

// @interface GMUGradient : NSObject
[BaseType (typeof(NSObject))]
interface GMUGradient
{
	// @property (readonly, nonatomic) NSUInteger mapSize;
	[Export ("mapSize")]
	nuint MapSize { get; }

	// @property (readonly, nonatomic) NSArray<UIColor *> * _Nonnull colors;
	[Export ("colors")]
	UIColor[] Colors { get; }

	// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nonnull startPoints;
	[Export ("startPoints")]
	NSNumber[] StartPoints { get; }

	// -(instancetype _Nonnull)initWithColors:(NSArray<UIColor *> * _Nonnull)colors startPoints:(NSArray<NSNumber *> * _Nonnull)startPoints colorMapSize:(NSUInteger)mapSize;
	[Export ("initWithColors:startPoints:colorMapSize:")]
	IntPtr Constructor (UIColor[] colors, NSNumber[] startPoints, nuint mapSize);

	// -(NSArray<UIColor *> * _Nonnull)generateColorMap;
	[Export ("generateColorMap")]
	[Verify (MethodToProperty)]
	UIColor[] GenerateColorMap { get; }
}

// @interface GMUWeightedLatLng : NSObject
[BaseType (typeof(NSObject))]
interface GMUWeightedLatLng
{
	// @property (readonly, nonatomic) float intensity;
	[Export ("intensity")]
	float Intensity { get; }

	// -(instancetype _Nonnull)initWithCoordinate:(CLLocationCoordinate2D)coordinate intensity:(float)intensity;
	[Export ("initWithCoordinate:intensity:")]
	IntPtr Constructor (CLLocationCoordinate2D coordinate, float intensity);
}

// @interface GMUHeatmapTileLayer
interface GMUHeatmapTileLayer
{
	// @property (copy, nonatomic) NSArray<GMUWeightedLatLng *> * _Nonnull weightedData;
	[Export ("weightedData", ArgumentSemantic.Copy)]
	GMUWeightedLatLng[] WeightedData { get; set; }

	// @property (nonatomic) NSUInteger radius;
	[Export ("radius")]
	nuint Radius { get; set; }

	// @property (nonatomic) GMUGradient * _Nonnull gradient;
	[Export ("gradient", ArgumentSemantic.Assign)]
	GMUGradient Gradient { get; set; }

	// @property (nonatomic) NSUInteger minimumZoomIntensity;
	[Export ("minimumZoomIntensity")]
	nuint MinimumZoomIntensity { get; set; }

	// @property (nonatomic) NSUInteger maximumZoomIntensity;
	[Export ("maximumZoomIntensity")]
	nuint MaximumZoomIntensity { get; set; }
}

// @interface GMUGeoJSONParser : NSObject
[BaseType (typeof(NSObject))]
interface GMUGeoJSONParser
{
	// @property (readonly, nonatomic) NSArray<id<GMUGeometryContainer>> * _Nonnull features;
	[Export ("features")]
	GMUGeometryContainer[] Features { get; }

	// -(instancetype _Nonnull)initWithURL:(NSURL * _Nonnull)url;
	[Export ("initWithURL:")]
	IntPtr Constructor (NSUrl url);

	// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
	[Export ("initWithData:")]
	IntPtr Constructor (NSData data);

	// -(instancetype _Nonnull)initWithStream:(NSInputStream * _Nonnull)stream;
	[Export ("initWithStream:")]
	IntPtr Constructor (NSInputStream stream);

	// -(void)parse;
	[Export ("parse")]
	void Parse ();
}

// @interface GMUKMLParser : NSObject
[BaseType (typeof(NSObject))]
interface GMUKMLParser
{
	// @property (readonly, nonatomic) NSArray<id<GMUGeometryContainer>> * _Nonnull placemarks;
	[Export ("placemarks")]
	GMUGeometryContainer[] Placemarks { get; }

	// @property (readonly, nonatomic) NSArray<GMUStyle *> * _Nonnull styles;
	[Export ("styles")]
	GMUStyle[] Styles { get; }

	// -(void)parse;
	[Export ("parse")]
	void Parse ();

	// -(instancetype _Nonnull)initWithURL:(NSURL * _Nonnull)url;
	[Export ("initWithURL:")]
	IntPtr Constructor (NSUrl url);

	// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
	[Export ("initWithData:")]
	IntPtr Constructor (NSData data);

	// -(instancetype _Nonnull)initWithStream:(NSInputStream * _Nonnull)stream;
	[Export ("initWithStream:")]
	IntPtr Constructor (NSInputStream stream);
}

// @interface GMUGeometryRenderer : NSObject
[BaseType (typeof(NSObject))]
interface GMUGeometryRenderer
{
	// -(instancetype _Nonnull)initWithMap:(GMSMapView * _Nonnull)map geometries:(NSArray<id<GMUGeometryContainer>> * _Nonnull)geometries;
	[Export ("initWithMap:geometries:")]
	IntPtr Constructor (GMSMapView map, GMUGeometryContainer[] geometries);

	// -(instancetype _Nonnull)initWithMap:(GMSMapView * _Nonnull)map geometries:(NSArray<id<GMUGeometryContainer>> * _Nonnull)geometries styles:(NSArray<GMUStyle *> * _Nullable)styles;
	[Export ("initWithMap:geometries:styles:")]
	IntPtr Constructor (GMSMapView map, GMUGeometryContainer[] geometries, [NullAllowed] GMUStyle[] styles);

	// -(void)render;
	[Export ("render")]
	void Render ();

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
}

// @protocol GMUGeometry <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUGeometry
{
	// @required @property (readonly, nonatomic) NSString * _Nonnull type;
	[Abstract]
	[Export ("type")]
	string Type { get; }
	
	// @required @property (readonly, nonatomic) NSString * _Nonnull type;
	[Abstract]
	[Export ("coordinates")]
	GMUCoordinates[] Coordinates { get; }
}

// @interface GMUStyle : NSObject
[BaseType (typeof(NSObject))]
interface GMUStyle
{
	// @property (readonly, nonatomic) NSString * _Nonnull styleID;
	[Export ("styleID")]
	string StyleID { get; }

	// @property (readonly, nonatomic) UIColor * _Nullable strokeColor;
	[NullAllowed, Export ("strokeColor")]
	UIColor StrokeColor { get; }

	// @property (readonly, nonatomic) UIColor * _Nullable fillColor;
	[NullAllowed, Export ("fillColor")]
	UIColor FillColor { get; }

	// @property (readonly, nonatomic) CGFloat width;
	[Export ("width")]
	nfloat Width { get; }

	// @property (readonly, nonatomic) CGFloat scale;
	[Export ("scale")]
	nfloat Scale { get; }

	// @property (readonly, nonatomic) CGFloat heading;
	[Export ("heading")]
	nfloat Heading { get; }

	// @property (readonly, nonatomic) CGPoint anchor;
	[Export ("anchor")]
	CGPoint Anchor { get; }

	// @property (readonly, nonatomic) NSString * _Nullable iconUrl;
	[NullAllowed, Export ("iconUrl")]
	string IconUrl { get; }

	// @property (readonly, nonatomic) NSString * _Nullable title;
	[NullAllowed, Export ("title")]
	string Title { get; }

	// @property (readonly, nonatomic) BOOL hasFill;
	[Export ("hasFill")]
	bool HasFill { get; }

	// @property (readonly, nonatomic) BOOL hasStroke;
	[Export ("hasStroke")]
	bool HasStroke { get; }

	// -(instancetype _Nonnull)initWithStyleID:(NSString * _Nonnull)styleID strokeColor:(UIColor * _Nullable)strokeColor fillColor:(UIColor * _Nullable)fillColor width:(CGFloat)width scale:(CGFloat)scale heading:(CGFloat)heading anchor:(CGPoint)anchor iconUrl:(NSString * _Nullable)iconUrl title:(NSString * _Nullable)title hasFill:(BOOL)hasFill hasStroke:(BOOL)hasStroke;
	[Export ("initWithStyleID:strokeColor:fillColor:width:scale:heading:anchor:iconUrl:title:hasFill:hasStroke:")]
	IntPtr Constructor (string styleID, [NullAllowed] UIColor strokeColor, [NullAllowed] UIColor fillColor, nfloat width, nfloat scale, nfloat heading, CGPoint anchor, [NullAllowed] string iconUrl, [NullAllowed] string title, bool hasFill, bool hasStroke);
}

// @protocol GMUGeometryContainer <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUGeometryContainer
{
	// @required @property (readonly, nonatomic) id<GMUGeometry> _Nonnull geometry;
	[Abstract]
	[Export ("geometry")]
	GMUGeometry Geometry { get; }

	// @required @property (readonly, nonatomic) NSString * _Nonnull type;
	[Abstract]
	[Export ("properties")]
	GMUProperties[] properties { get; }
	
	// @required @property (nonatomic) GMUStyle * _Nullable style;
	[Abstract]
	[NullAllowed, Export ("style", ArgumentSemantic.Assign)]
	GMUStyle Style { get; set; }
}

// @protocol GMUGeometryContainer <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface GMUProperties
{
	// @property (readonly, nonatomic) NSString * _Nonnull styleID;
	[Export ("key")]
	string key { get; }
	
	// @property (readonly, nonatomic) NSString * _Nonnull styleID;
	[Export ("value")]
	string value { get; }
}
