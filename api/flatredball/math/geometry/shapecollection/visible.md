## Introduction

The Visible property allows setting the visibility of all contained shapes in a ShapeCollection. It's important to note that the ShapeCollection does not itself store any visibility data, so there is no getter for Visible. The Visible setter loops through all contained shapes and sets their Visible property accordingly.

## Code Example

The following code shows how to make a ShapeCollection invisible. It assumes that there is a ShapeCollection named ShapeCollectionInstance:

    ShapeCollectionInstance.Visible = false;
