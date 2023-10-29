# glue-how-to-add-emitters

### Introduction

Emitters are objects which can create Sprites according to presets in a .emix file. Emitters are often used for animated graphical effects such as smoke, sparks, explosions, and bullets. Glue and GlueView make using Entities very easy. This page will cover the basics on how to use Entities.

### Creating a .emix file

The first step in creating an Emitter is to create a .emix file. Just like any other file, .emix files can be added to Screens or Entities. If the .emix file is added to a Screen then it will automatically emit. If it is added to an Entity then an object for a contained Emitter, or for the entire Emitter itself, must be created. For simplicity we will show how to add an Emitter to a Screen:

1. Create or select an existing Screen in your Glue project
2. Right-click on the Files tree node
3. Select "Add File" -> "New File"
4. Select "Emitter List (.emix)" as the file type
5. Enter a name or leave it as the default and click "OK"
6. Double-click the file to open it. You may need to set up your [file associations](../../../frb/docs/index.php) to open the .emix file in the ParticleEditor.![ParticleEditor.PNG](../../../media/migrated\_media-ParticleEditor.PNG)
7. Click the "Add Emitter" button
8. Enter a name for the new emitter
9. Click the "Start All" button![EmittingParticle.PNG](../../../media/migrated\_media-EmittingParticle.PNG)
10. Click File->"Save .emix (Emitter List XML)" and click OK to save the file. If asked, select the "Copy All Locally" file, then click "Save".

For more information on how to edit the file in the [ParticleEditor](../../../frb/docs/index.php), see the [ParticleEditor](../../../frb/docs/index.php) wiki page.

### Viewing the Emitter in Glue

As of October 2012 Emitters which are added to Screens and Entities will automatically emit. You can even preview emitters in GlueView. Simply select the GlueView -> "Launch GlueView" option from Glue:

![EmitterInGView.PNG](../../../media/migrated\_media-EmitterInGView.PNG)

**Note:** You may need to switch the camera from 3D to 2D in GlueView if the emitter does not show up.

### Viewing the Emitter in Game

If you run your game you will see the Emitter that you created in game (assuming the Screen that contains the Emitter is the current Screen). No additional code is required to make it run.
