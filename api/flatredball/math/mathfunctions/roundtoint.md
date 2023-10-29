## Introduction

The RoundToInt method can be used to round a float or double value to an integer value. The return value is rounded as an integer which allows for == checks without having to worry about loss of precision.

## Code examples

RoundToInt can be used to convert floats to integers

    int intAs7 = MathFunctions.RoundToInt(7.0f);

It will do mathematical rounding as well:

    int intAs7 = MathFunctions.RoundToInt(6.8f);
