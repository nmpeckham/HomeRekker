using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject
{
    internal int shape;
    internal int material;
    internal string name = "";

    public PlaceableObject(int _shape, int _material)
    {
        shape = _shape;
        material = _material;
        name = GameData.objectShapes[shape];
    }
}
