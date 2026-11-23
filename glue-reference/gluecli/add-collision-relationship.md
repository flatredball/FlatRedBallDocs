# add-collision-relationship

### Introduction

`add-collision-relationship` adds a collision relationship to a screen, the way the **Add** button in an object's **Collision** tab does. It picks the same name (`PlayerBallVsGoal`, numbered if taken), puts the objects in the same order, and uses the same defaults. Options set the physics and other settings in the same run.

Each object is a top-level object in the screen that can collide:

* an instance of an entity that implements `ICollidable`
* a list of such entities
* a `ShapeCollection`
* a `TileShapeCollection`

A list can collide with itself. The first object of a relationship must be an entity or a list, so if you pass a `ShapeCollection` or `TileShapeCollection` as `--first`, it becomes the second object, as in the editor.

To change a relationship later, use `set-collision-property`, described below.

### Usage

```
GlueCli add-collision-relationship <project> --element <element> --first <object> --second <object> [options]
```

### Options

| Option | Description |
|--------|-------------|
| `--element <element>` | Screen to add the relationship to. Required. |
| `--first <object>` | First object. Required. |
| `--second <object>` | Second object. Required. |
| `--name <name>` | Relationship name. Turns off auto-naming. Default: the editor's auto name. |
| `--type <type>` | Collision physics: `none`, `move`, `move-soft`, `bounce`, `platformer`, `platformer-cloud`, `delegate` or `stacking`. Default: `none`, or `bounce` (`platformer` for a platformer entity) against a `TileShapeCollection`. |
| `--first-mass <number>` | First object's mass for move and bounce. Default: 1. |
| `--second-mass <number>` | Second object's mass for move and bounce. Default: 1. |
| `--elasticity <number>` | Bounce elasticity. Default: 1. |
| `--soft-coefficient <number>` | Soft collision coefficient, for `move-soft`. Default: 1. |
| `--apply-physics <true\|false>` | Apply the physics automatically. `false` only detects the collision. Default: `true`. |
| `--active <true\|false>` | Whether the relationship is active when the screen starts. Default: `true`. |
| `--collision-limit <limit>` | List vs list: `All`, `First` or `Closest`. Default: `All`. |
| `--list-vs-list <mode>` | List vs list: `PreventDoubleChecksPerFrame` or `AllowDoubleChecksPerFrame`. |
| `--first-sub <shape>` | Collide only this shape of the `--first` object's entity. |
| `--second-sub <shape>` | Collide only this shape of the `--second` object's entity. |
| `--in-derived-screen` | Add the relationship even though the screen derives from `GameScreen`. Without it, the run fails, because relationships usually go in `GameScreen`. |
| `--json` | Print one JSON object to stdout instead of text. |

### Examples

Make the balls in Beefball bounce off the goals:

```
GlueCli add-collision-relationship Beefball --element GameScreen --first PlayerBallList --second GoalList --type bounce --first-mass 0 --elasticity 0.5
```

```
Added PlayerBallVsGoal2 (PlayerBallList vs GoalList, BounceCollision) in Screens\GameScreen.
  masses 0 / 1, elasticity 0.5, apply physics true, active true
  sub-collisions (none) / (none), collision limit All, auto name true
Files written (2):
  Screens/GameScreen.Generated.cs
  Screens/GameScreen.glsj
No new errors.
```

`GameScreen` already has `PlayerBallVsGoal`, so the new one is `PlayerBallVsGoal2`.

Give the relationship your own name. `Walls` is a `ShapeCollection`, so it becomes the second object:

```
GlueCli add-collision-relationship Beefball --element GameScreen --first Walls --second PuckList --name PuckHitsWalls
```

```
Added PuckHitsWalls (PuckList vs Walls, NoPhysics) in Screens\GameScreen.
  masses 1 / 1, elasticity 1, apply physics true, active true
  sub-collisions (none) / (none), collision limit All, auto name false
  PuckList is first: the first object must be an entity or a list.
```

### JSON Output

`edit` holds `{element, name, first, second, collisionType, sourceClassType, swapped, settings}`.

* `swapped` is true when `--first` and `--second` changed places.
* `settings` holds every setting of the relationship, by the name `set-collision-property` takes.

### Failure

The run exits with code 1 and saves nothing when an object does not exist or cannot collide, neither object is an entity or a list, an entity instance would collide with itself, the name is taken or not valid, or a value is not valid. The message lists close matches or the valid values.

```
GlueCli add-collision-relationship Beefball --element GameScreen --first PlayerBallList --second GoalLst
```

```
Edit not applied (1):
  Screens\GameScreen has no top-level object 'GoalLst' (--second). Did you mean: GoalList? Objects that can collide: PlayerBallList, PuckList, GoalList, Walls.
1 problem(s).
```

### Changing Settings Later

`set-collision-property` changes one setting of an existing relationship, the way the **Collision** tab does. Changing an object or a sub-collision renames the relationship while its auto name is on.

```
GlueCli set-collision-property <project> --element <element> --relationship <name> --property <setting> --value <value>
```

The settings are the names in the `settings` JSON above, such as `CollisionType`, `FirstCollisionMass`, `SecondCollisionMass`, `CollisionElasticity`, `IsCollisionActive`, `FirstCollisionName`, `SecondSubCollisionSelectedItem`, `IsDealDamageChecked` and `GroundPlatformerVariableName`. `CollisionType` also takes the short names `--type` takes.

```
GlueCli set-collision-property Beefball --element GameScreen --relationship PlayerBallVsGoal2 --property CollisionType --value move
```

```
Set CollisionType of PlayerBallVsGoal2 in Screens\GameScreen: BounceCollision -> MoveCollision.
```

With `--json`, `edit` holds `{element, relationship, property, oldValue, newValue, name}`, where `name` is the relationship's name afterwards.
