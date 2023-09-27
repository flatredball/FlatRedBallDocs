## Introduction

If you are looking at starting a project with Glue, but would like to get a sense of how generated code in Glue works, this article will help you get a good idea of how everything in Glue works together.

## Screens and Entities

The fist thing to understand is that Glue is heavily built upon the Screen and Entity patterns. These patterns were defined and used prior to the creation of Glue. As they became more and more solid, an optimal approach to implementing each of these patterns became clear, and there was rarely a reason to deviate from these patterns. In other words, we encouraged users to write their Screen and Entity code the same way every time.

So why should programmers even have to write the same code over and over (perhaps even thousands of times across the FRB community)? We encouraged it to be the exact same in every implementation. There's really no decision making involved - it's just a repetitive task done the same every time. Why not have a tool that could write the code for you, and maybe even one that supported some options for customization. This is Glue at a basic level.

## Glue controls structure

The first thing you'll need to keep in mind is that Glue controls the structure of your application. However, if you've used FRB without Glue in the past, then you may already be familiar with this concept. Consider the Game class (usually called Game1). The two methods you generally work with are Initialize and Update. When you make FRB, or even raw XNA games for that matter, what calls these methods doesn't really matter. All that matters is that Initialize is called once at the start of execution, and Update is called once per frame. In other words, the Game class, which is the base class for Game1, is the class that controls the structure of your project, and it exposes Initialize and Update for you to fill in.

Glue works the same way. In most cases, there are only two methods you will need to worry about:

1.  CustomInitialize
2.  CustomActivity

These methods are conceptually similar to the Initialize and Update in the Game1 class: CustomInitialize is started when your Screen/Entity is first created, and CustomActivity is called once per frame.

Therefore, if you're interested in where to write your code as soon as possible, you'll want to look at the CustomInitialize and CustomActivity of your Screen or Entity.

## Partial Classes

When you create a new Screen or Entity in Glue, Glue creates two files. For this example we'll use an entity called "Player". In this case, Glue creates "Player.cs" and "Player.Generated.cs". However, both of these files define the same class: Player. The reason this is possible is because C# supports what is called "partial classes". A partial class is functionally identical to a regular class - there's really no difference at runtime. The only thing the "partial" key specifies is that the class may be defined in more than one file. In the case of Glue, this is two files, although technically you could create even more files if you wanted.

The two classes are simply used to separate generated code from hand-written code. This system allows Glue to generate code without having to parse it and determine what code it can overwrite and what code is custom code which should be preserved. Instead, Glue simply wipes and re-writes the entire .Generated.cs file whenever the matching Screen or Entity changes.

Your non-generated (custom) file can contain anything that a non-partial class could contain. You can add fields, properties, methods, events, and so on. Almost nothing is off-limits - you obviously can't do anything in the custom code that would conflict with what is in the Generated.cs file. For example, you can't inherit from another class because all Screens inherit from the Screen class and all Entities inherit from the PositionedObject class.

## The flow of Activity

As we mentioned above, the Update method is a method that is called on your Game1 class every frame automatically. If you have created your project using the FlatRedBall New Project Creator, then you will have the following call in your Game1 class:

    Screens.ScreenManager.Activity();

This line of code begins the potentially-large activity call that can happen on the current Screen. The ScreenManager, base Screen class, and the Generated code that Glue creates for any Screen is all available as open source in your project, so if you are interested in following the flow, you can do so. However, we'll skip the complex details and jump right to the Activity call in your Screen's generated code. This call is called every frame, and it contains a call to your Screen's CustomActivity. This is how your current Screen's CustomActivity is executed.

The current Screen's Activity call is also responsible for calling Activity on any Entities that have been added to the Screen in Glue. Just like Screens, Entities have an Activity call which calls the given Entity's CustomActivity method.

Therefore, both Screens and Entities which have been added through Glue will automatically have their CustomActivity method called every frame. You don't have to do anything to make this happen.

## CustomInitialize

The CustomInitialize works very similarly to the CustomActivity method in that it is automatically called by the structure set up in Glue. Every Screen and Entity will have their CustomInitialize methods called when first created.

## What about CustomDestroy?

CustomDestroy is a useful method, but one that is not used in every Screen or Entity. This method provides an opportunity for you to remove anything that you've added to the engine in your custom code. You do not need to remove objects that have been added through Glue - Glue will take care of that for you. However, if you create a Sprite through the SpriteManager in your CustomActivity method, then you will need to remove it in CustomDestroy.

## ...and what about CustomLoadStaticContent?

The CustomLoadStaticContent method is a method that you can use to load content that is going to be shared across multiple instances of the same type of Entity, or to load content that is going to be used in CustomInitialize. In short, usually the only code that goes in CustomLoadStaticContent is calls to FlatRedBallServices.Load. This method is called asynchronously if you are using loading Screens (covered in a later tutorial), so that means you should not add any objects to the Engine in this method.
