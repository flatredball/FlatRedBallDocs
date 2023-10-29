# Introduction

The Cost member represents the difficulty in traveling the node. Usually cost is influenced by or even equal to distance, but it doesn't necessarily have to be. Cost can measure a number of things including:

* Difficulty in crossing due to terrain
* Difficulty in crossing due to risk (enemies, thieves)
* Resources required to perform a particular action (if node networks are used abstractly)

The cost property is used by the [NodeNetwork](../../../../../../frb/docs/index.php) to find the most efficient path from one node to the next.
