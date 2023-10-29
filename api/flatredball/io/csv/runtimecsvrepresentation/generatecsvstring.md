## Introduction

The GenerateCsvString method can be used to generate a string in CSV format. The resulting string can be saved to a file to create a CSV which can be opened in any application that supports CSVs.

## Code Example

The following code shows how to use the GenerateCsvString method:

    RuntimeCsvRepresentation rcr = new RuntimeCsvRepresentation();

    rcr.Headers = new CsvHeader[2];
    rcr.Headers[0] = new CsvHeader("Header1");
    rcr.Headers[1] = new CsvHeader("Header2 (int)");

    rcr.Records = new List<string[]>();
    rcr.Records.Add(new string[2]);
    rcr.Records[0][0] = "FirstColumnValue";
    rcr.Records[0][1] = "3";

    string result = rcr.GenerateCsvString();

The result string will contain:

    Header1,Header2 (int)
    FirstColumnValue,3
