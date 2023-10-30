# tutorials-gum-exposed-variables

### Introduction

Exposed variables provide a way to modify Gum objects contained within other Gum objects through your code. For this tutorial, we'll be creating a scoring HUD object.

### Creating a ScoreHud object

First, we'll create a ScoreHud component in Gum. To do this:

1. Right-click on Components and select **Add Component**
2. Enter the name **ScoreHud** and click **OK**
3. Verify **ScoreHud** is selected
4. Set **Width Units** to **RelativeToContainer**
5. Set **Width** to **0**
6. Set **Height Units** to **RelativeToContainer**
7. Set **Height** to **0**

![ScoreHud1.PNG](../../../../media/migrated_media-ScoreHud1.PNG) Next, we'll create two Text objects:

1. Drag+drop a Text object into the ScoreHud object.
2. Rename the Text to Player1ScoreText
3. Position the Player1ScoreText object near the top-left of the Screen
4. Change the Player1ScoreText's "X Units" to "PercentageWidth"
5. Repeat the steps above to create a Player2ScoreText which is positioned on the top-right of the Screen

![ScoreHud2.PNG](../../../../media/migrated_media-ScoreHud2.PNG)

### ScoreHud in MainMenuGum

Now we can add a ScoreHud instance to the MainMenuGum by drag+dropping the ScoreHud into MainMenuGum: ![ScoreHud3.PNG](../../../../media/migrated_media-ScoreHud3.PNG) If you run the game at this time you'll notice that the score hud appears, but the score HUD says "Hello" for Player 1 and Player 2's scores. We can get access to the ScoreHud object in Glue as follows:

1. Switch to Glue
2. Expand the "MainMenu" screen
3. Right-click on Objects
4. Select "Add Object"
5. Select "From File"
6. Select the file "MainMenuGum.gusx"
7. Select ScoreHudInstance as the Source Name
8. Enter the name ScoreHudInstance
9. Click OK

![ScoreHud4.png](../../../../media/migrated_media-ScoreHud4.png) Unfortunately, if you try to access the Player objects in Visual Studio you'll see that there is no way to change the Text on the ScoreHud: ![ScoreHud5.png](../../../../media/migrated_media-ScoreHud5.png)

### Accessing score Text

To access the score text we first need to expose the variables in Gum. To do this:

1. Switch to Gum
2. Select the Player1ScoreText object in Gum
3. Right-click on the Text variable
4. Select "Expose Variable" ![GumExposeVariable.png](../../../../media/migrated_media-GumExposeVariable.png)
5. Enter the name "Score1" and click OK
6. Repeat the same process to expose "Score2" for Player2ScoreText

You should now have 2 exposed variables. You can see this by selecting the **ScoreHud** object in Gum: ![ExposedVariablesInContainer.PNG](../../../../media/migrated_media-ExposedVariablesInContainer.PNG) Now you can go to Visual Studio and add the following code to CustomInitialize  in your MainMenu  screen:

```
void CustomInitialize()
{
    this.ScoreHudInstance.Score1 = "200";
    this.ScoreHudInstance.Score2 = "450";
}
```

Notice that the variables appear in Visual Studio with the same names as exposed in Gum. Running the game will show the score values showing 200 and 450 respectively. ![ScoreHud6.png](../../../../media/migrated_media-ScoreHud6.png) [<- 5. Events on Gum Objects Part 2](5-events-on-gum-objects-part-2.md) -- [7. States ->](tutorials-gum-states.md)
