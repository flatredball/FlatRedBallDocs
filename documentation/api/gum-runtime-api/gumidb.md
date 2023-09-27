## Introduction

GumIdb (which stands for Gum IDrawableBatch) provides the IDrawableBatch implementation which allows the Gum rendering engine to render within a FlatRedBall game. All FlatRedBall games which use Gum must create a GumIdb instance. The Gum plugin automatically creates a GumIdb instance whenever a Gum screen is added to a FlatRedBall screen, so most games do not need to manually create or add a GumIdb instance.  
