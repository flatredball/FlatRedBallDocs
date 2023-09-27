## Introduction

Glue generates a Reload function in GlobalContent which simplifies reloading CSV files. Reload can only be used to reload CSV files from disk.

Reload is useful for games which may change CSVs during execution, such as games that download new data from a remote server. Reload will change the member that is passed to the function but will not re-assign properties that have been set from rows in the CSV. In other words, any objects that reference the old CSV must be re-assigned to values in the new CSV.

## Code Example

The following assumes that the Global Content Files folder in Glue contains a file called EnemyDefinition.csv:

    GlobalContent.Reload(GlobalContent.EnemyDefinition);
