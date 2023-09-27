## Introduction

IAnimationChainAnimatable-implementing objects should automatically update their displayed frame according to time. It is possible that a frame may last less than one frame of game time - if the game is running slowly or if the frame is of very short duration. Sprites, for example, will skip frames if the timing advances far enough. Not all frames are guaranteed to play.
