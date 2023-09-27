## Introduction

The ReferencedFileSave class is a common class in Glue - every Screen and Entity contains a list of ReferencedFileSaves. Every file added to Glue will create a ReferencedFileSave.

## Name

The Name property on the ReferencedFileSave is the name of the file relative to the project's content folder. Since different project types treat the content folder differently, the best way to identify the absolute file name is to use the ProjectManager:

    bool forceAsContent = true;
    string absoluteFileName = ProjectManager.MakeAbsolute(namedObjectInstance.Name, forceAsContent);
