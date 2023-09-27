## Introduction

The XmlDeserialize function is a function that can load a XML file and create a runtime object out of it. You must have an object that matches a given XML's format to properly deserialize an XML into an instance you can use at runtime. The XmlDeserialize method uses System.Xml.Serialization.XmlSerializer internally, but this provides a convenient way to deserialize objects with one call. XmlDeserialize uses the [FileManager's RelativeDirectory](/frb/docs/index.php?title=FlatRedBall.IO.FileManager.RelativeDirectory.md "FlatRedBall.IO.FileManager.RelativeDirectory") when given relative paths to deserialize.

## Code Example

For an example on how XmlDeserialize works, see XmlSerialize: http://flatredball.com/documentation/api/flatredball/flatredball-io/flatredball-io-filemanager/flatredball-io-filemanager-xmlserialize/
