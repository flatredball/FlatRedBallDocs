# Instance Creation

### Introduction

This document describes the details of how instances are created during live edit. This document is useful if you are working on fixing bugs or implementing new functionality in live edit. It does not cover the way to create entities using live edit. For information on using Live Edit, see the [FlatRedBall Editor Live Edit](../../glue-reference/enable-live-edit/) section.

### Instance Creation Types

Instances can be created in a number of ways:

1. By running the code generation for when an entity is added to a Screen or another Entity
2. By reacting to a drag+drop of an entity in a Screen or another Entity while in live edit. This is referred to as a "dynamic instance"
3. By re-running commands when re-loading a screen (#2), or creating a dynamic entity which itself contains dynamic entities (#2)
4. By calling Factory.CreateNew or Variant.CreateNew in CustomInitialize
5. By calling `new` on an entity type in CustomInitialize

These scenarios above can be a mix of generated code and dynamic code. The challenging part of working with dynamic instances is to make sure that dyanmic modifications to entities are applied in all cases above without applying any changes in duplicate.

Changes can be applied in one of three ways:

1. `ReRunAllGlueToGameCommands` - This method is executed in any non EntityViewingScreen after the Screen's generated code is executed. This is a "catch all" for any generated code which may need to be modified after it has run. Note that when this code is executed, Factories have yet to be assigned the ApplyEditorCommandsToNewEntity (see below)
2. `ApplyEditorCommandsToNewEntity` in `InstanceLogic` - Newly-created instances which are created through InstanceLogic.CreateEntity execute the `ApplyEditorCommandsToNewEntity` if the instance if it is the top-level entity and if it is not being created through a factory. If it is being created through a factory, it will be handled by the 3rd case (see below)
3. `ApplyEditorCommandsToNewEntity` in Factory CreateNew - After an entity has been created through a factory, and after the screen has called BeforeCustomInitialize.

This collection of when events are raised has a few downsides. The first is that it is complicated. Remembering this combination of when these methods are run is confusing. Second, at the time of this writing there is a bug in the entity instantiation. An entity instance will not have Glue commands applied if:

1. It is being created by re-running commands
2. The entity has an associated factory (usually the case)
3. The modification to the entity is applied before the creation of the entity instance. If it is applied after, then the re-run will apply the change appropriately.

We cannot run all commands on the entity instance through its constructor because we only want to re-run commands up to the creation of the instance. Re-running all global commands will apply to all instances...but maybe we don't need to. Perhaps an entity that is instantiated is responsible for running all commands which apply directly to it. If it did so, then it would automatically handle all commands for all modifications, and we would not need to re-run global commands for entity instances. We would still need to re-run commands for deleting at the screen level, unless we re-run them at the screen level the same way we run Entity level commands.

Need to investigate this.
