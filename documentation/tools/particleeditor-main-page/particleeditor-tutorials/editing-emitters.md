## Introduction

The ParticleEditor public provides full control over all emitter properties, which are broken up into two two categories: Emitter Properties and Particle Properties:

![EmitterAndParticleProperties.png](/media/migrated_media-EmitterAndParticleProperties.png)

### Emitter Properties

Emitter properties control where and how often an emitter creates its particles. For example, the X, Y, and Z values define the position of the emitter, and the AreaEmissionType controls whether to emit all particles from a single point, or inside of an area (such as a rectangle).

The SecondFrequency property controls how much time should pass between each emission. A smaller number means that the emitter will create particles more frequently.

### Particle Properties

Particle properties control the behavior of particles after they have been created. For example, the RadialVelocity property controls how fast particles fly outward from the emission point.

## Setting Particle Texture

The Texture property controls which image is displayed by each particle. This value is null by default. To set the texture:

1.  Click the "..." button on the Texture property in the particle settings section.
2.  Navigate to where the desired file is located
3.  Select the file and click "Open"
4.  If asked, copy the file to the location of the .emix file

If the loaded file is outside of your Glue project's content folder, then the file should be copied. If the file is already a part of the Glue project's content folder, then there is no need to copy the file.

![SetTextureOnEmitter.gif](/media/migrated_media-SetTextureOnEmitter.gif)

## Previewing Emitters

The ParticleEditor and GlueView work together to provide real-time previewing of particles. To learn more about GlueView, see the [GlueView page](/frb/docs/index.php?title=Glue:Reference:Menu:Glue_View "Glue:Reference:Menu:Glue View").

GlueView displays the selected Screen/Entity, mimicing what will be shown when you run the game (excluding custom code). Since files behave slightly different in screens and entities, the process of previewing an emitter depends on whether the emitter is part of a screen or entity.

### Previewing in Screens

Files which are part of screens will automatically show up in game and GlueView. Therefore, the only requirement to view an emitter in a screen is to have its \*TimedEmission\* value set to true:

![TimedEmissionEmitInScreen.png](/media/migrated_media-TimedEmissionEmitInScreen.png)

### Previewing in Entities

Previewing an emitter in an entity is similar to previewing an emitter in a screen; the only difference is that an object must be made in the entity to display either a single emitter, or the entire file. For more information on entire files, see [the Entire File page](/frb/docs/index.php?title=Glue:Reference:Objects:Entire_File "Glue:Reference:Objects:Entire File").

### Manually emitting an emitter

If an emitter is part of an entity, but has not yet been added as an object, then it will not automatically emit. The ParticleEditor provides two buttons for manually emitting:

1.  Emit All - emits all contained emitters in the file one time.
2.  Emit Current - emits the selected emitter one time.

Note that if particles have their **NumberPerEmission** value set to greater than 1, then clicking the buttons will result in multiple particles being created.

## Conclusion

Emitters have a lot of properties available, so the best way to learn how to create emitters is to experiment with the values. Using GlueView, all changes will appear in real-time, making particle creation fast and wasy.
