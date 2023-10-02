## Introduction

State Categories can be thought of as folders for states. State Categories are used for a number of reasons:

-   To organize similar states into categories
-   To allow multiple states to be set at the same time (if not sharing variables between states)
-   To create multiple enumerations for more expressive code (if not sharing variables between states)
-   To enable including and excluding particular variables from assignment

State categories will appear as folders in Glue which can contain any number of States. ![StateCategories.PNG](/media/migrated_media-StateCategories.PNG) Note that categorized cannot be added inside of other categories.

## Adding a State Category

To add a state category:

1.  Expand a Screen or Entity that you want to add a category to
2.  Right-click on the States item
3.  Select "Add State Category" ![AddStateCategory.png](/media/migrated_media-AddStateCategory.png)
4.  Enter the name for the new category
5.  Click OK

## Excluding Variables in Categories

By default a category has access to all variables on a Screen or Entity. For example, the following Player entity includes 10 variables:

![](/media/2021-10-img_617bf592855c2.png)

By default all variables appear in the the State Data tab when viewing one of the categories, as shown in the following image:

![](/media/2021-10-img_617bf658b5b63.png)

Usually states should only set a few of the variables. In the example shown here, the category might set variables related to Player armor. To exclude variables click the **...** button in the State Data tab and use the **\<\<** and **\>\> **buttons to include and exclude variables. In this case, only armor-related variables are included. All other variables are excluded and will be removed from the grid view as they are removed. [![](/media/2016-01-29_07-28-14.gif)](/media/2016-01-29_07-28-14.gif)

### Excluding Variables Prevents Accidental Assignment

Excluding variables has two benefits:

1.  Simplifies the grid so only relevant variables are displayed
2.  Removes unnecessary assignment of variables when a state is set

The first benefit is visibly obvious but the second benefit is more subtle. To see the effect of excluding variables, consider the example shown above before variables are excluded. FlatRedBall would generate the following code. Notice the Armor class includes properties related to the weapon as well as X,Y, and Z values for positioning the player:

    public class Armor
    {
        public string Name;
        public float X;
        public float Y;
        public float Z;
        public int WeaponValue;
        public int ArmorValue;
        public int MovementRange;
        public string PlayerSpriteTexture;
        public string WeaponSpriteTexture;
        public int WeaponDamage;
        public int WeaponRange;
        ...

Also the CurrentArmorState property setter assigns these values as shown in the following code snippet:

    public Entities.Player.Armor CurrentArmorState
    {
        get
        {
            return mCurrentArmorState;
        }
        set
        {
            mCurrentArmorState = value;
            if (this.Parent == null)
            {
                X = value.X;
            }
            else
            {
                RelativeX = value.X;
            }
            if (this.Parent == null)
            {
                Y = value.Y;
            }
            else
            {
                RelativeY = value.Y;
            }
            if (this.Parent == null)
            {
                Z = value.Z;
            }
            else
            {
                RelativeZ = value.Z;
            }
            WeaponValue = value.WeaponValue;
            ArmorValue = value.ArmorValue;
            MovementRange = value.MovementRange;
            PlayerSpriteTexture = GetFile(value.PlayerSpriteTexture) as Microsoft.Xna.Framework.Graphics.Texture2D;
            WeaponSpriteTexture = GetFile(value.WeaponSpriteTexture) as Microsoft.Xna.Framework.Graphics.Texture2D;
            WeaponDamage = value.WeaponDamage;
            WeaponRange = value.WeaponRange;
        }
    }

This state will likely cause a bug since it assigns the position of the Player and may unintentionally alter weapon-related values. Therefore, excluding these variables is important to keep the game behaving as intended.

## State Categories as StateData

StateData is the concept of treating states similar to CSV data. Glue supports treating States as CSV data by providing a CSV-like interface when selecting a category, as shown in the following image:

![](/media/2020-06-img_5ee783d044f32.png)

For an in-depth discussion of State Data, including how to exclude variables from inclusion, see the [State Data blog post](/news/introducing-state-data.md).

## SharesVariablesWithOtherCategories

The SharesVariablesWithOtherCategories controls whether the State Category shares variables with other categories. This value is false by default. If you set the value to, then the only purpose of the category is organizational in Glue - all states contained in the category will behave the same as if they were not contained in any category. If this value is set to false, then the category will be treated separate from other categories and from uncategorized states. This means that the category:

-   Will create a separate enum value
-   Will create a separate property of this enum type in the given Screen/Entity
-   Will create [InterpolateToState](/frb/docs/index.php?title=Glue:Reference:States:InterpolateToState "Glue:Reference:States:InterpolateToState") and InterpolateBetween functions for this enum type
-   Will allow exposing and tunneling of a new variable type in Glue
-   Will allow setting the new category state in GlueView
