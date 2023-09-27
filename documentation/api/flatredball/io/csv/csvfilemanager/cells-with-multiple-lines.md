## Introduction

The CsvFileManager supports CSV (or .txt files) cells with multiple rows. If you are using Text objects to display the contents of a CSV cell, the Text object will obey the new lines.

## Multiple Lines in Excel

To enter multiple lines in Excel:

1.  Click on a cell
2.  Begin entering text
3.  Hold down the ALT key and press ENTER to insert a new line
4.  Continue typing

### \n doesn't work in CSVs

If you are used to programming new lines in strings in C# code, then you may be familiar with the '\n' character. However, FlatRedBall CSVs will not obey the newline character. The reason for this is because in code the '\n' is actually a single character, while writing \n in a CSV actually generates two characters: the '\\' character followed by the 'n' character. To represent the \n character as a single character, you just insert an actual newline - this is what ALT+Enter in Excel accomplishes.
