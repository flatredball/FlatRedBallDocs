## Introduction

The Z value controls the ordering of the batch relative to other batches, z-ordered sprites and text objects. Since the rendering performed in IDrawableBatches may be preceded and followed by other FlatRedBall rendeing calls, render states are *not* preserved between DrawableBatch Draw calls.
