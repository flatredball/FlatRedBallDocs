# uikit-uiviewcontroller

### Introduction

The UIViewController class can be used to display native user interfaces on iOS platforms. Common examples include a text box for entering a username, or displaying Game Center leaderboards. For API reference on UIViewController, see [this page](http://developer.xamarin.com/api/type/UIKit.UIViewController/). For a guide on creating iOS UI in code, see [this page](http://developer.xamarin.com/guides/ios/application_fundamentals/ios_code_only/).

### Accessing the Root UIViewController

The root UIViewController can be used to present custom view controllers. For example, if your project contains a UIViewController named MyLoginViewController, you can display it as follows:

```
var loginViewController = new MyLoginViewController();
var rootViewController = FlatRedBallServices.Game.Services.GetService(typeof(UIViewController)) as UIViewController;

bool animated = false;
Action completionHandler = null;

rootViewController.PresentViewController(loginViewController, animated, completionHandler);
```

&#x20;
