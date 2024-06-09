# Collisions

The Collisions object is a List\<TileShapeCollection>. When a LayeredTileMap is created (usually from TMX), each tile layer is checked for tiles with shapes. If any tiles on a layer contain shapes (defined in the Tileset), then a TileShapeCollection will be created for that layer. If tiles have shapes defined, but do not have a Type defined, then the name of the TileShapeCollection matches the name of the layer. If a tile defines a type, then the TileShapeCollection will be named after the Type.

Note that this is populated from the shapes added to tiles in the tileset, as opposed to the ShapeCollections object which is populated based on shapes added to object layers.
