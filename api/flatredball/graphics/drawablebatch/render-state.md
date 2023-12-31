# render-state

### Introduction

Most rendering APIs (including XNA and DirectX) have what are called "render states". While there are RenderState classes, the term "render state" is a general term which is a variable that can be set before rendering to impact the rendering of objects. When rendering objects, there are many (dozens upon dozens) of states that can be set to control how objects appear. For example, The XNA GraphicsDevice.RenderState.DestinationBlend partly controls how a drawn pixel will blend with the underlying pixel.

### Setting Render States in IDrawableBatches

FlatRedBall internally sets a variety of render states to achieve certain effects according to user variables. For example, a [Sprite's](../../../../../frb/docs/index.php) [BlendOperation](../../../../../frb/docs/index.php#Alpha_and_BlendOperation) property can potentially change the RenderState's GraphicsDevice.RenderState.SourceBlend and DestinationBlend when being rendered. Therefore, any render state that you rely on in your IDrawableBatch's Draw method must be set **in the Draw method**. If it is set only in the IDrawableBatch's constructor or elsewhere in the code, your render state may be overwritten by FlatRedBall's rendering code.

### Preserving Render States

Unfortunately, FlatRedBall cannot predict the type of render states you will need in your IDrawableBatch code. Therefore, it's impossible for the engine to adjust its render states to fit your needs. However, FlatRedBall does require certain render states to be set in its rendering code. For performance reasons, FlatRedBall generally sets render states only when switching between categories of objects being rendered (such as [Sprites](../../../../../frb/docs/index.php) and [Texts](../../../../../frb/docs/index.php)) or when an object calls for it (such as when one [Sprite](../../../../../frb/docs/index.php) has a different [BlendOperation](../../../../../frb/docs/index.php#Alpha_and_BlendOperation) than the previously-drawn [Sprite](../../../../../frb/docs/index.php). Since IDrawableBatches are drawn in the same section of code as ordered [Sprites](../../../../../frb/docs/index.php) and [Texts](../../../../../frb/docs/index.php), **render states must be preserved**. This means that if you change a render state at the beginning of your IDrawableBatch's Draw method, be sure to set it back to the previous value or else you may encounter unexpected rendering behavior.
