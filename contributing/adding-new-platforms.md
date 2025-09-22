# Adding New Platforms

## Introduction

This guide provides instructions for adding a new platform. This could include a new .NET version (such as going to .NET 10) or it could be a new runtime (such as KNI).

## 1. Adding a Template

To add a new template, open the Templates folder and copy an existing template, or add a new project from scratch. Note that the Game1 will get copied over so the contents of Game1 do not matter, and should not differ per platform. If certain platforms (like iOS) require custom code in Game1, you need to add #if blocks.

## 2. Modifying Game1Copier

todo...

## 3. Modifying BuildServerUploader

todo...

## 4. Modifying Glue
