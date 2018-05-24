#!/bin/bash

sharpie bind \
      -o Xamarin.Google.iOS.Maps.Utility/Generated \
      -sdk iphoneos11.3 \
      -scope google-maps-ios-utils/src \
      google-maps-ios-utils/src/Clustering/GMUCluster.h \
      google-maps-ios-utils/src/Clustering/GMUClusterManager.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUClusterAlgorithm.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUGridBasedClusterAlgorithm.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUNonHierarchicalDistanceBasedAlgorithm.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUSimpleClusterAlgorithm.h \
      google-maps-ios-utils/src/Clustering/View/GMUDefaultClusterIconGenerator.h \
      google-maps-ios-utils/src/Clustering/View/GMUDefaultClusterRenderer.h \
      google-maps-ios-utils/src/Heatmap/GMUHeatmapTileLayer.h \
      google-maps-ios-utils/src/Geometry/GMUGeoJSONParser.h \
      google-maps-ios-utils/src/Geometry/GMUKMLParser.h \
      google-maps-ios-utils/src/Geometry/GMUGeometryRenderer.h \
      google-maps-ios-utils/src/Geometry/Model/GMUGeometryContainer.h \
      google-maps-ios-utils/src/Geometry/Model/GMUStyle.h \