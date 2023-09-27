## Introduction

This page is a high-level overview of the technology and community features that FlatRedBall offers. Please note that FlatRedBall is under continual development so the information contained in this page is subject to change. This information is intended to give you a very broad view of FlatRedBall technology. For information about how to use FlatRedBall for game projects, please see our.

## FlatRedBall Components

The following is a list of the components of FlatRedBall. Each component will be discussed in detail below:

-   FlatRedBall Game Engines - A collection of game engines built around .NET, C#, and various graphical APIs enabling FlatRedBall to run on a variety of platforms.
-   FRBDK - A set of graphical [WYSIWYG (what you see is what you get)](http://en.wikipedia.org/wiki/WYSIWYG) applications designed to create general-purpose XML data which can be easily loaded in to FlatRedBall applications.
-   Glue - A high-level application designed to simplify the creation and loading of FRBDK data and to improve the development speed of teams.
-   Templates - A set of code and Visual Studio project files which provide a fully-working start for new projects.
-   Wiki/Documentation - Information about FlatRedBall, often in tutorial form which can be read start-to-finish.
-   Forums - Years of searchable posts about all topics of FlatRedBall development
-   Chat - An immediately-loading chat room available on our front page to strengthen the FlatRedBall community.

## FlatRedBall Game Engines

The FlatRedBall game engines are libraries (of the file type .dll) which can be included in Visual Studio projects to enhance game development. FlatRedBall game engines can run on the following platforms:

-   PC
-   Xbox 360
-   Windows Phone 7
-   iOS
-   Windows 8 (Windows Store app)
-   Browser (through Silverlight)

Functionality provided by these engines include:

-   Graphical objects which automatically update and render to the screen
-   Collision and physics systems
-   Text rendering
-   Content loading and unloading
-   Attachment and object grouping logic
-   Input (mouse, keyboard, game pad, touch screen)
-   User interface logic (clicking, cursor logic, events)
-   Standard content formats (used by the FRBDK)
-   File IO

## FRBDK

The FRBDK is a collection of tools which create standard XML file formats which can be loaded by the FlatRedBall game engines and which are also understood by Glue. The following tools are available in the FRBDK:

-   AIEditor - a tool for creating node networks. Node networks are useful for AI navigation through complex areas.
-   AnimatoinEditor - a tool for creating sprite animations (flipping of textures as well as sprite sheets).
-   ParticleEditor - a tool for creating particle emitters.
-   PolygonEditor - a tool for creating 2D and 3D collision areas/volumes useful for defining playable areas and triggers.
-   SplineEditor - a tool for creating curved splines in 3D space.
-   SpriteEditor - a tool for creating general-purpose graphical scenes.

## Glue

Glue is a powerful tool used to simplify and standardize FlatRedBall game development. Glue is intended to automate code which most game development teams write over and over. This automation provides the following benefits:

-   Frees up the development team to work on meaningful tasks.
-   Eliminates human error.
-   Reflects best practices which have been developed over dozens of projects.
-   Represents concepts in an easy-to-understand graphical interface as opposed to being included in code.

Glue features include:

-   Fast creation and automatic management of content files.
-   "Screens" and "Entities" which are standard containers of logic, content, and often represent easy-to-understand game objects.
-   Advanced content loading code eliminating memory leaks, reducing game freezes, and enabling users to easily select when to load content during a loading screen.
-   Immediate visualization of game layout using GlueView.
-   Abstraction of variables and objects enabling teams to refactor with minimal impact on existing projects.
-   Common object types such as "window" to enable adding behavior to existing objects quickly
-   File-watching for automatic updates when content files change.
-   Plugin system to allow the community to extend functionality, to create game-specific functionality, and to increase the feature set without creating inter-dependencies between components.

## Templates

Templates are projects which Glue can customize to enable users to quickly create new projects. Templates are also used extensively for testing functionality in isolated projects. These can help eliminate noise when the source of a bug isn't evident.

## Wiki/Documentation

The wiki provides an extensive pool on information about all other parts of FlatRedBall. It is a continually growing collection of articles decided for beginners and experienced developers alike. Information is generally split into tutorial/how-to sections for users who are just getting started in a particular area of development, as well as reference sections for experienced developers who know specifically the kind of information they need.

Since all documentation is in the form of a wiki it is very easy to edit by the FlatRedBall staff and it is often changing in response to feedback from FlatRedBall users.

## Forums

The forums provide a rich history of question/answer information for users. It can be searched easily to find questions and answers for particular topics, and new questions can quickly be asked.

The wiki is organized into topics such as engine, FRBDK, math questions, general development questions, and community-based sections where users can show off their projects and ask others to join their team.

## Chat

The chat room is immediately available when visiting [www.flatredball.com]() It requires no login - users immediately enter the chat room as one would enter the lobby of a building.

The intent is to encourage users to ask questions openly, help one another, and to supplement what may seem like confusing navigation to new users. Many users have been helped by the chat room since it was originally added.
