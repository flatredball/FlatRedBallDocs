## Introduction

The LastCollision properties in the ShapeCollection can be used to identify which shapes were collided with on the last collision. This is useful because many games need to know specifically which shapes were collided against to perform custom logic. For example, you may be working on a platformer which includes collision shapes representing spikes. If the character touches a spike then he should lose a life. The LastCollision properties enable checking for this information.

## Code Example

The following example shows how to check which shapes the user collided against. It will check collision against a shape collection. If the user touched an AxisAlignedRectangle which has the name that includes the word "Spike" then the game responds appropriately:

    // Assuming that Character has a Collision object which is a valid shape (such as an AxisAlignedRectangle)
    if(Character.Collision.CollideAgainstMove(ShapeCollectionInstance))
    {
       for(int i = 0; i < ShapeCollectionInstance.LastCollisionAxisAlignedRectangles.Count; i++)
       {
           if(ShapeCollectionInstance.LastCollisionAxisAlignedRectangles[i].Name.Contains("Spike"))
           {
               ReactToPlayerHittingSpikes();
               break;
           }
       }
    }
