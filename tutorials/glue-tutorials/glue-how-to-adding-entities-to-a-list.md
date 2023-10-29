## Introduction

Lists in Glue are common objects, especially inside of screens. Lists can be used to contain groups of objects. These objects can either be added at runtime (through code) and in Glue. Adding a dynamic number of objects requires adding them through code.

## Adding in Code

The following code assumes a screen called GameScreen, an entity called Bullet, and a list of Bullets called BulletList inside of GameScreen:

![ListHowToSetup.PNG](/media/migrated_media-ListHowToSetup.PNG)

The following code will create a bullet whenever the user presses the space bar. Notice that this code is being added to the **GameScreen.cs** file.

Modify the GameScreen's CustomActivity so it reads as follows:

    void CustomActivity(bool firstTimeCalled)
    {
        if(InputManager.Keyboard.KeyPushed(Keys.Space))
        {
            Entities.Bullet newBullet = new Entities.Bullet();
            BulletList.Add(newBullet);
        }
    }
