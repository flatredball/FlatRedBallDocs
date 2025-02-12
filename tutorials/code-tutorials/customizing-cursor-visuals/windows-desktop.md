# Windows Desktop

### Introduction

Windows Desktop games can display custom cursors. The default XNA window is a Windows Forms window, so customization of the cursor visuals is done the same as for any other Windows Forms app.

### Example Code - Changing the Cursor using MonoGame

MonoGame 3.6 and newer introduces a method for changing the Windows cursor. The cursor can be set from a Texture2D. Assuming CursorTexture is a valid Texture2D:

```csharp
FlatRedBallServices.Game.IsMouseVisible = true;

int originX = 0;
int originY = 0;

MouseCursor customCursor = MouseCursor.FromTexture2D(CursorTexture, originX, originY);
Mouse.SetCursor(customCursor);
```

For more information, see the following links:

* [https://docs.monogame.net/api/Microsoft.Xna.Framework.Input.Mouse.html#Microsoft\_Xna\_Framework\_Input\_Mouse\_SetCursor\_Microsoft\_Xna\_Framework\_Input\_MouseCursor\_](https://docs.monogame.net/api/Microsoft.Xna.Framework.Input.Mouse.html#Microsoft_Xna_Framework_Input_Mouse_SetCursor_Microsoft_Xna_Framework_Input_MouseCursor_)
* [https://docs.monogame.net/api/Microsoft.Xna.Framework.Input.MouseCursor.html](https://docs.monogame.net/api/Microsoft.Xna.Framework.Input.MouseCursor.html)

### Example Code - Changing the Cursor using Windows Forms and .cur File

{% hint style="info" %}
This approach only worked with the original XNA engine, and may work in the future if FRB adds support for MonoGame DirectX. This does not work with DesktopGL projects.
{% endhint %}

The following code loads a .cur file and sets the window's default cursor:

```csharp
var cursor = new System.Windows.Forms.Cursor("Content/GlobalContent/Cursor.cur");
System.Windows.Forms.Form asForm =
    (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
asForm.Cursor = cursor;
```

### Example Code - Changing the Cursor using Windows Forms and .png File

{% hint style="info" %}
This approach only worked with the original XNA engine, and may work in the future if FRB adds support for MonoGame DirectX. This does not work with DesktopGL projects.
{% endhint %}

.cur files have a 32x32 pixel size limit. This can be bypassed by loading a .png into a Bitmap object, then using that object to construct a Cursor, as shown in the following code:

```csharp
// code obtained from StackOverflow, as posted by user "Nick"
// http://stackoverflow.com/questions/550918/change-cursor-hotspot-in-winforms-net
public struct IconInfo
{
    public bool fIcon;
    public int xHotspot;
    public int yHotspot;
    public IntPtr hbmMask;
    public IntPtr hbmColor;
}
[DllImport("user32.dll")]
[return: MarshalAs(UnmanagedType.Bool)]
public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
[DllImport("user32.dll")]
public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

/// <summary>
/// Create a cursor from a bitmap without resizing and with the specified
/// hot spot
/// </summary>
static System.Windows.Forms.Cursor CreateCursor(System.Drawing.Bitmap bmp, int xHotSpot, int yHotSpot)
{
    IntPtr ptr = bmp.GetHicon();
    IconInfo tmp = new IconInfo();
    GetIconInfo(ptr, ref tmp);
    tmp.xHotspot = xHotSpot;
    tmp.yHotspot = yHotSpot;
    tmp.fIcon = false;
    ptr = CreateIconIndirect(ref tmp);
    return new System.Windows.Forms.Cursor(ptr);
}

void Initialize()
{
    var bitmap = 
        (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile("Content/GlobalContent/SmallCursor.png");
    var cursor = CreateCursor(bitmap, 0, 0);
}
```
