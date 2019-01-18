using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Tiled2Unity;

[Tiled2Unity.CustomTiledImporter]
class TerrainTileImporter : Tiled2Unity.ICustomTiledImporter
{
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> props)
    {
        if (props["Type"] == "Ground")
        {
            gameObject.layer = LayerMask.NameToLayer("Ground");

            var collider = gameObject.GetComponent<Collider2D>();
            collider.isTrigger = true;
        }
    }


    public void CustomizePrefab(GameObject prefab)
    {
    }
}