# JSON (.json)

### Introduction

JSON files can be added to FlatRedBall projects. JSON files are treated as content and their membership in the game's .csproj is automatically managed by FlatRedBall, but they must be manually loaded in code. JSON files can be used to store _definition data_ - data which is defined during the development of a game and which does not change while the game is running. Examples of game definition data incude

* Weapon damage, cost, rarity, and description text
* Enemy health, movement speed, and experience awarded
* Level difficulty rating, preview image name, and description text

JSON can also be used to store game progress or game settings, but these files are usually created and loaded during runtime so they are not added to the FlatRedBall Editor.

### JSON vs Comma Separated Values

Both JSON and Comma Separated Value files can be used to store data. JSON data provides more flexibility and also can integrate with more standardized deserializers such as JSON.net and System.Text.Json. However, due to this flexibility FlatRedBall does not automatically generate classes for deserialization. You must create your own to load a JSON file.

Ultimately both JSON and Comma Separated Values can be used to store and load definition data, so usage often comes down to developer familiarity.

### Example - Loading JSON Definition Data

The first step in loading a JSON file is to define either the JSON or the desired C# class for JSON. You can start with either depending on which you are more familiar with.

#### C#-First

If you are more familiar writing C#, then you can define your class and create a simple example object which can be used to create your JSON. For example, the following code could be used to define definition data for enemies in a game:

```csharp
class EnemyDefinition
{
    public string Name { get; set; }
    public decimal HealthPoints { get; set; }
    public int ExperienceAwarded { get; set; }
    public int GoldAwarded { get; set; }
}

class EnemyData
{
    public List<EnemyDefinition> Data { get; set; }

    public EnemyData()
    {
        Data = new List<EnemyDefinition>();

        var enemy1 = new EnemyDefinition();
        enemy1.Name = "Goblin";
        enemy1.HealthPoints = 10;
        enemy1.ExperienceAwarded = 20;
        enemy1.GoldAwarded = 1;

        Data.Add(enemy1);

        var enemy2 = new EnemyDefinition();
        enemy2.Name = "Dragon";
        enemy2.HealthPoints = 80;
        enemy2.ExperienceAwarded = 55;
        enemy2.GoldAwarded = 12;

        Data.Add(enemy2);
    }
}
```

Notice that EnemyData includes a constructor which populates the Data list - this is only being done temporarily to obtain valid JSON. You can use similar code to obtain a valid data object which can be used to create JSON. You can either add this code to a C# console project and serialize the JSON, or you can use an online tool such as [https://csharp2json.azurewebsites.net/](https://csharp2json.azurewebsites.net/)

{% hint style="info" %}
Be sure to delete the constructor which populates the Data list after you have created your JSON file. Leaving this code in may result in additional data when loading your JSON.
{% endhint %}

The output JSON might look similar to the following text:

```json
{
  "data": [
    {
      "name": "Goblin",
      "healthPoints": 10.0,
      "experienceAwarded": 20,
      "goldAwarded": 1
    },
    {
      "name": "Dragon",
      "healthPoints": 80.0,
      "experienceAwarded": 55,
      "goldAwarded": 12
    }
  ]
}
```

#### JSON-First

if you are more familiar writing JSON text first, you can write this JSON and use online converters to create C# classes. For example, the code above could be used on the website [https://json2csharp.com/](https://json2csharp.com/) to produce the following C# classes:

```csharp
public class Datum
{
  [JsonProperty("name")]
  public string Name { get; set; }

  [JsonProperty("healthPoints")]
  public double HealthPoints { get; set; }

  [JsonProperty("experienceAwarded")]
  public int ExperienceAwarded { get; set; }

  [JsonProperty("goldAwarded")]
  public int GoldAwarded { get; set; }
}

public class Root
{
  [JsonProperty("data")]
  public List<Datum> Data { get; set; }
}
```

Notice that the generated C# does not include names like Enemy and EnemyData so you may need to make modifications to the generated C# to make it more expressive.

#### Adding JSON to FlatRedBall

Once you have created a JSON file and a C# file, you can add the JSON to FlatRedBall. JSON files can be added to any location - Global Content, Screen Files, or Entity files. Since you will be performing the loading in custom code, the only difference between these locations is organization. JSON data tends to be relatively small compared to other game data (such as textures and audio), so adding it to Global Content is usually preferred.

To add a JSON file to your project:

1. Save the file to disk in its desired location, such as your game's content folder ( `Content\GlobalContent` )
2. Drag+drop the file into the Global Content Files in the FlatRedBall Editor

<figure><img src="../../../.gitbook/assets/01_04 55 05.gif" alt=""><figcaption><p>Drag+drop the JSON file into its desired location, such as Global Content Files</p></figcaption></figure>

{% hint style="info" %}
The steps above ultimately add the JSON file to your .csproj file. If you are comfortable adding this file manually (such as through Visual Studio, Rider, or Visual Studio Code), you can do so through your IDE rather than using FlatRedBall. Ultimately, the only thing that matters is that the file ends up in the built directory.
{% endhint %}

Now the file is part of your project, so you can load it in your custom code. For example, the following code could be used to load the data in Game1.cs:

```csharp
var jsonContents = FlatRedBall.IO.FileManager.FromFileText(
    "Content/GlobalContent/EnemyData.json");

// This uses JSON.NET but you can also use System.Text.Json:
var enemyData = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyData>(
    jsonContents);
```

The contents of the JSON are loaded using FromFileText. For more information, see the [FileManager.FromFileText](../../../api/flatredball/io/filemanager/fromfiletext.md) page.

We can add a breakpoint to verify that enemyData contains the data we added to our JSON file:

<figure><img src="../../../.gitbook/assets/image (368).png" alt=""><figcaption><p>enemyData shown in the Visual Studio variable watch window</p></figcaption></figure>
