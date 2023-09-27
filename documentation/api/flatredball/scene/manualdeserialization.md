## Introduction

ManualDeserialization is a static field on Scene which determines if the engine should use the default XML deserializers, or if it should use an internal deserialization method where it destructs the XML and assigns the properties based off of string values.

The default XML deserialization (when ManualDeserialization is false) uses reflection to deserialize .scnx files. Reflection-based deserialization is very slow on Windows Phone 7 and the Xbox 360. ManualDeserialization defaults to true on these platforms, and results in a significant performance increase.

You will usually not need to change this value, it should be set automatically by FlatRedBall to use the best configuration.
