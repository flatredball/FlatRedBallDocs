# new-starter-project-brakeneck

Starter projects are a great way to begin your journey as a game developer or to learn about FlatRedBall. As of today Glue includes a new starter project called BrakeNeck, a top-down endless shooter which can be played by one or two players. https://www.youtube.com/watch?v=1nWEo-JhNAg BrakeNeck focuses on a few technologies and patterns:

* Extensive use of code-driven particles (as opposed to using an Emitter)
* Gum for UI and HUD
* Multi-player - a first for FlatRedBall starter projects. This requires two controllers, but of course you can modify the code to use other hardware.
* Lots of polish! Particles, explosions, shadows, tracks.

Of course, this starter project has also resulted in a huge set of bug fixes and engine improvements in FlatRedBall including:

* A new GameRandom class in FlatRedBallServices to provide convenient random functions
* Lots of minor improvements to the workflow of the AnimationEditor, such as bringing selected frames into focus and not showing the movement arrows when in Magic Wand mode.
* Gum text bug fixes, including a bug where layout didn't consider font scale and also added support for text objects up to 4096x4096 in size
* Fixed GlueView bug where sometimes position wouldn't apply on animated sprites
* Fixed code generation bug where the order of variable assignments was at times random
* And much more! For a full list of FRB changes, check out the [FlatRedBall Trello board](https://trello.com/b/lc6VzEDl/flatredball-engine-and-tools)

The starter project can be accessed through Glue's New Project menu, or you can [look at the source directly on github](https://github.com/vchelaru/BrakeNeck).   Big thanks to profexorgeek ([twitter](https://twitter.com/profexorgeek), [facebook](https://www.facebook.com/justin.d.johnson)) for supplying the beautiful art for this game.
