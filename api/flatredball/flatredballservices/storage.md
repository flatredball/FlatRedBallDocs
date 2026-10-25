# Storage

### Introduction

`FlatRedBallServices.Storage` saves and loads game data such as save files, high scores, and settings. You call it the same way on every platform. On desktop it writes files. On web it writes to the browser's `localStorage`. You do not need `System.IO.File` or `#if` blocks.

`Storage` has the same API as `Engine.Storage` in FlatRedBall 2, so code moves between the two with few changes.

### Main Concepts

* Setting `StorageName`
* Saving and loading text
* Keys
* Saving with a stream
* Where data is stored
* Web limits
* Custom storage

### Setting StorageName

Set `FlatRedBallServices.StorageName` before you call `InitializeFlatRedBall`. If you do not, the first call to `Storage` throws an `InvalidOperationException` on every platform.

```csharp
// Game1 constructor, before InitializeFlatRedBall:
FlatRedBallServices.StorageName = "MyGame";
```

The name is the save folder on desktop and the key namespace in the browser on web. It can use letters, digits, spaces, `-`, `_`, and `.`, up to 64 characters. Pick a name and keep it. Changing it later leaves existing saves behind.

### Saving and Loading Text

All calls are async. Use `WriteTextAsync` to save and `ReadTextAsync` to load. `ReadTextAsync` returns `null` if the key does not exist.

```csharp
await FlatRedBallServices.Storage.WriteTextAsync("saves/slot1.json", json);

string? loaded = await FlatRedBallServices.Storage.ReadTextAsync("saves/slot1.json");
```

The other calls are:

* `ExistsAsync(key)` returns `true` if the key has data
* `DeleteAsync(key)` removes a key and returns `true` if it existed
* `ListAsync(prefix)` returns every key that starts with the prefix
* `ReadBytesAsync(key)` and `WriteBytesAsync(key, data)` work with raw bytes
* `OpenReadAsync(key)` returns a `Stream`, or `null` if the key does not exist

Any failure to read or write throws a `StorageException`.

### Keys

A key is a relative name, with `/` between parts. Keys are the same on every platform, so a key that works on desktop also works on web.

* Use lowercase letters, digits, `-`, `_`, and `.`
* Use `/` to separate parts, like `saves/slot1.json`
* A key can be up to 256 characters, and each part up to 128
* Parts cannot be empty, `.`, or `..`

A bad key throws an `ArgumentException`.

### Saving With a Stream

`OpenWriteAsync` returns a stream you write into. Nothing is saved until you call `CommitAsync`. If you dispose the stream without committing, the write is thrown away, so a crash in the middle of saving does not damage the old save.

```csharp
await using var stream = await FlatRedBallServices.Storage.OpenWriteAsync("saves/slot1.bin");
await stream.WriteAsync(bytes);
await stream.CommitAsync();
```

### Where Data Is Stored

On desktop, files go in a per-user folder named after `StorageName`. On Windows this is `%LocalAppData%\<StorageName>`. To use a different folder, set `FlatRedBallServices.StorageRootDirectory` before `InitializeFlatRedBall`. The exact folder is used, and `StorageName` is not added to it.

On web, data goes in the browser's `localStorage`. Entries are stored under `frb2:<StorageName>/<key>`. This is the same prefix FlatRedBall 2 uses, so a FlatRedBall 1 web game and a FlatRedBall 2 web game with the same `StorageName` see the same saves. Web projects need no extra setup.

### Web Limits

* Browsers allow about 5 MiB of `localStorage` per site, shared by everything on that site
* Bytes are stored as text, so they take about a third more space
* A write that goes over the limit throws a `StorageException` and keeps the old value
* Players can clear site data at any time

Some browsers block `localStorage`, for example in certain private modes. In that case the game still runs and saves work until the page closes, but `Storage.IsPersistent` is `false`. Check it if you want to warn the player that nothing will be kept.

```csharp
if (!FlatRedBallServices.Storage.IsPersistent)
{
    // Tell the player that progress will not be saved
}
```

### Custom Storage

To store data somewhere else, such as a cloud service, create a class that implements `IStorageBackend` and assign it to `Storage.Backend`. Assign it after `InitializeFlatRedBall`, because initialization replaces the backend.

```csharp
FlatRedBallServices.Storage.Backend = new MyCloudBackend();
```

Before `InitializeFlatRedBall` runs, `Storage` keeps data in memory only. This is also handy in unit tests.

### Conclusion

`FlatRedBallServices.Storage` gives you one async save and load API that works on desktop and web.
