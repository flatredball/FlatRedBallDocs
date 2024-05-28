# DialogBox

The DialogBox control is used to display dialog to the screen. It provides a number of common dialog functionality including:

* Typewriter (letter by letter) display of the text
* Multi-page display using an IEnumerable
* Task (async) support for logic after
* Force display of entire page and page advance input
* Input support using keyboard, mouse, and gamepads

<figure><img src="../../../../.gitbook/assets/28_17_07_29 (1).gif" alt=""><figcaption><p>Standard DialogBox</p></figcaption></figure>

### Implementation Example

Like other FlatRedBall.Forms controls, the easiest way to create a DialogBox is to add a DialogBox instance into your screen. By default dialog boxes are visible, but you may want to mark yours as invisible in your Gum screen so it doesn't display in game until you need it to display. For most games only a single DialogBox instance is needed unless you intend to have multiple dialog boxes displayed at the same time.

<figure><img src="../../../../.gitbook/assets/image (8) (1).png" alt=""><figcaption></figcaption></figure>

To display a dialog box, use one of the Show methods. The simplest is to call Show with a string, as shown in the following code:

```csharp
void CustomActivity(bool firstTimeCalled)
{
    if(InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Enter))
    {
        var dialogBox = Forms.DialogBoxInstance;
        dialogBox.Show("Hello, I am a dialog box. Let's make same games!");
    }
}
```

<figure><img src="../../../../.gitbook/assets/28_17_48_03.gif" alt=""><figcaption><p>DialogBox shown with one page of text</p></figcaption></figure>

Alternatively, multiple pages can be displayed using an IEnumerable such as a string array as shown in the following code snippet:

```csharp
var dialogBox = Forms.DialogBoxInstance;

var pages = new string[]
{

    "Let me tell you why FlatRedBall.Forms is so great:",
    "It has tons of functionality out-of-the-box.",
    "You can do all of your layouts visually in Gum.",
    "It has MVVM support.",
    "Its appearance can be fully customized too!"
};

dialogBox.Show(pages);
```

<figure><img src="../../../../.gitbook/assets/28_17_53_02.gif" alt=""><figcaption><p>Multiple pages of text from a string[]</p></figcaption></figure>

### Automatic Paging

DialogBox can display multiple pages through the Show and ShowAsync methods. Each string is treated as an entire page if it fits. A single string will be be broken up into multiple pages if it is too large.

The following code results in multiple pages automatically being set.

```csharp
string textToDisplay = string.Empty;
for(int i = 0; i < 20; i++)
{
    textToDisplay += $"This is sentence number {i+1}. ";
}

dialog.ShowAsync(textToDisplay);
```

<figure><img src="../../../../.gitbook/assets/19_14 23 03.gif" alt=""><figcaption><p>DialogBox automatic paging for long text</p></figcaption></figure>

Automatic paging only applies if the number of lines is limited on the backing Text object. The default implementation of the DialogBox should automatically limit the number of lines.

The default implementation's Text property has the following relevant properties:

* HeightUnits of RelativeToContainer - the height unit depends on the container, so the height does not increase as more lines of Text are added.\
  ![](<../../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png>)
* Text Overflow Vertical Mode of Truncate Line - this prevents text from spilling over the bounds.\
  ![](<../../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png>)

Note that if the Text property can extend indefinitely - either by allowing it through a Text Overflow Vertical Mode of **Spill** or by having a Height Units of **Relative to Children**.

### ShowAsync for async Programming

The ShowAsync method returns a task which can be used to await for all pages to be shown and for the final page to be dismissed. A common usage of ShowAsync is in a scripted sequence. For example, a scripted sequence may combine dialog and player movement. Since the player can choose when to advance text, the amount of time that a DialogBox is displayed must be awaited. The following shows how code might be used to implement a scripted sequence which combines dialog being displayed and player movement.

```csharp
var dialogBox = Forms.DialogBoxInstance;
await dialogBox.ShowAsync("Hello? Who is there?");
await MovePlayerTo(100, 50);
await dialogBox.ShowAsync("Oh, the room is empty, but I thought I heard a noise.");
await MovePlayerTo(300, 80);
await dialogBox.ShowAsync("No one is here either. Am I hearing things?");
```

Note that if your game requires advancing the dialog with the Keyboard or Xbox360GamePad, then the DialogBox must have its IsFocused property set to true. See the section on IsFocused for more information.

### Multiple Pages Using ShowAsync

The DialogBox control provides a few approaches for showing multiple pages. As shown above, the Show method can take an array of `string`s. Alternatively, the `ShowAsync` method can be used to show one page at a time.

```csharp
private async void ShowMultiplePages()
{
    var dialogBox = Forms.DialogBoxInstance;

    await dialogBox.ShowAsync("This is the first page of dialog.");
    await dialogBox.ShowAsync("This is a second page.");
    await dialogBox.ShowAsync("And a third page.");
    await dialogBox.ShowAsync("Finally a fourth page.");
}
```

This approach is useful if your DialogBox implementation has additional properties for each page of dialog. For example, a DialogBox can be modified in Gum to have a Text instance displaying the name of the person speaking.

<figure><img src="../../../../.gitbook/assets/image (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>DialogBox with SpeakerTextInstance in Gum</p></figcaption></figure>

Since the Show method exists on the standard DialogBox, it does not have a way to specify the speaker. We can access the visual on the DialogBox to modify the SpeakerTextInstance directly through the Visual property.

```csharp
var dialogBox = Forms.DialogBoxInstance;
var dialogBoxVisual = dialogBox.Visual as DialogBoxRuntime;

dialogBoxVisual.SpeakerTextInstance.Text = "Captain";
await dialogBox.ShowAsync("Which way should we go?");

dialogBoxVisual.SpeakerTextInstance.Text = "Soldier";
await dialogBox.ShowAsync("...");

dialogBoxVisual.SpeakerTextInstance.Text = "Captain";
await dialogBox.ShowAsync("I know you are afraid to speak up, but don't worry! " +
    "We're a team, we need to work together to get through this.");

dialogBoxVisual.SpeakerTextInstance.Text = "Soldier";
await dialogBox.ShowAsync("Well...it might be best to follow the river.");

```

<figure><img src="../../../../.gitbook/assets/17_05 57 03.gif" alt=""><figcaption><p>Dialog box with speaker</p></figcaption></figure>

Note that to access the SpeakerTextInstance, the Visual must be used, which is a reference to the Gum object. The `dialogBox` is an instance of the standard `DialogBox` forms object, so it ony provides methods and properties common to every `DialogBox`. For more information about Forms vs Gum objects, see the [Forms vs Gum](../../../../tutorials/flatredball-forms/getting-started/forms-and-gum-objects.md) in Code Tutorial.

### Styling

DialogBox text fully support styling, including pages. The following code results in styled text.

```csharp
string textToDisplay = 
    "Now that I've found the [Color=Yellow]ring[/Color], " +
    "I can return it back to the [Color=Green]king[/Color]. " +
    "I should hurry before [Color=Purple]nightfall[/Color].";

dialog.ShowAsync(textToDisplay);
```

<figure><img src="../../../../.gitbook/assets/image (2) (1) (1) (1) (1) (1).png" alt=""><figcaption><p>Styled text in a dialog box</p></figcaption></figure>

More information on styled text can be found in the Gum documentation: [https://docs.flatredball.com/gum/gum-elements/text/text#using-bbcode-for-inline-styling](https://docs.flatredball.com/gum/gum-elements/text/text#using-bbcode-for-inline-styling)

### DialogBox Input

DialogBox responds to input and can respond to two types of input: _confirm_ input and _cancel_ input.

Confirm input performs the following actions:

* If dialog is printing out character-by-character, the entire page is immediately displayed
* If the entire page is displayed and the DialogBox has more pages to display, the page is cleared and the next page begins displaying
* If the entire page is displayed and the DialogBox has no more pages to display, the dialog box is dismissed

Cancel input performs the following actions:

* If dialog is printing out character-by-character, the entire page is immediately displayed
* If the entire page is displayed and the DialogBox has more pages to display, the page is cleared and the next page is displayed in its entirety
* If the entire page is displayed and the DialogBox has no more pages to display, the dialog box is dismissed

In other words, confirm and cancel input behave the same except that cancel immediately prints out the next page, giving players the choice to skip letter-by-letter display.

Dialog can be advanced with Mouse, Keyboard, Xbox360GamePad, and a custom `Func` predicate named `AdvancePageInputPredicate`. Note that if a DialogBox has a non-null `AdvancePageInputPredicate`, then all other forms of input are ignored. This allows games to fully customize a DialogBox's page advance logic.

#### Mouse Input

The Mouse can only perform confirm input. If a dialog is clicked, then its confirm action is executed.

#### Keyboard Input

The Keyboard's IInputDevice implementation is used for confirm and cancel actions:

* Space (DefaultPrimaryActionInput) is used to confirm
* Escape (DefaultCancelInput) is used to cancel

Note that the keyboard actions will only apply if the DialogBox has focus. For example, the following code shows how to give a DialogBox focus:

```csharp
var dialogBox = Forms.DialogBoxInstance;
dialogBox.IsFocused = true;
dialogBox.Show("Press space or ESC to perform confirm or cancel actions, respectively");
```

For more information on IsFocused and DialogBoxes, see the section below.

**Xbox360GamePad Input**

Xbox360GamePads can be used to advance dialog. A DialogBox must have focus for the Xbox360GamePads to advance dialog, just like the Keyboard. Furthermore, the desired Xbox360GamePads must be added to the GuiManager's GamePadsForUiControl as shown in the following code:

```csharp
GuiManager.GamePadsForUiControl.Add(InputManager.Xbox360GamePads[0]);
```

For more information, see the [GuiManager.GamePadsForUiControl](https://flatredball.com/documentation/api/flatredball/flatredball-gui/flatredball-gui-guimanager/gamepadsforuicontrol/) page.

Once gamepads are added, the dialog box can be shown and focused just like in the example above for Keyboard input.

#### AdvancePageInputPredicate

To customize advance behavior, the AdvancePageInputPredicate delegate can be used to control DialogBox advancement. This method can be used to advance dialog box behavior using custom input or other conditions such as the completion of a tutorial. DialogBoxes must have focus or their AdvancePageInputPredicate will not apply.

The following code shows how to advance the page on a secondary click. Note that this code does not perform any additional logic, such as whether the cursor is over the DialogBox. This means that right-clicking anywhere on the screen advances the dialog.

```csharp
void CustomInitialize()
{
    Forms.DialogBoxInstance.AdvancePageInputPredicate = AdvanceOnSecondaryClick;
}

private bool AdvanceOnSecondaryClick()
{
    return GuiManager.Cursor.SecondaryClick;
}
```

As mentioned above, assigning AdvancePageInputPredicate prevents all other default page advance logic, so the user will not be able to advance the dialog with the keyboard, gamepads, or with a left-click on the DialogBox.

### IsFocused

As mentioned in the section on DialogBox Input, Xbox360Gamepad and Keyboard input will only advance and dismiss the dialog box if IsFocused is set to true. This must be set explicitly to give the dialog box focus. Note that mouse clicks will advance the dialog box automatically even if the DialogBox's IsFocused is not set to true.

Typically IsFocused is set to true whenever dialog is displayed. When a DialogBox is dismissed, it is hidden and its IsFocused is set to false. This means that if multiple DialogBox pages are displayed one-after-another using `ShowAsync`, `IsFocused` must be set to true before each `ShowAsync` call is performed, as shown in the following code:

```csharp
var dialogBox = Forms.DialogBoxInstance;

dialogBox.IsFocused = true;
await dialogBox.ShowAsync("This is the first page of dialog.");
dialogBox.IsFocused = true;
await dialogBox.ShowAsync("This is a second page.");
dialogBox.IsFocused = true;
await dialogBox.ShowAsync("And a third page.");
dialogBox.IsFocused = true;
await dialogBox.ShowAsync("Finally a fourth page.");
```

### Dismiss

The dismiss method can be used to visually remove a DialogBox and raise events as if it has been advanced. The Dismiss method performs the following logic:

* Makes the DialogBox invisible (sets IsVisible to false)
* Raises the PageAdvanced and FinishedShowing events
* Clears all pages so that the dialog box can be used "fresh"
* Removes focus (sets IsFocused to false)
