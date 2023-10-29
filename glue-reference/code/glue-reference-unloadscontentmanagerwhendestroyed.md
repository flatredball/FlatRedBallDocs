## Introduction

The UnloadsContentManagerWhenDestroyed controls whether a Screen will unload all of the content that it has loaded when it is Destroyed. The UnloadsContentManagerWhenDestroyed is set to true by default, meaning a Screen will unload its content at the end of its life. This property can be set to false and the Screen will not unload its ContentManager. There are two common situations when you may not want to unload content:

1.  A series of Screens which use the same content may not want to unload after each is destroyed. This will allow content to be "passed" from Screen to Screen, which can greatly improve load times. Of course, you need to make sure that the last Screen in the series has its UnloadsContentManagerWhenDestroyed set to true.
2.  A popup Screen may use the same content manager as its parent Screen. In this case, it should not unload the content because it will unload its parent's content as well.

## Dynamically setting UnloadsContentManagerWhenDestroyed

The UnloadsContentManagerWhenDestroyed property is simply a property which can be set at any time. The Screen uses this property only when unloading, meaning that this property can be set at any time - even in CustomDestroy. Therefore, you can set UnloadsContentManagerWhenDestroyed depending on which Screen is next if the current Screen may has multiple Screens that it can go to, and one uses the same content while the other does not.
