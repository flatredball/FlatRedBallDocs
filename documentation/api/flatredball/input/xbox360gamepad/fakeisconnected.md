## Introduction

The FakeIsConnected property can force a Xbox360GamePad's IsConnected property to true whether a physical controller is actually connected or not.

## Common Usage

Some game logic may depend on the number of connected Xbox360GamePads. For example, a game which supports a local versus mode may enable one character-selection cursor for each connected Xbox360GamePad. You may not have access to four Xbox controllers, but you may want to still test this functionality. The FakeIsConnected enables this.
