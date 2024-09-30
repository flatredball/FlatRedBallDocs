# SourceFile

### Introduction

Files in Glue can support "external" or "source" files. A source file is a file which must be processed before it can be used by Glue/FlatRedBall. Source files enable using files created by 3rd-party applications to be used in FlatRedBall. For example, the source file functionality would allow you to use a .psd file (Photoshop file) as a texture file. However, for a source file to be usable, a specific program (which is often referred to as a "builder") must exist to convert the source file to a file format which is understood by Glue/FlatRedBall. For example if the source file were a .psd file, then the destination might be a .png, and a PSD to PNG builder would be needed.

### Adding a file with a source file

To add a file with a source file:

1. Right-click on the "Files" item under a Screen or entity
2. Select "Add Externally Built File"

<figure><img src="../../.gitbook/assets/migrated_media-AddExternallyBuiltFile.png" alt=""><figcaption></figcaption></figure>

### Source files require builders

Glue must be told how to convert a source file to the file type that Glue understands. To do this builders must be set up. To set up a builder, see the [article on builders](../../frb/docs/index.php).
