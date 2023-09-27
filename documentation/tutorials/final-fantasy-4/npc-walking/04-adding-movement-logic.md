## Introduction

At the end of the previous tutorial we had an instance of the Npc entity in the GameScreen. We had collision added to both the GameScreen (in the SolidCollision object), and the Npc entity is ICollidable with a rectangle, so we have all the pieces necessary for collision. This tutorial will add movement logic to the Npc entity. For testing we will first add movement using the keyboard, and then we'll replace it with random movement on a timer.

## Sharing SolidCollision Reference

The Npc entity will perform its movement logic in CustomActivity. To decide whether it can move it must have a reference to the SolidCollision from the GameScreen. First we'll add a property to the Npc.cs file:

    public FlatRedBall.TileCollisions.TileShapeCollection SolidCollision { get; set; }

Now we can assign it in GameScreen.cs CustomInitialize:

    void CustomInitialize()
    {
        foreach(var npc in NpcList)
        {
            npc.SolidCollision = SolidCollision;
        }
    }

All NPCs in the list will now have a reference to the SolidCollision object. Note that this requires that the Npc instances being created CustomInitialize. If our game supported spawning Npcs after the Gamescreen initialized, we'd have to handle sharing the reference on spawn.

## Adding Npc MoveToTile Method

Next we'll add a method called MoveToTile which will move the Npc to a tile in a specified direction. This method will only perform the logic to move the Npc - it won't check if the movement is possible. We will perform that logic elsewhere once we get the movement logic written.

    public void MoveInDirection(int xOffset, int yOffset)
    {
        const float secondsToTake = 0.5f;

        var destination = this.Position;
        destination.X += xOffset;
        destination.Y += yOffset;

        var direction = destination - Position;

        // assumes tiles are 16 pixels wide
        var speed = 16 / secondsToTake;

        this.Velocity = direction.AtLength(speed);

        if(xOffset > 0) SpriteInstance.CurrentChainName = "WalkRight";
        else if(xOffset < 0) SpriteInstance.CurrentChainName = "WalkLeft"; else if(yOffset > 0) SpriteInstance.CurrentChainName = "WalkUp";
        else SpriteInstance.CurrentChainName = "WalkDown";

        SpriteInstance.Animate = true;

        this.Call(() =>
        {
            Velocity = Vector3.Zero;
            Position = destination;
            SpriteInstance.Animate = false;
        })
            .After(secondsToTake);
    }

The logic above sets the velocity of the entity to move in the direction towards the offset, and then stops the velocity after the **secondsToTake** value. We can quickly test this by adding the following code to Npc.cs CustomActivity:

    private void CustomActivity()
    {
        var keyboard = InputManager.Keyboard;
        if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up)) MoveInDirection(0, 16);
        else if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down)) MoveInDirection(0, -16);
        else if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Left)) MoveInDirection(-16, 0);
        else if (keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Right)) MoveInDirection(16, 0);

    }

We can press the arrow keys on the keyboard to test movement in the four directions. [![](/wp-content/uploads/2021/03/2021_March_21_214754.gif)](/wp-content/uploads/2021/03/2021_March_21_214754.gif)

## Conclusion

Now our Npc instance can move (with keyboard input) and has a reference to the game's SolidCollision so it will be able to perform collision checks when moving to prevent from moving through walls. The next tutorial will be a deep dive into the decision logic for which direction to move. While this logic might seem simple, it becomes a little more complicated as we consider how multiple Npc instances need to consider their movement relative to one another.
