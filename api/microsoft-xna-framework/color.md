## Introduction

The Color struct is a common struct used in FlatRedBall to control the color of objects. Unfortunately the Color class used by the different versions of FlatRedBall is not cross-platform. Therefore, you may need to change which using statement you put at the top of any class that uses the Color struct.

Use one of the following three lines of code to qualify the Color class:

    using Color = SilverArcade.SilverSprite.Graphics.Color; // if using FlatSilverBall
    using Color = Microsoft.Xna.Framework.Graphics.Color; // if FlatRedBall XNA 3.1
    using Color = Microsoft.Xna.Framework.Color; // If using FlatRedBall XNA 4.0 (namespace changed in XNA framework)
    using Color = System.Drawing.Color; // if using FlatRedBall MDX

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
