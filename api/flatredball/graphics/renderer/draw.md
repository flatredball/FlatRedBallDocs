# Draw

The Draw function is responsible for looping through all Cameras in FlatRedBall and performing rendering for each one. This method is automatically called for you in a default template, so most games do not require manually calling this method.&#x20;

The Renderer's Draw method is usually called by the [FlatRedBallServices object](../../../../documentation/api/flatredball/flatredballservices.md). You can modify the game code where [FlatRedBallServices.Draw](../../flatredballservices/draw.md) is called to customize how rendering occurs (such as to do custom render targets). For more information, see [this page](../../flatredballservices/draw.md)
