## Introduction

FlatRedBall supports having any number of ContentManagers living concurrently. This section will explain some situations where multiple content managers may be useful.

## Overlapping content

Multiple content managers may be used if two content managers can exist at the same time, usually for async or time-sliced loading. For example, consider a game where the user transitions from one screen to another. The content managers lay live as follows:

    |----------Screen 1 Content Manager --------|
                                     |---------Screen 2 Content Manager-------|
                 Async loading starts^          ^Async loading finishes

Content managers can also be used to provide transitions between Screens - this is typically how Loading screens operate:

    |-----Screen 1 Content Manager -----| |-----Screen 2 Content Manager|       
                                |Loading Screen-|

## Varied lifespans

Content managers can be used if you have content which has a predefined lifespan and will be removed before the current Screen is destroyed. This may look like this:

    |-------------Screen 1 Content Manager -----------|
                   |---Object ContentManager---|
    Start of object^                           ^End of object

Note that deleting the object may not help much to reduce maximum memory usage - the peak will likely be hit while both content managers are alive.

## Individual Asset Handling

If you need to load and unload individual assets, you may consider using multiple content managers. This is useful for tools. Keep in mind that if you are performing from-file content loading, you do not necessarily need to even use content managers. The ContentManager class is intended to be used as a convenient way to cache, group, and unload a collection of content, so situations where you load and unload individual files may not benefit from working with a ContentManager.
