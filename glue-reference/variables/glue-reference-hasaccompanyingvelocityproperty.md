## Introduction

The HasAccompanyingVelocityProperty property is a property that tells Glue to generate a Velocity value for the given variable. The velocity variable is useful in the following situations:

-   If you intend to change a variable at a constant rate over time then you can set this value to true. Glue will generate a velocity property which will be applied at a time-based rate. The application of this value considers pausing.
-   If you intend to interpolate a custom variable, then it will be necessary to create a velocity property. If a velocity property is created Glue will use it in interpolating states.

![HasAccompanyingVelocityProperty.png](/media/migrated_media-HasAccompanyingVelocityProperty.png)
