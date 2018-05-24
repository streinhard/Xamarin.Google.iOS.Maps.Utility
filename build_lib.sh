#!/bin/bash

pod install --project-directory=google-maps-ios-utils/workspace

mkdir -p build

xcodebuild \
	-configuration Release \
	-sdk iphoneos \
	-scheme GoogleMapsUtils \
	-workspace google-maps-ios-utils/workspace/GoogleMapsUtils.xcworkspace \
	-derivedDataPath build

xcodebuild \
	-configuration Release \
	-sdk iphonesimulator \
	-scheme GoogleMapsUtils \
	-workspace google-maps-ios-utils/workspace/GoogleMapsUtils.xcworkspace \
	-derivedDataPath build

lipo -create \
	build/Build/Products/Release-iphoneos/libGoogleMapsUtils.a \
	build/Build/Products/Release-iphonesimulator/libGoogleMapsUtils.a \
	-output Xamarin.Google.iOS.Maps.Utility/libGoogleMapsUtils.a