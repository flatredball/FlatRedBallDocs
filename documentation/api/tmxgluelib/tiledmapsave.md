## Introduction

The TiledMapSave class is a file which can deserialize from TMX or used to serialize back to TMX. Note that this class attempts to match the TMX file but at the time of this writing it does not contain all of the functionality. Note that most games do not need to work with the TiledMapSave object - it is used internally in generated code to load TMX files automatically when a TMX file is added to Glue. Games may need to load TMX files to a TiledMapSave object to perform custom programmatic customization.

## Loading TMX

The FromFile method is used to load a TMX file into a TiledMapSave instance. The following code can be used to load a TMX file:

    var tiledMapSave = TiledMapSave.FromFile("content/MyTmx.tmx");

   
