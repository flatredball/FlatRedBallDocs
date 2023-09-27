## Introduction

The CsvHeader class represents a header in a CSV file in the [RuntimeCsvRepresentation](/frb/docs/index.php?title=FlatRedBall.IO.Csv.RuntimeCsvRepresentation.md "FlatRedBall.IO.Csv.RuntimeCsvRepresentation") class. The [RuntimeCsvRepresentation](/frb/docs/index.php?title=FlatRedBall.IO.Csv.RuntimeCsvRepresentation.md "FlatRedBall.IO.Csv.RuntimeCsvRepresentation") class contains an array of CsvHeaders called Headers.

## Header Information

When a [RuntimeCsvRepresentation](/frb/docs/index.php?title=FlatRedBall.IO.Csv.RuntimeCsvRepresentation.md "FlatRedBall.IO.Csv.RuntimeCsvRepresentation") is loaded, it will (by default) contain an array of CsvHeaders. Each CsvHeader represents the first item in a column in a CSV file.

The contents of the cell can be obtained through either the Name or OriginalText properties - they will be initially identical.

By default the IsRequired property will be set to false. Both the IsRequired and Name properties can be modified through the [RuntimeCsvRepresentation's RemoveHeaderWhitespaceAndDetermineIfRequired method](/frb/docs/index.php?title=FlatRedBall.IO.Csv.RuntimeCsvRepresentation.md.RemoveHeaderWhitespaceAndDetermineIfRequired&action=edit&redlink=1 "FlatRedBall.IO.Csv.RuntimeCsvRepresentation.RemoveHeaderWhitespaceAndDetermineIfRequired (page does not exist)").

Did this article leave any questions unanswered? Post any question in our [forums](/frb/forum.md) for a rapid response.
