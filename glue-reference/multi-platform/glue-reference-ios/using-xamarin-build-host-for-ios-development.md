# Using Xamarin Build Host

### Introduction

FlatRedBall iOS projects (including Glue projects) can be developed in Visual Studio and deployed to an iOS device through a networked Mac using Xamarin Build Host. This is the fastest way to develop iOS gams but it does require a Xamarin Business License (which is more expensive than Xamarin Indie License).

This article shows how to use Xamarin Build Host to deploy a FlatRedBal iOS game.

### Xamarin Build Host Setup

Before deploying you must have your Mac and PC computers configured for Xamarin Build Host. Xamarin provides a guide for getting Xamarin Build Host set up here: [http://developer.xamarin.com/guides/ios/getting\_started/installation/windows/introduction\_to\_xamarin\_ios\_for\_visual\_studio/](http://developer.xamarin.com/guides/ios/getting\_started/installation/windows/introduction\_to\_xamarin\_ios\_for\_visual\_studio/)

### Creating an iOS Project in Glue

Creating a FlatRedBall iOS project through Glue is nearly identical to creating a PC project:

1. Open Glue
2. Select File->"New Project"
3. Select "iOS" as the project type
4. Enter a name
5. Click "Make my project!"

![CreateNewiOSProject.gif](../../../.gitbook/assets/migrated\_media-CreateNewiOSProject.gif)

Once the project has finished downloading it can be opened in Visual Studio. Visual Studio should display UI for the Xamarin Build Host:

![ConnectedToMac.PNG](../../../.gitbook/assets/migrated\_media-ConnectedToMac.PNG)

### Running the project

As shown in the Xamarin guide above, running the app simply requires running from Visual Studio just like normal. Of course, the app will run on simulator or physical iOS device depending on your settings:

![FrbiOSScreenie.png](../../../.gitbook/assets/migrated\_media-FrbiOSScreenie.png)
