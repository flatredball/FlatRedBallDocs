# kalldrexx-interactive-debugging-console

## Introduction

To assist in debugging I have created an extensible interactive input and output console logging system, very similarly to the console system made popular by the Quake games. This system allows execution of commands through a command processing engine (by default it uses javascript but any language can be easily hooked up).

With this system it is possible for developers to view debugging output and interact and update C# objects and methods from within their game. This allows developers to change AI behaviors, spawn entities, load levels, and much more.

![Console5.PNG](../../media/migrated\_media-Console5.PNG)

## Install / Quick Start

* Download the code from [GitHub](https://github.com/KallDrexx/ConsoleLib) or the binaries from [GlueVault](http://www.gluevault.com/code/49-advanced-debugging-console)
* Add a reference to the ConsoleLib dll (or project) to your project
* In your Game1.cs file initialize the console management system
  * At the start of the Initialize() method (before all FRB initialization) add ConsoleManager.Instance.InitializeProcessor(new JavascriptConsoleProcessor());

```
InteractiveConsoleInstance.ConsoleToggleKey = Keys.OemTilde;
InteractiveConsoleInstance.ConsoleScrollUpKey = Keys.PageUp;
InteractiveConsoleInstance.ConsoleScrollDownKey = Keys.PageDown;
```

* Add some custom C# objects to be accessible via the console
  * In your screen's CustomInitialize method add: ConsoleManager.Instance.RegisterObjectToConsole(\<c# object>, "\<name of object for script referencing>", this);
  * In your screen's CustomDestroy() method add the following code (this is required for memory management purposes ConsoleManager.Instance.UnregisterObjectsFromSource(this);
  * Then in the console just type the name you registered it with and you can access all of that object's public properties and methods
* To output text from code to the console system call ConsoleManager.Instance.AddOutput("My Text", "Category");

Now you can load your game up and press the ConsoleToggleKey to open and close the console window.

Built-in commands:

* objects() - shows all objects registered with the console manager
* properties(string) - shows all public properties for the specified object
* methods(string) - shows all public methods for the specified object

With the default setup any javascript can be run, including:

* function square(x) { return x \* x; } - This will create a function that will square values. You can call this function by typing square(5) from the console
* for loops such as for (var x = 0; x < 5; x++) { Camera.X = Camera.X + x; } (this assumes you exposed your camera to the console system.
* new variables (e.g. test1 = "abcd" will create a variable called test1 that can be later called upon from the console.

## Details

Below are lower level details on how the console system works.

### Endpoints

Endpoints are areas of code that can receive output or send input to the console. A class does not have to do both, as you can have a class that only receives output but does not send input to the console.

#### Receiving Output

In order to receive output from the console you must create a method that implements the following delegate:

```
public delegate void OutputDisplayUpdatedDelegate(IEnumerable<string> newText, string category);
```

Once registered (coming up) this method will be called any time any output is sent to the console that the system thinks should be sent to this method (more details on that in a bit).

The first parameter is a list of strings that contain the new output in the order in which they were printed, so newText\[0] is the first line added to the console and newText\[1] is the line of text added next. The second parameter defines the category of the output. More about that when we describe registering this method with the console manager.

Once created your code must register this method with the console manager via the following method on the ConsoleManager class:

```
public void RegisterOutputUpdateHandler(OutputDisplayUpdatedDelegate handler, string category = "");
```

The first parameter is the handler method created to receive console output, with a signature matching the OutputDisplayUpdatedDelegate. The second parameter is optional, and is the name of the category of output that your handler wants to be notified of. For example, if you designate all AI output to have a category of _AI_, then any handler not subscribed to the _AI_ category will not be notified of AI output. A single instance of a handler method can be registered for multiple output categories.

Observant readers will notice that even though we are subscribing a handler to a specific category, the console will call the handler with the output's category. The reason for this is because if a handler is subscribed to no category (null or empty string), then that handler will receive all output regardless of category. This allows the handler to do any special handling on text based its categorization, such as changing the color or adding a prefix based on the output's category.

Once a handler method is registered it will be immediately called once output is sent to the console. In order to stop the handler method from receiving output, the following method must be called on the ConosoleManager class:

```
public void UnregisterOutputHandler(OutputDisplayUpdatedDelegate handler, string category = "")
```

If a category is specified then the delegate is only unregistered for that specific category. If no category is supplied then the delegate is unregistered for all categories and will no longer receive any output.

#### Sending Input

Unlike when receiving output, your code does not need to do any registration prior to sending commands to the console system for processing. All that needs to be done is making a call to ConsoleManager.Instance.ProcessInput("command text", "category"). All output that is created from processing the command will have the category passed in to the ProcessInput() call. If no category is desired the parameter can be left out (or set to an empty string)

### Input Processing

The actual processing of commands is done through an implementation of the IConsoleProcessor interface. This abstraction allows developers to extend the console system to use any language they want, from python to Lua. All that needs to be done is to create a new class that implements IConsoleProcessor and code in all the required methods. See the [Python example](../../frb/docs/index.php#Add\_Python\_Support) for how this is done.

The zip uploaded to GlueVault includes the JavascriptProcessor class, which allows console commands to utilize Javascript via the [Javascript.net](http://javascriptdotnet.codeplex.com/) engine.

### Memory Leak Considerations

When making C# objects and methods accessible to the console you must make sure to keep in mind that those objects need to be removed, otherwise the console system may still hold references to the objects, preventing them from being collected by the garbage collector.

When you no longer need an object, you can remove the object from the console by calling public void UnregisterObject(string name, object obj) method on the ConsoleManager class. To quickly remove all objects from the console added by a specific class, you can use the public void UnregisterObjectsFromSource(object source), where the source object should be the same as used to register the C# objects.

## Examples

### In-Game FRB Console Entity

The console system includes an FRB entity that can be used in your projects as a GUI to interact with the console system in the game.

In order to use the the console you must import the entity into your project via Glue. To do this:

1. Extract InteractiveConsole.entz from the console zip (from \[[GlueVault](http://www.gluevault.com/code/49-advanced-debugging-console)]).
2. Open your project in Glue
3. Right click on Entities and select Import Entity
4. Select InteractiveConsole.entz
5. Drag the new InteractiveConsole entity to your desired screen
6. Select the InteractiveConsole object in your screen and set "Attach To Camera" to true
7. Open the CustomActivity method in your game screen
8. Bind keyboard keys to console actions by setting the ConsoleToggleKey, ConsoleScrollUpKey, and ConsoleScrollDownKey properties for your InteractiveConsole instance
9. Load your game and press the key designated to ConsoleToggleKey and start typing into the console.

The interactive console entity has 5 main glue variables that slightly change its behavior

* PercentOfScreen - This float should be a value between 0 - 1 that determines how much of the screen should be covered by the console. It defaults to 75% (0.75) of the screen.
* SecondsBetweenScroll - This float controls how fast you can scroll through past console output
* PixelSpacingBetweenLines - This controls how many pixels are in between each line of text in the console display. This should mostly be left at 15.
* MaxStoredLines - This controls how much previous console output is kept in memory and can be scrolled through.
* StartingConsoleCategory - This setting allows you to set what console category the console is subscribed to. If left blank the console will receive all console output. This is useful if you intend to only use the console for one specific purpose, such as controlling AI. This can be changed at any time in your game by calling ConsoleUI.ChangeSubscribedConsoleCategory("category name") in the console.

### Output Logging Example

Another example of the use for the console system is to log data to a text file for later review. For example, if you want to run through a scenario and capture all of the AI states that occur during a turn this becomes immensely helpful. I included the following class in the ZIP for the console.

```
public class ConsoleOutputLogger
{
    protected const string DEFAULT_LOG_FILE_TEMPLATE = @"logs/{0}.log";

    public void StartLogging(string category = "")
    {
        ConsoleManager.Instance.RegisterOutputUpdateHandler(OutputHandler, category);

        string message = string.Format("Logging started at {0} for category {1}",
            DateTime.Now.ToShortTimeString(), 
            category.Trim() == "" ? "<all categories>" : category);

        ConsoleManager.Instance.AddOutput(message, category);
    }

    public void StopLogging(string category = "")
    {
        string message = string.Format("Logging stopped at {0} for category {1}",
            DateTime.Now.ToShortTimeString(),
            category.Trim() == "" ? "<all categories>" : category);

        ConsoleManager.Instance.AddOutput(message, category);
        ConsoleManager.Instance.UnregisterOutputHandler(OutputHandler, category);
    }

    public string GetLoggedCategories()
    {
        var categories = ConsoleManager.Instance.GetCategoriesRegisteredForHandler(OutputHandler);
        if (categories == null || categories.Count == 0)
            return "No console categories currently being logged";

        string result = "Logged categories: ";
        for (int x = 0; x < categories.Count; x++)
        {
            if (x > 0)
                result += ", ";

            if (categories[x].Trim() == string.Empty)
                result += "<all categories>";
            else
                result += categories[x].Trim();
        }

        return result;
    }

    protected void OutputHandler(IEnumerable<string> text, string category)
    {
        string filename = string.Format(DEFAULT_LOG_FILE_TEMPLATE, DateTime.Now.ToString("yyyyMMdd"));

        if (!Directory.Exists(Path.GetDirectoryName(filename)))
            Directory.CreateDirectory(Path.GetDirectoryName(filename));

        using (var stream = File.AppendText(filename))
        {
            foreach (string line in text)
            {
                stream.WriteLine("{0}: {1}", category.Trim(), line);                
            }
        }
    }
}
```

You can now log output from a specific category in two ways:

1. Through code by creating an instance of the class and call StartLogging with the desired category name
2. Add the logging class to the console, so you can start and stop logging at will via in-game console commands
   1. Add the following code to your Game1.cs (After initializing the console's processor): ConsoleManager.Instance.RegisterObjectToConsole(this, "logger", new ConsoleOutputLogger());
   2. Now in game, start logging by opening the console and typing logger.StartLogging("") and stop it with logger.StopLogging("")

### Networked Console Client

The code on [\[1\]](https://github.com/KallDrexx/ConsoleLib) contains a project for a Winforms application that can connect to your FRB game and utilize the console over the network. This will allow you to play your game full screen and issue console commands and debug from another computer if desired. It also allows you to save and load console commands from script, pause console output (for easy reading) and saving console output for later reading.

In order to enable this for your game:

1. Follow the install instructions to add the ConsoleLib project or dll to your FRB game
2. Add the following code to your Game1 constructor: \_consoleServiceHost = new ConsoleServiceHost("localhost", 4000);. This will allow you to start receiving console commands with a corrosponding protected variable to your Game1 class.
3. Compile the ConsoleClient project.
4. Run your game and run the ConsoleClient
5. In ConsoleClient, click the Connection menu item and select Connect
6. Enter "localhost" and port 4000 (or whatever you instantiated the ConsoleServiceHost class with
7. Enter a console command and press F5 to execute it.

### Add Python Support

If Javascript is not your cup of tea, this section will show you how to extend the console system to allow for other languages. I will be using Python as an example, but the concepts here can be applied to any language.

First, download [IronPython](http://ironpython.codeplex.com/) and add the libraries to your project.

Next create a new class called PythonConsoleProcessor\<tt> and have it inherit from the \<tt>IConsoleProcessor interface. After you visual studio's helpers to add all the required method signatures you should end up with:

```
    public class PythonConsoleProcessor : IConsoleProcessor
    {
        public string ProcessInput(string input)
        {
            throw new NotImplementedException();
        }

        public void RegisterObject(string name, object obj)
        {
            throw new NotImplementedException();
        }

        public void UnregisterObject(string name, object obj)
        {
            throw new NotImplementedException();
        }
    }
```

Now we need to create variables to store the python engine and a constructor to initialize it, so add the following to your class:

```
        protected ScriptEngine _engine;
        protected ScriptScope _scope;

        public PythonConsoleProcessor()
        {
            _engine = Python.CreateEngine();
            _scope = _engine.CreateScope();
        }
```

This initializes the python engine and give us a scope to add and remove objects from. Next we need to flesh out the code to process input. Remove the NotImplementedException from the ProcessInput method and replace it with:

```
        public string ProcessInput(string input)
        {
            try
            {
                var result = _engine.Execute(input, _scope);
                if (result == null)
                    return string.Empty;

                return result.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
```

This will run commands through the python engine and return the result, if any. If an exception occurs the message will be sent to the console.

**Note:** Usually you do not want to do catch (Exception ex) as that is bad practice. However, since IronPython has a lot of exceptions that can be thrown it's hard not to. If you look at the javascript processor I am more specific with exception handling.

Now to add code to register and unregister objects with the python engine:

```
        public void RegisterObject(string name, object obj)
        {
            _scope.SetVariable(name, obj);
        }

        public void UnregisterObject(string name, object obj)
        {
            _scope.SetVariable(name, null);
        }
```

And that's it. We have a complete console processor that will accept and process python commands. To activate this you need to replace the current call to ConsoleManager.Instance.InitializeProcessor() with ConsoleManager.Instance.InitializeProcessor(new PythonConsoleProcessor).

Now run your game and you will have full python support.
