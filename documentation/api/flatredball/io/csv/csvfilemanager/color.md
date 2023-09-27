## Introduction

The CsvFileManager supports cells that contain color values. Color values can be specified either by standard name or can be custom defined by components (as shown below).

## Defining a Color in CSV

The following shows how to define Colors in a CSV file:

|          |                                            |
|----------|--------------------------------------------|
| CarName  | PaintColor (Microsoft.Xna.Framework.Color) |
| Mustang  | White                                      |
| Elantra  | Green                                      |
| Corvette | A=255,R=0,G=27,B=128                       |
| Camry    | A=255, R=255,G=0,B=100                     |

The first two cars (Mustang and Elantra) are defined using standard color names. These names match the XNA Color names. The second two colors are custom colors created by setting the Red, Green, Blue, and Alpha components. The XNA Color struct uses 0 - 255 values for these components so keep that in mind when defining colors in CSV values.
