# optionally-loaded-content

### Introduction

Other tutorials so far have shown how to add content files (like .scnx files) to your Screens, Entities, and GlobalContent. However, all content added so far has always been loaded whenever their containing Screens or Entities have been instantiated. There are cases where the content that is loaded depends on the state of the game, and Glue is designed to handle these cases as well.

For example, consider a racing game where the player can choose his car. Each individual car may be represented by a different texture. That is, if the car's VisibleRepresentation is a Sprite, then the Sprite's Texture will need to be set according to what the player picks in the menu before the race. This article discusses how to load only the textures needed for your game. You'll learn how to set up you content so that it is optionally loaded, and how to load it in your game according to what the user has selected.

### Setting the "Loaded Only When Referenced" Property

The first step to making your content optionally-loaded is to set the Loaded Only When Referenced property. In this example we'll begin with a project that has four files:

![GlueFourCarFiles.png](../../../media/migrated_media-GlueFourCarFiles.png)

Next, we'll set the "Loaded Only When Referenced" property to be true on all of the files:

![GlueLoadedOnlyWhenReferenced.png](../../../media/migrated_media-GlueLoadedOnlyWhenReferenced.png)

Let's look at what the generated code looks like after we've set these properties.

![GeneratedLoadingCode.png](../../../media/migrated_media-GeneratedLoadingCode.png)

As you can see, the getter loads the content when it's first accessed. If it's not accessed, then the file is never loaded.

### Setting up a Scene

At this point in our article we have four optionally loaded files. Next we need to create a Scene for the Sprite. To do this:

* Right-click on Files under your Entity.
* Select "Add File >".
* Select "New File".
* Select "Scene (.scnx)" as the file type.
* Enter the name "SceneFile" as the file name.

Now we need to add a new Sprite which will display the car texture. To do this:

* Double-click on the newly-added .scnx file in Glue. This will open the SpriteEditor.
* Click on the "Add" menu item.
* Click on "Sprite ->"
* Click on "Untextured"![SpriteEditorAddUntextured.png](../../../media/migrated_media-SpriteEditorAddUntextured.png)

You should now see a new red Sprite in the center of the Screen:

![SpriteEditorUntexturedSprite.png](../../../media/migrated_media-SpriteEditorUntexturedSprite.png)

Now you can save your Scene and exit the SpriteEditor.

As always, you will want to create a Sprite object from the Scene that you just created. To do this:

* Right-click on "Objects" under you Entity
* Select "Add Object"
* Name the object Sprite
* "Source Type" should already be "File". Change its "Source File" to your scene file
* Change the "Source Name" to "UntexturedSprite"

Your Entity now has a Sprite object which you can access in code.

### Conditionally setting the Sprite's Texture

The next step is to set the Sprite object's Texture. We can break the task of setting the texture into two parts:

1. Deciding what texture the Sprite should be
2. Actually setting the texture once the decision is made

This might seem backwards, but we're going to start with step 2 - actually setting the texture. The reason for this is because this task would need to be done first so that it can be used when writing the decision-making code.

### Getting the property

For the following code we'll assume that the decision of which texture to use will be made outside of our Entity. For example, the car color may be set in a settings screen prior to the actual race where the PlayerCar entity is used.

Therefore, we'll create a public method called SetTexture which will take a string name and set the property. This approach is also useful if you are dealing with a CSV file that includes information. You can use the string values out of the data object and directly pass them to the class (as we'll show below).

#### Using GetMember

Every Entity and Screen has a GetMember method which can be used to get a File by name. The GetMember does not take a path or extension. Therefore, you would use "RedCar" as opposed to "Content/Entities/PlayerCar/RedCar.png" when calling GetMember.

To allow access to setting the texture using GetMember, add the following code to your Entity's custom code file:

```
 public void SetTexture(string texturePropertyName)
 {
     // Use GetMember to get the Texture2D.  Remember, simply
     // accessing this property will cause a load, but only of the property
     // with the name contained in texturePropertyName
     Texture2D textureToSet = (Texture2D)this.GetMember(texturePropertyName);

     // Now we have a reference to the texture to set.  We just have to set it to the Sprite's texture:
     this.Sprite.Texture = textureToSet;
     // Set the ColorOperation to use Texture - the reason for this is 
     // untextured Sprites in the SpriteEditor use ColorOperation.Color
     // so that the Red/Green/Blue values can be seen.
     this.Sprite.ColorOperation = ColorOperation.Texture;
 }
```

That's all there is to it! Now we simply need to call SetTextureProperty and pass a proper string and our Sprite will be set to the right texture. For more information on ColorOpeation, see the [ColorOperation page](../../../frb/docs/index.php) and the [IColorable page](../../../frb/docs/index.php).

### Deciding on which texture to set

Now we have a SetTextureProperty method in our Entity which can take a texture property name and set the value. Keep in mind that the value passed to SetTextureProperty is **not the file name of the texture**. It is the property name. In other words:

Yes! This is correct:

```
mCarInstance.SetTextureProperty("BlueCar");
```

No no no no! Don't use the file name:

```
mCarInstance.SetTextureProperty("BlueCar.png");
```

But actually, even the first call to SetTextureProperty up above isn't the best way to code this up. Why? Because what if your designer or artist decides that you should now have an orange car as well? Once the orange car graphic is created and added to Glue, you will have to go in and add another line to set the orange car graphic. While that may seem insignificant, writing your code so that new content can be added without any programmer involvement can lead to very efficient development. In fact, it's the very idea behind Glue!

So instead, we should put this all in the hands of the content creator by writing a general system that will handle everything for us.

One of the challenges of presenting a system like this in an article is that it has the potential of becoming **very large**. Sure, we've already written the code to set the texture, and we've shown how to set the texture with a hard-coded value such as "BlueCar", but how would we handle the selection though data?

The answer lies in the .csv file format. Whenever you encounter a problem like this, we recommend making .csv files. A previous Glue tutorial covers how to work with .csv files [here](../../../frb/docs/index.php#Introducing_CSV) so we'll skip over the details. Make sure that when you create your CSV file you either add it to the Screen that will select the car texture (like a menu screen) or add it to "Global Content Files" in Glue.

Your .csv might look something like this:

![AvaialbleCarsSpreadsheet.png](../../../media/migrated_media-AvaialbleCarsSpreadsheet.png)

Once you save your .csv file Glue will generate code for a list of objects which will contain the information which you can access. For example, in my code, I could do the following:

```
// My Entity is called PlayerCar
// You could create an instance of your Entity either in code or by having it added to a Screen.  In my case,
// I'm creating it manually:
PlayerCar mPlayerCar = new PlayerCar(ContentManagerName);

// Now we need to know which index into our list we're going to use.  Again, this information could come from
// anywhere - could come from a save file, could come from a previous main menu that stuffs the information
// in GlobalData.  In my case I'm using GlobalData:
int carIndex = GlobalData.Player.SelectedCarIndex;

// Next I use the carIndex to look in the list that is created from the .csv file.  Since my file is 
// loaded in global content, I access it through the GlobalContent class:
string carTextureProperty = GlobalContent.AvailableCars[carIndex].CarTextureProperty;

// Finally, I apply the carTextureProperty to my mPlayerCar:
mPlayerCar.SetTextureProperty(carTextureProperty);
```

### Conclusion

While this topic may seem large and a little complex, it is a very powerful pattern. This extends the ability of content creators to add and modify the game without any code changes. This means greatly improved productivity, far fewer bugs, and alignment with future FlatRedBall trends.

Also, keep in mind that in this article we've used optionally loaded Textures to modify a Sprite texture. This is not the limit of where this pattern can be applied - you can use it for any content such as Scenes and ShapeCollections. A properly planned data setup can also reduce the number of classes needed if your level Screens only differ by loaded content. Take some time to think about how you can apply this approach to your Glue project to make development go smoother.
