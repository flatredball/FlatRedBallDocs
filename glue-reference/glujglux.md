# FileVersion (.gluj)

### Introduction

Modern FlatRedBall projects are saved as a collection of json files. The root file uses the .gluj (Glue JSON) extension. Screens use the .glsj (Glue Screen JSON) extension while entities use the .glej (Glue Entity JSON) extension. Note that older FlatRedBall projects use an XML format with the extension .glux and use only a single file for the entire project.

This document discusses details about the glue data files. Versions which display the green checkbox ✅ can typically be upgraded to without any additional modifications to the project. Versions which display the red exclamation ❗ typically require modifications to a project to prevent compile or logical errors.

### Gluj Versions

The main Glue file (gluj for modern projects) contains a file version. This version is used by the FlatRedBall editor to determine which features to enable and disable. Generally new file versions are created whenever a feature is introduced which may break old projects. Old projects can be manually upgraded to a new version, but each upgrade may require manual changes. The property controlling the file version is FileVersion. For example, the following project is using file version 11:

```
"FileVersion": 11,
```

To upgrade to a new version, the gluj/glux file can be opened in a text editor and manually updated.

Important: Upgrades may require additional changes to a project as described below. Furthermore, upgrading may have unexpected consequences, so using version control to undo large changes is recommended. Upgrades should be performed one version at a time rather than multiple versions at once.

### Version 1

This is the initial version which began tracking FileVersion.

### Version 2 - Adds Game1.Generated.cs

This version introduces Game1.Generated.cs which enables additional code to be injected into Game1 without the risk of introducing errors in custom code.

❗ To update to this version you may need to remove portions of code from Game1.cs which are handled by Game1.Generated.cs. Review the generated code and compare it with your custom code.

### Version 3 - Automatic List-Factory Association

This version automatically associates Lists in Screens with their corresponding factories. Older games may manually associate the lists with factories.

❗ To upgrade to this version, remove custom code which associates lists to factories to prevent double-adds. Also, note that you need to check your screens to make lists in the screens have AssociateWithFactory set to true on any items you wish to have associated with factories. This is default to true on newer projects, but older projects may not have this set to true automatically.

![](../media/2023-03-img\_6408847f65565.png)

### Version 4 - Gum GUE GetAnimation Method and FlatRedBall.Forms

This version introduces FlatRedBall.Forms and the GetAnimation method to Gum objects.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 5 - CSV (state) Inheritance support

CSVs can now inherit from other CSVs. This is used to allow derived platformer and top-down objects to access movement variables defined in their base classes.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 6 - Added nuget references in template csproj files

New FlatRedBall csproj files now have nuget packages as part of the csproj enabling the FlatRedBall Editor to modify these. As of version 6 this is only used to add Newtonsoft Json.Net for live editing.

❗ To upgrade to this version, manually add the Newtonsoft.Json nuget packages to your project.

### Version 7 - Added edit mode

Edit mode is now enabled. This adds a lot of generated files enabling the editor to communicate with the game, and the game automatically opens a port for the editor to connect.

### Version 8 - Screens and entities have partial CustomActivityEditMode

This adds a new function to screens and entities (partial).

✅ No changes are needed to upgrade to this version since these changes have no side effects on a game. The new methods are partial so no modifications are necessary to custom code.

### Version 9 - Glue file changed from .glux to .gluj

FlatRedBall Editor now saves its files in json format rather than xml.

✅ To upgrade to this, open the glux file and change file version to 9, then open the FlatRedBall editor. Note that the glux file will not be deleted and will remain on disk. The editor prefers to load gluj if one exists, and if not, it falls back on glux.

### Version 10 - Added IEntity base interface for entities

This adds code generation to implement the IEntity interface for all entities.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 11 - Separated Screens into glsj and entities into glej files

This version separates all screen and entity data into their own json files. This change reduces the chances of destructive merge conflicts.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor. Versions manually converting to this should first upgrade to version 9. Once a project is on version 9 or higher, it can safely be upgraded to version 11 and FlatRedBall will automatically break apart the main json file into separate Screen/Entity json files.

### Version 12 - Automatic AnimateSelf Call on Gum Screens

This version automatically adds the AnimateSelf call on Gum screens. For example, a project may have the following added to Screen Activity methods:

```csharp
if (!IsPaused)
{
    MainMenuGum?.AnimateSelf();
}
```

❗ Projects updating to this version should remove custom calls to their GumScreen's AnimateSelf, or explicit AnimateSelf calls on any component instances owned by Gum screens, otherwise animation logic will run multiple times per frame.

### Version 13 - Removal of Game1 Generated Camera and StartUp Screen

This version removes the generation of startup screen and camera setup from Game1.cs into Game1.Generated.cs. Projects upgrading to this version should remove code from Game1.cs Initialialize which sets the startup screen and which calls CameraSetup.SetupCamera. For example, before a change, Game1 Initialize may appear as shown in the following snippet:

```csharp
protected override void Initialize()
{
    #if IOS
    var bounds = UIKit.UIScreen.MainScreen.Bounds;
    var nativeScale = UIKit.UIScreen.MainScreen.Scale;
    var screenWidth = (int)(bounds.Width * nativeScale);
    var screenHeight = (int)(bounds.Height * nativeScale);
    graphics.PreferredBackBufferWidth = screenWidth;
    graphics.PreferredBackBufferHeight = screenHeight;
    #endif

    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    GlobalContent.Initialize();

                CameraSetup.SetupCamera(SpriteManager.Camera, graphics);
    Type startScreenType = typeof(CrankyChibiCthulu.Screens.VicLevel1);

    var commandLineArgs = Environment.GetCommandLineArgs();
    if (commandLineArgs.Length > 0)
    {
        var thisAssembly = this.GetType().Assembly;
        // see if any of these are screens:
        foreach (var item in commandLineArgs)
        {
            var type = thisAssembly.GetType(item);

            if (type != null)
            {
                startScreenType = type;
                break;
            }
        }
    }

    // Call this before starting the screens, so that plugins can initialize their systems.
    GeneratedInitialize();

    if (startScreenType != null)
    {
        FlatRedBall.Screens.ScreenManager.Start(startScreenType);
    }


    base.Initialize();
}
```

After the change, Game1 Initialize may appear as shown in the following snippet

```csharp
protected override void Initialize()
{
    #if IOS
    var bounds = UIKit.UIScreen.MainScreen.Bounds;
    var nativeScale = UIKit.UIScreen.MainScreen.Scale;
    var screenWidth = (int)(bounds.Width * nativeScale);
    var screenHeight = (int)(bounds.Height * nativeScale);
    graphics.PreferredBackBufferWidth = screenWidth;
    graphics.PreferredBackBufferHeight = screenHeight;
    #endif

    FlatRedBallServices.InitializeFlatRedBall(this, graphics);

    GlobalContent.Initialize();

    GeneratedInitialize();

    base.Initialize();
}
```

This change brings the following benefits:

* Changes to the StartUp screen no longer modify custom code, reducing the chances of having merge conflicts
* This change enables generated code to handle parameters for camera and resolution setup, which will be used when the game is started embedded in the game window
* Establishes a pattern for additional startup functionality which will be added in future versions.

❗ To update to this version, modify Game1.cs as shown in the code snippet above.

### Version 14 - Remove LocalizationManager.Translate Calls on Variables

FlatRedBall Editor supports localization through CSV files. If a localization file is added, then it will attempt to localize string variables. The current implementation is problematic for a few reasons:

1. It is inconsistent - some variables are assigned and some aren't. Of course, this inconsistency could be fixed, but it would take some time.
2. Sometimes variables should not be localized. It is common to create string variables for types which are enums at runtime, but are not available in the FRB Editor. When a localization file is added, all of these values will get set to localized values, and this can break a game in unexpected ways.
3. Localization may not be desirable on some strings. For example, text objects which display health or currency should not be localized.
4. Localization has no support for string interpolation. This requires code to perform properly.
5. The Gum tool supports localization files. This is where most games should perform their localization, not in the FlatRedBall editor.

Rather than completely shutting off localization in the FRB Editor, a new version is being added since it introduces a breaking change.

❗ To update to this version, you must manually add calls to LocalizationManager.Translate wherever generated code was doing so. This can be done by doing a search in generated code and identifying where this occurs. Once this version is enabled, all generated code will not contain LocalizationManager.Translate calls, so these must be done manually in code as necessary. Note that the call to LocalizationManager.AddDatabase will still be done by generated code if a localization CSV has been added to the editor in Global Content. For more information on localization, see the [LocalizationManager page](../api/flatredball/localization/localizationmanager.md).

### Version 15 - Sprite Has UseAnimationTextureFlip Property

The UseAnimationTextureFlip property was added to the FlatRedBall Source on April 1 2022. The FRB Editor needs to know if this property exists in the engine so it can be shown in the property grid. If not, then it should not be shown.

✅ To update to this version, either link your game against FRB source and update the source, or update libraries to get the latest libraries which include Sprite.UseAnimationTextureFlip.

### Version 16 - Remove IsScrollableEntityList

The IsScrollableEntityList property is an old property which has not been maintained or tested for many years. It is likely broken and similarly, modern projects probably do not use this property. Furthermore, this property mainly existed to support lists which are now handled by FlatRedBall.Forms. Therefore, this is being removed from the UI in Version 16. Earlier file versions will still display this property, but it may not work correctly.

✅ To upgrade to this version, verify that you do not rely on this functionality. No other work is needed.

### Version 17 - ScreenManager has PersistentPolygons

The FlatRedBall engine now has a PersistentPolygons list which can be used to keep Polygons persistent across screens without throwing errors. This is used by the edit-mode to display the selection. If this is false, then the polygon is not made persistent, and edit mode can crash when switching between screens. However, this is only needed if running in edit mode. Games which do not develop in edit mode do not need this.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 18 - Sprite has TolerateMissingAnimations

Normally when assigning a Sprite's CurrentChainName, if the animation is not present the code throws an exception. This can be problematic when in edit mode. This version allows the generation of Sprite.HasTolerateMissingAnimations to false when going into edit mode so that the game does not crash when assigning missing animation names.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 19 - AnimationLayer has Name and IPlatformer is Generated

**AnimationLayer has Name**

This version results in the PlatformerAnimationController generating AnimationLayers and assigning their Name property. Older versions of the FlatRedBall engine did not include a Name property.

**IPlatformer is Generated**

This version also generates the IPlatformer interface into projects. This is used to apply the new Platformer AnimationController. Projects which do not use the Platformer entity type will not be impacted by this change.

❗ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor. Make sure you do not have an existing IPlatformer interface in your project. If so, you may get class/namespace conflicts.

### Version 20 - New Default FlatRedBall.Forms Components

This version introduces a new set of FlatRedBall.Forms controls.

<figure><img src="../media/2022-02-04_08-12-25.gif" alt=""><figcaption></figcaption></figure>

These controls provide more flexibility, and the defaults are cleaner and look better overall. New FlatRedBall projects will automatically add these controls when Gum/Forms is added (usually through the wizard).

✅ Upgrading to this version is safe under a number of conditions:

1. If you do not intend to use FlatRedBall.Forms at all, then you can safely upgrade to this version.
2. If you have not yet added FlatRedBall.Forms to your game project, you can upgrade to this version first, and then add FlatRedBall.Forms through the Gum tab by selecting the .gumx file.
3. If you have already added FlatRedBall.Forms to your project, you can upgrade to this version if you do not intend to re-create all of the default forms controls. Upgrading to this version will not do anything to your project unless you re-add all controls through the Gum tab.
4. If you have already added FlatRedBall.Forms to your project and would like to replace existing .Forms controls, you can delete all default controls from your project and then re-add all Forms controls through the Gum tab. You may also be able to add all controls without deleting your existing default controls, but this has not been tested, so do so with the ability to undo your changes using version control.

### Version 21 - Support for IStackable

This version introduces support for the IStackable interface.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 22 - ICollidable has ItemsCollidedAgainst and LastFrameItemsCollidedAgainst

This version adds two new properties to ICollidable to make it easier to track collision every frame. These properties will be filled automatically by CollisionRelationships and can be used in an entity's CustomActivity. Since these properties are being added to the FlatRedBall Engine, games which compile directly against the engine have two options:

1. Increase the .gluj file version to 22. This tells the FlatRedBall Editor to codegen these properties.
2. Manually add these properties in custom code to entities. This is a fallback if upgrading a file version is inconvenient.

Note that this is a breaking change to projects linking against the engine, so one of these two changes must be performed.

✅ If projects would like to upgrade to this version, keeping the engine and FlatRedBall Editor (Glue) together will prevent compile errors.

### Version 23 - CollisionRelationship Supports ArePhysicsAppliedAutomatically and DoCollisionPhysics

This version adds the ability for CollisionRelationship physics to be defined in the FlatRedBall Editor in the **Collision Physics** UI, but to have those physics only apply if DoCollisionPhysics is called in code.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 24 - Gum Supports StackSpacing

This version adds code generation support for the StackSpacing property in Gum.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 25 - CollisionRelationships support MoveSoft Collision

This version adds limited support for MoveSoft collision. This will be expanded in future versions, but the codegen is being introduced here.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 26 - CameraSetup.Generated.cs replaces CameraSetup.cs

The CameraSetup.cs file is a generated file, so it should be named as such. Previous versions did not name it as a generated file, so it was often included in repositories. This version changes the file so it is named as a generated file.

❗ To upgrade to this version, either remove Setup/CameraSetup.cs, or rename it to Setup/CameraSetup.Generated.cs. Relaunch the FlatRedBall Editor and it will generate to CameraSetup.Generated.cs.

### Version 27 - ShapeCollection has MaxAxisAlignedRectanglesRadiusX and MaxAxisAlignedRectanglesRadiusY

This version adds support for using ShapeCollection.MaxAxisAlignedRectanglesRadiusX and MaxAxisAlignedRectanglesRadiusY in the TileShapeCollection generated code. This enables TileShapeCollections to have AxisAlignedRectangles which are not squares.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 28 - CollisionRelationship Names No Longer Include "List"

This version reduces the length of CollisionRelationships which are auto-named. "List" will be removed from the name of CollisionRelationships between lists to make it easier to read in the tree view and generated code. For example, previously a CollisionRelationship named PlayerListVsBulletList will now be named PlayerVsBullet. Similarly the generated events for when the collision occurs no longer include the word "List.

✅ To upgrade to this version, be aware that changing the object or sub-collision objects may result in a change to the collision relationship which previously had the word List. Projects do not need any changes to the underlying libraries.

### Version 29 - Gum Text Updates Internal Text With 0 Children Depth

This version does not change any interface for the code, but depends on the Gum Text object being able to update its internal character positions even if the argument for updating children depth is 0. Previously the check for children depth was performed by the Gum layout engine to prevent unnecessary Texture churn on a Text object. This is no longer needed for two reasons:

1. Often, Text objects render character-by-character. When performing character-by-character rendering, updating the characters is not as expensive because a Texture2D must not be created and disposed.
2. GraphicalUiElements (the base class for Gum objects) now have more advanced checks in their properties to prevent Layout calls from propagating.

Since the setters on GraphicalUiElement properties often prevent Layout propagation, passing a non-0 children layout depth on TextRuntime.Text changes causes more layouts. Version 29 depends on the internal GraphicalUiElement allowing text to update even if 0 child depth is passed so that TextRuntime.Text can pass a 0 depth and improve performance when updating text.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 30 - FrameworkElement Manager

This version introduces the FrameworkElementManager class which can call Activity on FlatRedBall.Forms FrameworkElements. This is useful for FrameworkElements which require every-frame activity, such as the PlayerJoinView which must query Xbox360GamePad button presses for joining and unjoining.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 31 - Has GumSkia Elements

✅ This version introduces the ability to add GumSkia elements. You can safely upgrade to this version without any changes to your project.

### Version 32 - ITiledTileMetadata

This version introduces the ITiledTileMetadata interface. This interface has a property which lets your code respond to the creation of an entity from its texture coordinates.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 33 - IDamageable and IDamageArea Updates (aka V2)

This version introduces lots of changes to IDamageable and IDamageArea. If this is enabled, the FlatRedBall Editor will generate new properties for IDamageable and IDamageArea Entities. This version also allows the editor to generate additional code on CollisionRelationships between IDamageable and IDamageArea lists.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 34 - Game1 GenerateInitializeEarly, GenerateDrawEarly, Removal of GlobalContent.Initialize

Version 34 enables additional code generation in Game1 with the addition of GenerateInitializeEarly and GenerateDrawEarly. These methods are called before standard FlatRedBall initialize and draw calls, enabling FlatRedBall Editor plugins to inject code before FlatRedBall standard calls. This is used to eliminate needing to add manual code for SkiaGum. This also removes the need to keep GlobalContent.Initialize in Game1.

❗ To update to this version, a number of changes are required. First, update the partial block at the top of Game1.cs by adding the two new Early calls as shown in the following code:

```csharp
partial void GeneratedInitializeEarly();
partial void GeneratedInitialize();
partial void GeneratedUpdate(Microsoft.Xna.Framework.GameTime gameTime);
partial void GeneratedDrawEarly(Microsoft.Xna.Framework.GameTime gameTime);
partial void GeneratedDraw(Microsoft.Xna.Framework.GameTime gameTime);
```

Next, remove GlobalContent.Initialize from the Initialize method and replace it with a call to GeneratedDrawEarly as shown in the following code. Note that GeneratedInitializeEarly should come **before** FlatRedBallServices.InitializeFlatRedBall:

```csharp
protected override void Initialize()
{
#if IOS
 var bounds = UIKit.UIScreen.MainScreen.Bounds;
 var nativeScale = UIKit.UIScreen.MainScreen.Scale;
 var screenWidth = (int)(bounds.Width * nativeScale);
 var screenHeight = (int)(bounds.Height * nativeScale);
 graphics.PreferredBackBufferWidth = screenWidth;
 graphics.PreferredBackBufferHeight = screenHeight;
#endif

  GeneratedInitializeEarly();
  FlatRedBallServices.InitializeFlatRedBall(this, graphics);
  GeneratedInitialize();
  base.Initialize();
}
```

Finally, update Draw as shown in the following code:

```csharp
protected override void Draw(GameTime gameTime)
{
   GeneratedDrawEarly(gameTime);
   FlatRedBallServices.Draw();
   GeneratedDraw(gameTime);
   base.Draw(gameTime);
}
```

### Version 35 - ICollidable has ObjectsCollidedAgainst and LastFrameObjectsCollidedAgainst

This version expands properties introduced in version 22 by adding ObjectsCollidedAgainst and LastFrameObjectsCollidedAgainst. These properties make it easier to track collision every frame. These will be filled autoamtically by CollisionRelationships and can be used in an entity's CustomActivity. Since these properties are being added to the FlatRedBall Engine, games which compile directly against the engine have two options:

1. Increase the .gluj file version to 35. This tells the FlatRedBall Editor to codegen these properties.
2. Manually add these properties in custom code to entities. This is a fallback if upgrading a file version is inconvenient.

Note that this is a breaking change to projects linking against the engine, so one of these two changes must be performed.

✅ If projects would like to upgrade to this version, keeping the engine and FlatRedBall Editor (Glue) together will prevent compile errors.

### Version 36 - FlatRedBall has IRepeatPressableInput

This version adds the IRepeatPressableInput interface which provides checks for repeated press inputs. This is used in the IInputDevice interface to standardize repeat presses when navigating through UI. For example, this is used when holding down the DPad to cycle between letters when entering a name in an arcade-style high score list.

✅ If projects would like to upgrade to this version, keeping the engine and FlatRedBall Editor (Glue) together will prevent compile errors.

### Version 37 - Tiled Files Generated

Previous versions of FlatRedBall generated all Tiled files without the .Generated.cs suffix. This causes a lot of version control noise, especially when FlatRedBall changed portions of the Generated code. Now all Tiled files are properly generated.

❗ To update to this version:

1. Open your project in Visual Studio
2. Close the FlatRedBall Editor
3.  Remove all non-generated Tiled files. You can remove the individual files or even the entire folders which contain these files. Be careful in case you have manually added additional files here:

    ![](../media/2023-02-img\_63f38a8261c27.png)
4. Save your project (csproj) in Visual Studio
5. Update your .gluj file version in a text editor
6. Open your project in the FlatRedBall Editor

After code generation finishes, all of the files should be re-added with a .Generated.cs suffix.

![](../media/2023-02-img\_63f392f2c0a53.png)

### Version 38 - Project JSON files (glej and glsj) Remove Redundant Derived Objects

This version adds logic to remove redundantly-defined derived objects from Screen and Entity json files. This can reduce file sizes and eliminate diffs in version control.

✅ No changes are required to upgrade to this version, but projects which are not on version control are advised to avoid this version until it has been fully tested for a month or two (probably until after May 2023).

### Version 39 - GraphicalUiElement (Gum) Exposes Animation Properties as Protected

This version introduces protected properties for animation including mCurrentFrameIndex and mTimeIntoAnimation. These protected properties are used by codegen for the SpriteRuntime to add the PlayAnimationsAsync method which work the same as the FlatRedBall Sprite's PlayAnimationsAsync method.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 40 - GraphicalUiElement (Gum) is INotifyPropertyChanged

This version introduces codegen which depends on GraphicalUiElement implementing the INotifyPropertyChanged interface. Initially this is used for real-time variable reference evaluation, but it may be used for additional functionality in the future.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 41 - Gum Text Objects Have TextOverflowHorizontalMode and TextOverflowVerticalMode

This version introduces codegen which depends on the Gum Text objects having TextOverflowHorizontalMode and TextOverflowVerticalMode. Projects which are not of this version will not apply these properties as set in the Gum project, so text will continue to overflow as before.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 42 - TileShapeCollectionAddToLayerSupportsAutomaticallyUpdated

This version introduces the ability for TileShapeCollections to add themselves to a Layer and to be automatically updated. This is used by Entites which include TileShapeCollections as their collision, such as moving walls in a game.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 43 - FlatRedBall Includes ISong Interface

This version introduces the usage of ISong, an interface which enables FlatRedBall to work with song files other than MonoGame (XNA). This is currently used for NAudio but it can be expanded for other types of songs in the future.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 44 - FlatRedBall Renderer has ExternalEffectManager

This version adds an ExternalEffectManager, enabling Gum and Tiled rendering to use all of the color operations available to normal FlatRedBall Sprites.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

❗ To upgrade to this version and enable rendering using the new shader for Tiled or Gum:

1. Download the latest DesktopGL template [https://files.flatredball.com/content/FrbXnaTemplates/DailyBuild/ZippedTemplates/FlatRedBallDesktopGlNet6Template.zip](../content/FrbXnaTemplates/DailyBuild/ZippedTemplates/FlatRedBallDesktopGlNet6Template.zip)
2. Extract the template
3. Navigate to the Content folder in the unzipped folder
4.  Copy the two Shader files (fx and xnb)

    ![](../media/2023-08-img\_64d80a499a664.png)
5. Paste these files into your project's Content folder, overwriting the existing shader fx and xnb files

### Version 45 - Sprite has SetCollisionFromAnimation

This version adds a new checkbox to the Sprite Variables tab enabling the generation of collision assignment from the Sprite's AnimationChains.

![](../media/2023-08-img\_64e2d3103ca16.png)

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 46 - IGumScreenOwner Interface

This version introduces the IGumScreenOwner interface. If this exists, then all FlatRedBall Screens which have a Gum Screen will implement this interface in generated code. This enables the automatic updating of layouts outside of screen code, such as in the FlatRedBall Editor code.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 47 - FlatRedBall Screens Implement INameable

This version adds a Name property to FlatRedBall Screens, and allows the code generation to assign this Name property.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 48 - SpriteManager has InsertLayer

This version adds usage of the SpriteManager's InsertLayer to enable reordering of Layers during live edit.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 49 - Gum Renderables Use System.Drawing and System.Numerics

This version is a breaking change to Gum - Gum renderable objects no longer use XNA objects such as Color, Vector3, and Matrix for their internals. This change is an effort to make Gum more cross-platform in C# and to eventually support other programming languages without needing to migrate as much XNA syntax.

This change only modifies the Renderables themselves such as Text and Sprite, but does not modify the wrapping codegen objects such as TextRuntime and SpriteRuntime, so most games will not be affected by this change. However, if you are directly working with the renderables then you may be affected by this syntax change.

Note that if your project is linked to source, then the FRB codegen system will automatically generate the new codegen against the System.Drawing and System.Numerics types, so you are not required to upgrade to this version.

❗ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor. If you have compile errors:

* Identify the locations where you are having compile errors and make the assignments of the values use the proper types. You may need to convert from XNA to System.Drawing/Numerics types.
* Add System.Numerics and System.Drawing references to your project if you are using an older version of FlatRedBall.

### Version 50 - GumCommonCodeReferencing

This version updates to using the GumCommon code. The engine doesn't reference GumCommon libraries, but the addition of GumCommon shifts where code is located in the files that are being referenced by the engine and also by games which link to source.

This version does not provide any funcitonal changes.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 51 - Gum Text supports BBCode

This version allows Gum projects to use BBCode for specifying inline styles.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 52 - IDamageArea has IsDamageDealingEnabled and IDamageable has IsDamageReceivingEnabled

#### This version introduces several new properties:

* IDamageArea.IsDamageDealingEnabled
* IDamageable.IsDamageReceivingEnabled
* IDamageable.InvulnerabilityTimeAfterDamage
* IDamageable.IsInvulnerable
* IDamageable.LastDamageTime

These new properties are generated on Entities which implement IDamageArea and IDamageable automatically for projects which are at least on version 52.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

❗ Note - if your game uses these interfaces which are either implemented in code, or if you have disabled automatic generation of these properties, then you will need to manually add properties as shown in the following code:

<pre class="language-csharp"><code class="lang-csharp">// IDamageArea:
bool IDamageArea.IsDamageDealingEnabled => true;

<strong>// IDamageable:
</strong>bool IDamageable.IsDamageReceivingEnabled => true;

double InvulnerabilityTimeAfterDamage => 0;
bool IsInvulnerable => TimeManager.CurrentScreenSecondsSince(LastDamageTime) &#x3C; InvulnerabilityTimeAfterDamage;
double LastDamageTime { get; set; } = -999
</code></pre>

If needed you can create these as properties with getters and setters, but the code above matches the behavior prior to version 52.

### Version 53 - "Type" class is now "Variant"

This version removes the confusing "Type" class for derived entities and replaces it with the name "Variant". This is a breaking changes. For example, if you have a base Enemy entity and derived Enemy entities, then FlatRedBall will have generated a class called EnemyType with all of the derived Enemies.

The reason for this change is to avoid confusion with the C# "Type" class in documentation, discussion, and code. Instead, the word Variant will be used in all documentation and code going forward.

❗ Since the name of the class changes, this upgrade may require you to make manual changes if you have been using the Type class. The following list outlines the changes required. If you have not been using the "Type" classes, then no changes are needed.

1. Change all partials from "Type" to "Variant" to match the newly-generated class.
2. Change usage of any "Type" in your custom code to "variant"
3. Change any instances which may reference "Type" variables to the new type

The last item requires a bit of manual work so the following outlines the steps to make this change.

Before the upgrade, you may have instances which reference the old "Type" variable as shown here:

<figure><img src="../.gitbook/assets/image (81).png" alt=""><figcaption><p>EnemyType in json file</p></figcaption></figure>

These will generate incorrectly until, as shown in the following errors in Visual Studio:

<figure><img src="../.gitbook/assets/image (82).png" alt=""><figcaption><p>Errors generating EnemyType and GameScreenType</p></figcaption></figure>

To fix these problems:

1. Use a version control system such as Git, or back up your project. Changing types on variables can cause unintended side effects so it's best to have a backup.
2. Locate the entity or screen which references the incorrect variable. You can do this by double-clicking the error in Visual Studio to be taken to the generated code with the error.
3. Find the matching entity or screen in the FRB Editor
4.  Find the variable with the old "Type" type and change it to variant.\


    <figure><img src="../.gitbook/assets/image (83).png" alt=""><figcaption><p>Change the type to Variant</p></figcaption></figure>



FlatRedBall attempts to keep all of your variable values the same, so if all worked okay you should not have any changes on instances aside from the types.

<figure><img src="../.gitbook/assets/image (84).png" alt=""><figcaption></figcaption></figure>

### Version 54 - ITopDownEntity Animations

This version adds top down animation support using an AnimationController specifically built for top down entities. Conceptually this is similar to platformer entity animations. It is optional and will not affect existing games with top down entities.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

### Version 55 - Case Sensitive File Loading

This version modifies code generation so that it includes the case of file paths rather than calling ToLower on all files. This helps make FRB work better on case-sensitive platforms such as iOS, Android, and Linux.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.

❗ Mobile games using Xamarin should not update to this version.

### Version 56 - Added FlatRedBallServices.GraphicsDeviceManager

This version modifies code generation for the Profiling tab so that it can enable/disable fixed time step and v-sync. Disabling v-sync requires access to the GraphicsDeviceManager which is now publicly exposed by FlatRedBallServices.

✅ To upgrade to this version, either link to the FlatRedBall Engine source code and update the repository, or update the pre-built binaries through the FlatRedBall Editor.
