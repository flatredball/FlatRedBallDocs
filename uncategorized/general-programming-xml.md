## Introduction

XML is a standard format used in many areas. FlatRedBall makes extensive use of XML for all of its file formats, including .scnx, .shcx, and .glux. A basic understanding of the XML format can help you generate, edit, and debug data.

## Representation of data

XML is simply a way to represent data. XML data can be "nested" meaning that data can contain other data, just like instances in C# can contain their own instances.

Let's compare how data might be created and represented in C# and XML:

    // In C# we might create a Person instance as follows:
    Person person = new Person();
    person.Age = 30;
    person.Name = "Michael";

    // In XML a Person may be represented as follows:
    <Person>
       <Age>30</Age>
       <Name>Michael</Name>
    </Person>

Just like in C#, the indentation in XML is not necessary; however, it can help make the XML document more readable.
