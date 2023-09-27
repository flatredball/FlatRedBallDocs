## Introduction

The FromList method will create a RuntimeCsvRepresentation according to the object passed to it. This method can be used to generate a RuntimeCsvRepresentation which can be saved to disk to create a CSV.

## Example Code

The following code will create a RuntimeCsvRepresentation from a list of Vector3's:

    List<Vector3> listOfVectors = new Vector3();
    listOfVectors.Add(new Vector3(0,0,0));
    listOfVectors.Add(new Vector3(1,2,3));
    listOfVectors.Add(new Vector3(4.2f,1,1f,3.3f));

    RuntimeCsvRepresentation rcr = RuntimeCsvRepresentation.FromList(listOfVectors);

![RcrFromVector3.PNG](/media/migrated_media-RcrFromVector3.PNG)

## XmlIgnore

The FromList method will ignore any fields or properties which have the [XmlIgnore](http://msdn.microsoft.com/en-us/library/system.xml.serialization.xmlattributes.xmlignore.aspx) attribute. This allows objects which are built for XmlSerialization to serialize the same using RuntimeCsvRepresentations.
