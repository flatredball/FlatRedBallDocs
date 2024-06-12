# CustomInitialize

A screen's CustomInitialize is the first method in _custom code_ called after a screen is created. It is called before the screen performs any rendering, but after all of the screen's content has been loaded and after the objects defined in the FRB Editor have been initialized.

CustomInitialize can be used to perform any logic-based initialization. Examples of common types of initialization include:

* Loading custom data from disk such as loading a user profile from a JSON file
* Positioning the player based on spawn locations
* Adding events to factories to perform custom code when an entity is instantiated
* Assigning input devices based on plugged-in hardware or settings from previous screens
* Playing animations or intro sequences such as having a Gum overlay fade out or starting a countdown before the game begins
