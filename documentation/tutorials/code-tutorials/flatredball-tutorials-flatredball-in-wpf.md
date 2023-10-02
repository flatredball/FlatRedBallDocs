# flatredball-tutorials-flatredball-in-wpf

### Introduction

FlatRedBall projects can be combined with WPF to create powerful applications utilizing the flexibility and speed of FlatRedBall with the power of WPF. This article the available options for combining these two technologies.

### Option 1 - FlatRedBall inside a WPF control

FlatRedBall can be contained within a WPF control. This is is a common approach if FlatRedBall is going to be used inside of a game development tool or other application where the user will interact with WPF as frequently as the FlatRedBall window. In this option the project type is a standard WPF project with FRB injected into it. ![FrbWpf1.PNG](../../../media/migrated\_media-FrbWpf1.PNG) The easiest way to accomplish this is to use the FRB WPF template which can be found here: [http://www.gluevault.com/projects/tech-demo/74-flatredball-wpf](http://www.gluevault.com/projects/tech-demo/74-flatredball-wpf)

### Option 2 - FlatRedBall with floating WPF controls

WPF controls can be added to existing FlatRedBall projects without much additional work. Fortunately this does not require many changes to existing FlatRedBall projects, so WPF controls can even be added to games already in-development. ![OneInstance.PNG](../../../media/migrated\_media-OneInstance.PNG) For more information on this option, see [this page](../../../frb/docs/index.php).
