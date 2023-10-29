## Introduction

The AddUnloadMethod allows you add custom logic to be executed when a ContentManager is unloaded. This is most often used to null-out static references to content contained in a particular ContentMangaer. This functionality is used heavily in Glue generated code, but it can also be used to null-out static objects in custom code.

## Code Example

The following code shows how to create a static Texture2D in custom code, and how to properly unload it. This code would be part of the custom code of a Screen or Entity. For this example we'll assume an Entity called Character.

    // At class scope
    static Texture2D mCustomTexture;

    // In CustomInitialize:
    if(mCustomTexture == null)
    {
       mCustomTexture = FlatRedBallServices.Load("TextureName.png", ContentManagerName);
       ContentManager contentManager = FlatRedBallServices.GetContentManagerByName(ContentManagerName);
       contentManager.AddUnloadMethod("CustomUnloadForCharacter", CustomUnloadStaticContent);
    }

    // Finally define the CustomUnloadStaticContent method
    static void CustomUnloadStaticContent()
    {
        mCustomTexture = null;
    }
