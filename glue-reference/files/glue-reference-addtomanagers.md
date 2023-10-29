## Introduction

The AddToManagers property controls whether a file is added to managers.

## Common Usage

This property defaults to true, but is most often set to false on files in Screens if you do not want the file to be "active" by default. For example, if a .mp3 file has its AddToManagers set to false, it will not begin playing automatically when the Screen is created.

## Specific File Type Discussions

-   .scnx - AddToManagers controls whether the contained Scene's objects are automatically added to the appropriate managers. If AddToManagers is set to false, then the Scene will not be rendered.
