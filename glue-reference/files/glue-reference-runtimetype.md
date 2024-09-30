# RuntimeType

The RuntimeType property controls the type that contains the data loaded from a given file when the game is running. Some types, such as .wav files, can be loaded into multiple runtime types such as `SoundEffect` and `SoundEffectInstance`.

### Automatic RuntimeType Selection

If you are adding a new file using the Add File window, the runtime type is displayed in the window. For example, notice that a Texture is created (Texture2D in code) when selecting a .png file type.

When a new file is added, the RuntimeType is automatically selected.

<figure><img src="../../.gitbook/assets/image (333).png" alt=""><figcaption><p>Texture type in the new file window</p></figcaption></figure>

Similarly, if a new PNG is added by drag+dropping the file into the FRB editor, the runtime type is selected automatically based on the file's extension. Usually this does not need to be changed.

<figure><img src="../../.gitbook/assets/image (334).png" alt=""><figcaption><p>MyFile loaded as a Texture2D</p></figcaption></figure>

The selected runtime type ultimately controls the type of the property created in the Screen, Entity, or Global Content. For example, MyFile.png is loaded as a Texture2D as shown in the following screenshot of Visual Studio:

<figure><img src="../../.gitbook/assets/image (335).png" alt=""><figcaption><p>MyFile in generated code</p></figcaption></figure>

{% hint style="info" %}
Files may be loaded as fields or properties depending on properties assigned on the file in the FRB Editor.
{% endhint %}

### Changing RuntimeType

RuntimeTypes can be changed through the dropdown in the Properties window. FlatRedBall provides options for the file according to its extension.

Some file types may only have a single RuntimeType associated with the extension.

<figure><img src="../../.gitbook/assets/image (336).png" alt=""><figcaption><p>RuntimeType for .png file</p></figcaption></figure>

Other types may provide multiple runtime types, such as SoundEffect and SoundEffectInstance for .wav files.

<figure><img src="../../.gitbook/assets/image (337).png" alt=""><figcaption><p>RuntimeType for .wav file</p></figcaption></figure>

{% hint style="info" %}
FlatRedBall provides standard RuntimeTypes for many extensions, but plugins can add additional runtime types. You can even create your own plugins to load your files into types that are not supported by FlatRedBall out of the box.
{% endhint %}

RuntimeType should not be changed through the dropdown if the file is a wildcard file. To change the runtime type, the edit must be performed in the .gluj file for global content. Be careful, you must assign a type that is understood by FRB or currently-loaded plugins.



