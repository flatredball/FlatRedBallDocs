## Introduction

Files which are added to Screens and Entities are (by default) loaded by generated code. Most files have an associated runtime type (such as PNG -\> Texture2D or SCNX -\> Scene) which can be used to access the information held in the file.

## Files create Static members

Files are automatically added as static variables to any Screen or Entity which contains them. To understand why this is the case let's consider a simple case.

Consider an Entity called Bullet which references a file called BulletImage.png. BulletImage.png is added to the Bullet Entity and creates a Texture2D named BulletImage which is a static member of the Bullet class. Since the image should be the same for all instances of each Bullet, there is no reason to create a copy of the BulletImage Texture2D for each Bullet instance.

GlobalContent is another area where files can be added. Since the user never creates an instance of GlobalContent (it's a static class) then all contained members are also static. Therefore, files which are added to GlobalContent are also static.

We've discussed Entities and GlobalContent, but what about Screens? Since only a single instance of a Screen can exist at a given time, files do not necessarily need to be static the same way that they do for Entities. However, for consistency, Screens also include all of their files as static members as well. This allows code to interact with Screens and Entities in a very similar way.
