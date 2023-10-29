## Introduction

The IsMaxPositionNormalized property controls whether to normalize (keep less than 1) the AnalogStick's Position value. If false, the analog stick will return its raw input value which may be larger than 1. Games which use the analog stick for movement and which would like to restrict the movement to a maximum value (such as a top-down game) should set IsMaxPositionNormalized to true.
