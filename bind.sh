#!/bin/bash

sharpie bind \
      -o GoogleMapsUtility-iOS-Binding/Generated \
      -sdk iphoneos11.3 \
      -scope google-maps-ios-utils/src \
      google-maps-ios-utils/src/Clustering/Algo/GMUClusterAlgorithm.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUGridBasedClusterAlgorithm.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUNonHierarchicalDistanceBasedAlgorithm.h \
      google-maps-ios-utils/src/Clustering/Algo/GMUSimpleClusterAlgorithm.h \
      google-maps-ios-utils/src/Clustering/GMUClusterManager.h \
      google-maps-ios-utils/src/Heatmap/GMUHeatmapTileLayer.h