# Adding New Platforms

## Introduction

This guide provides instructions for adding a new platform. This could include a new .NET version (such as going to .NET 10) or it could be a new runtime (such as KNI).

## 1. Adding a Template

To add a new template, open the Templates folder and copy an existing template, or add a new project from scratch. Note that the Game1 will get copied over so the contents of Game1 do not matter, and should not differ per platform. If certain platforms (like iOS) require custom code in Game1, you need to add #if blocks.

## 2. Modifying Game1Copier

Open Game1Copier.sln and find Program.cs.

Add information about the newly-created template to the templates list. Rebuild the project, then copy the built .exe to root Templates folder so the new template is copied.

## 3. Modifying BuildServerUploader

Open BuildServerUploader.cs and modify AllData.cs to add the new engine.

## 4. Modifying Glue

Update EmptyTemplates.cs to include the new template.

## 5. Update Engine.yml

Add the NuGet package building steps
