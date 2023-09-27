The simple command console provides an easy to use dos-style command parser featuring commands, helps, and aliases.

The simple command console is ready to go right out of the box. Simply import the entity into your project, and add it to your screen. Then use the described public methods to add new commands, helps or aliases.

## Registering Commands

    void RegisterCommand(string name, string helpText, CommandTarget target)

This method is used to register a command. This defines the command and indicates what method should be called when the command is entered.

**name** is a string that represents the command to be typed. This can not contain any white space characters, as the command parser stops at the first white space when looking for a command to parse.

**helpText** is a string to be displayed to the screen if the user types "help **name**". This should describe how to use the command.

**target** is a delegate provided by the entity and is defined as:

    public delegate void CommandTarget(string args);

The **CommandTarget** is the function to be called when this command is typed. If the user types anything after the command, the entirety of the line after the command is passed to the function as a single string. For instance, if the the command is "list" and the user types "list all my houses" then when the function is called it will be passed "all my houses" in the args variable.

## Registering Command Aliases

    void RegisterCommandAlias(string alias, string commandName)

This method allows you to register an alias for a previously registered command. An alias is another keyword that can be used instead of the commands name.

**alias** is a string that represents the new name of the command.

**commandName** is the **name** of the command to create an alias for.

## Registering Helps

    void RegisterHelp(string name, string helpText)

This method allows you to register help text that is not associated with a command. This should not be used to register helps for commands, as that help should be registered with the command itself.

**name** is a string that the user will type after the **help** command to retrieve this help entry.

**helpText** is a string that will be displayed to the screen when the user requests this help entry.

## Registering Help Aliases

    void RegisterHelpAlias(string alias, string helpName)

This method allows you to register an alias for a previously registered help entry. An alias is another keyword that can be used instead of the help entry's name.

**alias** is a string that represents the new name of the help entry.

**helpName** is the name of the original help entry to create an alias for.

## Customization

The console window display can be customized using the various variables that have been exposed.

-   X,Y : sets the bottom left corner of the console window
-   Z : sets the z-buffer of the display so it can show up over other sprites
-   NumOutputLines : The number of output lines visible in full display mode
-   NumCharOnLine : The number of characters allowed on each line
-   CursorBlinkRate : How fast the cursor should blink, smaller number is faster blink
-   FullDisplay : if the console is currently in full display mode
-   NumLinesInPartialDisplay : how many lines should be shown while in partial display mode
-   InputHistoryLength : how many different inputs should it remember at once
-   BackBufferHistoryLength : the total number of lines to be stored in the backbuffer

## In Game Usage

To issue a command in the game, type the command preceeded by a forward slash. For instance "/reset me" will call the function registered with the "reset" command, passing the argument of "me".

If you type your command without a forward slash like "reset me" the console will look to see if there is a "say" command registered, if so it will call the function registered with the "say" command and pass it the entirety of the typed input. This is the equivalent as if you typed "/say reset me". If no say command is registered, the console will tell the user that it did not recognize the command or keyword.

To get help on a topic or a command you can type "/help" followed by the topic or command that you want help on. For instance, if you wanted help on the "reset" command, you would type "/help reset", this same is true for non-command help.

If the command entered does not exist, the console will display a simple message saying that the command does not exist.

When in full mode, the console reads all input from the pc keyboard, and aside from certain special keys, all input is fed to the console display.

## Special Keys

When in full display mode, the console watches for certain special keys that perform certain operations.

| Key        | Operation                                         | Mode        |
|------------|---------------------------------------------------|-------------|
| Tilde (\~) | Toggle console between Full and Mini modes        | Full / Mini |
| Page Up    | Scrolls back-buffer up one page                   | Full        |
| Page Down  | Scrolls back-buffer down one page                 | Full        |
| Home       | Scrolls all the way to the top of the back-buffer | Full        |
| End        | Scrolls all the way to the end of the back-buffer | Full        |
| Up Arrow   | Scroll up one command in the input history        | Full        |
| Down Arrow | Scroll down one command in the input history      | Full        |

## Additional Notes

-   If the output display is too wide for the console's settings, it will auto-wrap the output to the last available space between characters.
-   The console currently only accepts input from InputManager.Keyboard
-   The console is currently only built for Windows PC, inputs from other devices may or may not be recognized.
-   Internally, there is no difference between a command help or a non-command help. Once registered all help topics are stored by keyword and display text only.

## Can I use this in a commercial project?

Flat Red Ball is kind of an open source oriented community. I am following suit by releasing this as open source under the MIT license. As such, you don't have very many limitations on how you can use this.

If you are really interested in reading the specific license that I've applied to this, then go [here](http://opensource.org/licenses/MIT).

## Who do I contact?

Did you find a bug? Do you have a suggestion for improvement? Or maybe you'd just like to let me know you are using it or provide other feedback? In any case, you can easily find me in the community or on chat as Magius96.
