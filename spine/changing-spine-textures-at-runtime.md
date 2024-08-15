---
description: How (and why) to change textures on a skeleton dynamically at runtime.
---

# Changing Spine Textures at Runtime

The general pattern in Spine is to create a skeleton that contains animations, and skins for each type of object that might share those animations. For example, you might create a "humanoid" skeleton that has walking and attacking animations. And you might have a skin for "human", "goblin", and "troll" that allow you to create unique types of game creatures that share animations. You can easily set the skin using the `SpineDrawableBatch.Skeleton.SetSkin()` method.

In some cases, you may want to have more customized skins. For example, what if humans, goblins, and trolls each have different types of weapons? Spine supports partial skins so you could have folders for skins that set the creature textures, weapon textures, and similar themes on the skeleton. This would allow you to stack unique combinations of skins at runtime.

However, this quickly becomes a combinatorial problem for the artist. They must carefully import every unique weapon, armor, or creature sprite into spine, create a partial skin for it, and re-export the skeleton into the project. It is very easy to make mistakes and accidentally include a goblin arm in a sword skin, for example.

For games that have a large number of partial skins, it may be worth creating a single template skin and dynamically creating the rest of your skins in code! Runtime skins are a [recommended approach in Spine documentation](https://esotericsoftware.com/spine-runtime-skins).

### Setting Up Your Spine Project

It is assumed that you already know how to set up a skeleton, create placeholders, and apply textures to those placeholders with a skin. See [Spine Skin Documentation](https://esotericsoftware.com/spine-skins) for details on this process.

Create a single skin and call it something like "template". Apply default textures to all of the slots in your skeleton so that the template skin is populating all of the slots. You can use these default textures to preview your animations during the art process.

It is possible to create skins completely dynamically at runtime but creating a template skin allows you to visually adjust the offsets, rotations, and other information that would be challenging and slow to do programmatically.

Here's an example of a Spine project with several placeholder slots and a single "template" skin:

<figure><img src="../.gitbook/assets/image (154).png" alt=""><figcaption><p>A Spine project with placeholders and a single template skin.</p></figcaption></figure>

### Change Skins at Runtime

The placeholder slots on your skin will be converted to a specific type of `Attachment` called a `RegionAttachment` which contains atlas texture region information that should be rendered in the slot on the skeleton.

You can change the region attachment on a skin at runtime using the `SetDynamicTextureOnSkin` method in the `SpineDrawableBatch`. This method takes a `Skin` , the placeholder name, an `Atlas`, and the atlas texture name. It swaps the texture on the placeholder and optionally applies it immediately to the skin. This method allows you to dynamically change any slot on the skin with any atlas texture you provide. However, it has a major drawback. Skins are shared across skeleton instances in the Spine Runtime for performance reasons. This means, if you change a placeholder on a skin, it changes the skin for every creature in your game using that skin!

> NOTE: you can get any skin on a skeleton by calling `Skeleton.FindSkin(skinName)`. Use this to get a skin reference to provide to the `SetDynamicTextureOnSkin` method!

To work around the issue of shared skins, you can create a dynamic skin that contains the unique attachment changes you want using the `GetOrCreateDynamicSkinFromTemplate` method on the `SpineDrawableBatch`. This allows you to create a named dynamic skin, make changes, and apply it to a skeleton instance without affecting other instances. Here is how you could combine these methods to create and apply a dynamic runtime skin in a FlatRedBall entity that contains a spine character (`SpineDrawableBatch`).

```csharp
public void SetUniqueSkin()
{
   var dynamicSkinName = "myDynamicSkin";
   
   // this assumes your template skin is called "template"!
   var dynamicSkin = SpineInstance
      .GetOrCreateDynamicSkinFromTemplate("template", dynamicSkinName);
   
   // set the "head" slot on the skin to the "goblinHead" head from the atlas      
   SpineInstance
      .SetDynamicTextureOnSkin(dynamicSkin, "head", myAtlas, "goblinHead");
}
```

> NOTE: if "myDynamicSkin" already exists on the skeleton, it will be retrieved instead of creating a new skin. This allows you change attachments on the dynamic skin multiple times with accidentally creating a large number of dynamic skins that aren't used! But this also means that multiple instances using the same skin name could change each others' appearance.

The Spine Runtime shares skins for performance reasons. Therefore, it is good to assume that creating a very large number of skins could cause problems. It is recommended that you have a deterministic naming pattern for your dynamic skins that avoids creating duplicate skins with the same information. For example, you might use `[creature name]_[weapon_name]` as a convention so you create dynamic skins for "goblin\_sword", "goblin\_club", "troll\_sword", and "troll\_club" that are shared across many instances of those creatures without creating a dynamic skin for every single creature instance.

### Other Approaches

There are three unique approaches to customizing Spine skeletons. This document mentions two but it may be useful to understand each approach and its tradeoffs.

#### Approach 1: Author Time

In this approach, the artist creates partial skins for each section of the skeleton (creature, weapons, armor for example). At runtime you apply a skin for each section and they stack. This approach is simple but puts a large workload on the artist.

#### Approach 2: Template Skin

This is the approach described here. It creates one skin with all slots populated and a skeleton only has this full skin applied. It is relatively simple and takes a lot of pressure off the artist. However, if you have a large number of slots, having a huge number of combinatorial skins may lead to performance problems in the game.

#### Approach 3: Dynamic Partial Skins

A final approach, which is much more complex and not described here, would be to create partial skins in code and stack them so that the skeleton is wearing a stack of dynamic skins. This approach _may_ be more performant at very large scale but is complex to create and the FlatRedBall implementation doesn't have any specific APIs supporting this approach.
