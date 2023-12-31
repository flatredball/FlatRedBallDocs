# glue-reference-screen-constructor

### Introduction

The Screen constructor is intentionally generated by Glue to have no arguments. However, the constructor should never be explicitly called in your game's custom code. In other words, you will never "new" a Screen in your custom code. Screens are instantiated by the ScreenManager and base Screen class using a variety of methods, but usually through StartAsyncLoad and MoveToScreen.

Just like [Entity constructors](../../../../frb/docs/index.php), the limitations on Screen constructors essentially means that you cannot pass custom information to the Screen's CustomInitialize method through the constructor. Fortunately, there are a number of ways around this.

### Using GlobalData

The most common approach to providing information to Screens which may be used in the Screen's CustomInitialize method is through GlobalData. For a discussion on GlobalData, see [this article](../../../../frb/docs/index.php#GlobalData).

### Additional Information

* [How are Screens Created?](../../../../frb/docs/index.php)
