# Introduction

The CurrentTime property returns how much time has passed since the start of the game's execution in seconds. This value changes every frame - specifically when calling [FlatRedBallServices.Update](../../../../frb/docs/index.php). This value will only change whenever [FlatRedBallServices.Update](../../../../frb/docs/index.php), meaning it will be the same value throughout the entire frame. Therefore, this value can be used to uniquely identify a frame.
