## Introduction

The TextRed, TextGreen, and TextBlue values control the color of the Text object used by the Debugger class. These three values range between 0 and 1, and the default value is 1,1,1 (white).

## Color and CommandLineWrite

Currently the Debugger uses a single Text object for the entire "command line", meaning if you set the color, the color applies to all lines, not just the single line.
