## Introduction

Rendering (the process of displaying graphics on screen) can be a source of performance problems. If you're not familiar with rendering you may ask "Why do we differentiate between rendering and other areas of code which may slow performance?" A few reasons for this are:

1.  Computers often have dedicated hardware for rendering.
2.  Rendering is often "async". In other words, a particular call may begin the process of rendering, and the code flow can continue while the rendering happens in the background. While this means that rendering can be fast, it also means that it can be difficult to measure exactly where the slowdown occurs.
3.  Rendering is often handled internally by FlatRedBall, so unless you are building against source you may not know exactly what is happening in the rendering code.
4.  Special software exists to help diagnose rendering problems.

## Areas of performance problems

Rendering slowdowns can occur due to a number of problems:

1.  Render State changes - for more information see [FlatRedBallXna:Tutorials:Render_State_Changes](/frb/docs/index.php?title=FlatRedBallXna:Tutorials:Render_State_Changes.md "FlatRedBallXna:Tutorials:Render State Changes")
2.  Fill rate/vertex count - for more information see the [PIX page](/frb/docs/index.php?title=FlatRedBall:Tutorials:PIX.md "FlatRedBall:Tutorials:PIX")
