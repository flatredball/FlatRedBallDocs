## Introduction

The AfterThat function can simplify delaying the execution of Scripts after other scripts have run. The AfterThat function will look at the previous Do calls which are grouped under the previous "If" or "AfterThat", and will only execute it's Do's when all of the previous Do's are finished. This allows the creation of cascading sequences. For example, you may create a script which must wait for the player to advance the text before the next part of the script executes.

## Example Code

The following shows how AfterThat might be used in a simple scripting block:

``` lang:c#
If.StartPushed();
Do.ShowCountdown();
AferThat();
Do.StartGameplay();
```

In the case example, the ShowCountdown script will execute as soon as StartPushed evaluates to true. Asuming that ShowCountdown has a function to determine if it has finished (more info below), then StartGameplay will execute after ShowCountdown has finished. Note that AfterThat can only be used to delay the execution of other Do scripts within the same If. AfterThat cannot be used to delay the evaluation of other if's. For example, the following is **not valid:**

``` lang:c#
If.StartPushed();
Do.ShowCountdown();

// This AfterThat will *not* delay the evaluation of If.PlayerHasMoved()
AfterThat();

If.PlayerHasMoved();
Do.ShowTutorial();
```

 

## Requirements to use AfterThat

To use the AfterThat function effectively, your Do's must contain logic to return when they are finished. If a Do (specifically a GeneralAction) does not contain a function for determining if it has finished, then it will be treated as if it has immediately finished once it has executed. Therefore, not all Do's need to contain timing values if using AfterThat - only Do's which you'd like to take a certain amount of time to execute.

## Tutorial Introduction

For this tutorial we will use a Circle and move it right, then back left, then back right. We'll use the AfterThat function to turn the circle around when it has reached its destination.

## Setting up the If and Do functions

The first step is to create the If and Do functions that will be available in our game script. I won't cover the steps here because they are identical to the implementation tutorial [which can be found here\|which can be found here](/frb/docs/index.php?title=Glue:GlueVault:Component_Pages:Game_Scripting_Plugin:Implementation_Tutorial "Glue:GlueVault:Component Pages:Game Scripting Plugin:Implementation Tutorial"). In short the setup is:

1.  Create a new project
2.  Use the menu option provided by the Game Scripting plugin to add all of the required code files to your project.
3.  Create a screen called GameScreen
4.  Create a class called GameScript which should have the following contents:

&nbsp;

        interface IGameScriptIf : FlatRedBall.Scripting.IIfScriptEngine
        {
            void True();
        }

        interface IGameScriptDo : FlatRedBall.Scripting.IDoScriptEngine
        {
            void MoveRight(FlatRedBall.PositionedObject objectToMove, float target, float speed);
            void MoveLeft(FlatRedBall.PositionedObject objectToMove, float target, float speed);
        }

        class GameScript : FlatRedBall.Scripting.ScriptEngine, IGameScriptIf, IGameScriptDo
        {
            Screens.GameScreen mScreen;

            public GameScript(Screens.GameScreen gameScreen)
            {
                mScreen = gameScreen;
            }


            public IGameScriptIf If
            {
                get
                {
                    return this;
                }
            }

            public IGameScriptDo Do
            {
                get
                {
                    return this;
                }
            }
        }

## Adding If.True()

It's common to have a "True" function available under the If interface to kick off scripts. Our interface above already defines it, so we now have to implement the function in GameScript. To implement this, add the following to your GameScript class:

            public void True()
            {
                CreateGeneralDecision(() => true);
            }

## Addding Do.MoveLeft() and Do.MoveRight()

Next, we'll need to implement the MoveLeft and MoveRight functions. To do this, add the following to your GameScript class:

            public void MoveRight(FlatRedBall.PositionedObject objectToMove, float target, float speed)
            {
                Action action = () => objectToMove.XVelocity = speed;
                var generalAction = CreateGeneralAction(action);
                generalAction.IsCompleteFunction = () => objectToMove.X >= target;
            }

            public void MoveLeft(FlatRedBall.PositionedObject objectToMove, float target, float speed)
            {
                Action action = () => objectToMove.XVelocity = -speed;
                var generalAction = CreateGeneralAction(action);
                generalAction.IsCompleteFunction = () => objectToMove.X <= target;
            }

Notice that the MoveLeft and MoveRight functions are structured the same, but they use different values for velocity and for IsCompleteFunction. Let's look specifically at MoveRight and identify what each line of code does:

    Action action = () => objectToMove.XVelocity = speed;

This line of code creates an Action using a lambda expression. This could be done using anonymous delegates, or even functions that you create in your script code. This line of code will simply assign the argument objectToMove's XVelocity to the argument speed variable when the script executes.

    var generalAction = CreateGeneralAction(action);

This line of code takes the "action" that we created above and stores it for execution. Calling CreateGeneralAction tells the scripting system to store this action and execute it when its owning If evaluates to true.

    generalAction.IsCompleteFunction = () => objectToMove.X >= target;

This line of code assigns a "IsCompleteFunction" which is used to determine when the action is complete. In this case we're checking to see what the objectToMove's X value is. Again, we're using a lambda expression here but this code could have been written with anonymous delegates or standard functions.

## Creating Initialize

Now that we have our If and Do functions defined, let's implement the script. To do this, add an Initialize function to your GameScript class which should look like this:

     public override void Initialize()
     {
         If.True();
         Do.MoveRight(mScreen.CircleInstance, 100, 30);

         AfterThat();
         Do.MoveLeft(mScreen.CircleInstance, -120, 50);

         AfterThat();
         Do.MoveRight(mScreen.CircleInstance, 200, 100);
     }

Notice that "AfterThat" takes the place of "If" for the second and third Do calls. The first AfterThat will wait until the first Do.MoveRight is finished before it executes its MoveLeft. Similarly, the second AfterThat will wait for Do.MoveLeft to finish before it executes its MoveRight.

## Adding the Script to your Screen

Finally we need to add the script to the GameScreen. Once finished your GameScreen should look like this:

    public partial class GameScreen
    {
        Scripts.GameScript mScript;

        void CustomInitialize()
        {
            mScript = new Scripts.GameScript(this);
            mScript.Initialize();
        }

        void CustomActivity(bool firstTimeCalled)
        {
            mScript.Activity();
        }

        void CustomDestroy()
        {
        }
        static void CustomLoadStaticContent(string contentManagerName)
        {
        }
    }

If you run your game you should now see your circle move right, then left, then back to the right on its own. Notice that we never specified any timing values - the AfterThat's simply execute after the previous scripts run. This means that you can adjust any script and subsequent scripts will adjust automatically.
