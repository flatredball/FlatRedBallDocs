## Introduction

The Windows IEnumerable contains all regular (non-dominant) windows in the GuiManager. By default IWindow-implementing Entities created in Glue will add themselves to the GuiManager and appear in this list. The order of IWindows in this list determines the order in which the Cursor performs UI checks.

## FlatRedBall Forms

By default, FlatRedBall.Forms objects created through Gum screens add themselves to the GuiManager and appear in this list. Note that the GuiManager does not hold a direct reference to the FlatRedBall.Forms objects, but rather the Visual for each of the forms. Furthermore, only the top-level objects are added to the GuiManager. Therefore, if a StackLayout instance contains multiple buttons, only the StackLayout's Visual will appear in the Window list. For example, the following image shows a Gum screen with four buttons. Since all of the buttons are not contained by any other Forms objects, all four will appear in the Windows list.

![](/media/2022-04-img_6255c9462f5c1.png)

![](/media/2022-04-img_6255ca1fe8fae.png)

 
