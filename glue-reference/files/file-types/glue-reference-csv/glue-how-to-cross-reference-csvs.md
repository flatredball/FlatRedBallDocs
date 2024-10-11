# Cross Referencing CSVs

### Introduction

CSVs are often used to define data for games, but it's common for one CSV to need to reference information from another CSV. This tutorial will walks you through creating two CSVs, with one referencing the other.

### Overview

We will be creating two CSVs:

1. The first defines the weapons in your game. The weapons defined for this game are for a traditional RPG.
2. The second will define the shops in the game which will contain a list of the weapons which they can sell.

### Creating the CSVs

First we'll create a CSV for weapons called WeaponInfo:

1. Right-click on Globa lContent Files
2. Select "Add File"->"New File"
3. Select "Spreadsheet (.csv)" as the type
4. Enter the name "WeaponInfo" as the new file's name
5. Click OK

Next create the CSV for StoreInfo:

1. Right-click on Global Content Files
2. Select "Add File"->"New File"
3. Select "Spreadsheet (.csv)" as the type
4. Enter the name "StoreInfo" as the new file's name
5. Click OK

You should now have 2 CSVs in your Global Content Files uner Global Content Files:

<figure><img src="../../../../.gitbook/assets/migrated_media-TwoCsvsCrossReference1.PNG" alt=""><figcaption><p>StoerInfo.csv and WeaponInfo.csv</p></figcaption></figure>

### Filling WeaponInfo CSV

Fill the WeaponInfo file so it appears as follows:

| Name (string, required) | Damage (float) |
| ----------------------- | -------------- |
| Sword                   | 3              |
| Spear                   | 4              |
| Dagger                  | 2              |

### Filling StoreInfo CSV

Fill the StoreInfo so it appears as follows:

| Name (string, required) | WeaponTypes (List\<string>) |
| ----------------------- | --------------------------- |
| CapitalCity             | Sword                       |
|                         | Spear                       |
| SouthCity               | Dagger                      |
|                         | Spear                       |

Note that the StoreInfo CSV file uses a List\<string> instead of a List\<WeaponInfo> for the WeaponTypes it contains. Specifically the StoreInfo references the Name of the WeaponInfo, similar to a key in a database.

### Adding a StoreInfo partial class

Next we'll need to write some simple code to associate the values in the WeaponTypes column in the StoreInfo CSV to the weapons defined in WeaponInfo.csv. To do this:

* Open your project in Visual Studio
* Expand the "DataTypes" folder in the Solution Explorer
* Right-click on the "DataTypes" folder and select "Add"->"Class..."
* Name the class "StoreInfo". This should be the same name as your CSV.

You should now have a file called StoreInfo.cs and a file called StoreInfo.Generated.cs

<figure><img src="../../../../.gitbook/assets/migrated_media-ItemsUnderDataTypes.PNG" alt=""><figcaption><p>Newly-created StoreInfo.cs file</p></figcaption></figure>

Next, open the newly-created StoreInfo.cs file and make it a "public partial" class. After you do this, your code should look like:

```csharp
public partial class StoreInfo
{
}
```

Finally save your project through the "File"->"Save All" option in Visual Studio. This saves changes to the project so that if the FRB Editor is open it will reload the changes.

### Adding the "Weapons" property to StoreInfo

Next we'll add a property to the StoreInfo.cs file to make it more convenient to access which WeaponInfo's a Store contains. To do this, add the following code to **StoreInfo.cs**:

```
public IEnumerable<WeaponInfo> Weapons
{
    get
    {
        foreach (var weaponType in this.WeaponTypes)
        {
            yield return GlobalContent.WeaponInfo[weaponType];
        }
    }
}
```

Now each ScreenInfo which is loaded into GlobalContent has an IEnumerable of WeaponInfo's that can be used to populate UI, menus, and drive game logic.
