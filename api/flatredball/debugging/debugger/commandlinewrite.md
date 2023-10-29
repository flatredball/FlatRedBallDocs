## Introduction

The CommandLineWrite function can be used to append a single line to the debugger. CommandLineWrite cannot be used at the same time as Write - calling Write will clear the output, wiping out all CommandLineWrite texts. Keep in mind that any function that writes to the output may overwrite the command line buffer. Calling CommandLineWrite will append text and the text will appear on screen for subsequent frames.
