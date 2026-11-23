# add-entity

### Introduction

`add-entity` adds an entity with the options of the editor's **Add Entity** dialog. It creates the same files, generates the same code, and plugins react the same way.

Defaults match the dialog:

* A factory (`CreatedByOtherEntities`) is created, unless you pass `--no-factory`.
* A list of the entity is added to GameScreen and to every screen with a tile map, unless you pass `--no-list`.
* A shape (`--circle`, `--rectangle`, `--polygon`) makes the entity ICollidable, unless you pass `--no-icollidable`. `--idamageable`, `--idamage-area`, `--platformer` and `--top-down` also make it ICollidable.

With `--base`, the entity inherits from another entity. As in the dialog, only `--folder` and the factory option apply. Shapes, interfaces, lists and movement come from the base.

### Usage

```
GlueCli add-entity <project> --name <name> [--folder <folder>] [--base <entity>] [options]
```

### Options

| Option | Description |
|--------|-------------|
| `--name <name>` | Entity name without folders, such as `Enemy`. Required. |
| `--folder <folder>` | Folder under `Entities`, such as `Enemies` or `Enemies\Bosses`. Created if it does not exist. Default: `Entities` itself. |
| `--base <entity>` | Entity to inherit from, such as `Enemy` or `Entities\Enemy`. |
| `--sprite` | Add a Sprite named `SpriteInstance`. |
| `--text` | Add a Text named `TextInstance`. |
| `--circle` | Add a Circle named `CircleInstance`. |
| `--rectangle` | Add an AxisAlignedRectangle named `AxisAlignedRectangleInstance`. |
| `--polygon` | Add a square Polygon named `PolygonInstance`. |
| `--icollidable` | Implement ICollidable. |
| `--no-icollidable` | Do not implement ICollidable, even with a shape. |
| `--ivisible` | Implement IVisible. The dialog does not show this option. |
| `--iclickable` | Implement IClickable. The dialog does not show this option. |
| `--iwindow` | Implement IWindow, which also implements IVisible. The dialog does not show this option. |
| `--idamageable` | Implement IDamageable (takes damage). |
| `--idamage-area` | Implement IDamageArea (deals damage). |
| `--team-index <index>` | TeamIndex for `--idamageable` or `--idamage-area`. Default: 0. |
| `--opposing-team-collision` | With `--idamageable` or `--idamage-area`, add damage collision relationships in GameScreen against lists of entities on other teams. |
| `--no-factory` | Do not create a factory. |
| `--no-list` | Do not add a list of this entity to GameScreen and tile map screens. |
| `--platformer` | Give the entity platformer movement. |
| `--top-down` | Give the entity top-down movement. |
| `--json` | Print one JSON object to stdout instead of text. |

### Example

Add a Coin entity with a Circle and a Sprite:

```
GlueCli add-entity Beefball --name Coin --circle --sprite
```

```
Added entity Entities\Coin (ICollidable, factory). Objects: SpriteInstance, CircleInstance. Added to screens: Screens\GameScreen.CoinList.
Files written (24):
  Beefball.csproj
  Beefball.gluj
  Entities/Coin.cs
  Entities/Coin.Generated.cs
  Entities/Coin.glej
  Factories/CoinFactory.Generated.cs
  Screens/GameScreen.glsj
  ...
No new errors.
```

The entity got a factory and a CoinList in GameScreen, because those are the dialog's defaults.

### JSON Output

`edit` holds `{name, baseEntity, objects, implementsICollidable, implementsIVisible, implementsIClickable, implementsIWindow, implementsIDamageable, implementsIDamageArea, createdByOtherEntities, movement, addedToScreens}`.

* `objects` lists the entity's own object names.
* `movement` is `Platformer`, `TopDown` or null.
* `addedToScreens` lists the objects added to screens, such as `Screens\GameScreen.CoinList`.

### Failure

The run exits with code 1 and saves nothing when the name is invalid or already used by an entity, screen or file, the folder name is invalid, or the base entity does not exist. The message lists close matches.

```
GlueCli add-entity Beefball --name Coin
```

```
Edit not applied (1):
  'Coin' is not a valid entity name: There is already an entity named Coin
1 problem(s).
```
