using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    internal static int playerFunds = 100;

    internal static Dictionary<int, string> objectMaterials = new Dictionary<int, string>
    {
        {0, "Hay" },
        {1, "Wood" },
        {2, "Metal" }
    };

    internal static Dictionary<int, string> objectShapes = new Dictionary<int, string>
    {
        {0, "Cube" },
        {1, "Rectangle" },
        {2, "L" },
        {3, "Hut" },
        {4, "Triangle" },
        {5, "Sphere" }
    };

    internal static Dictionary<string, int> itemPrices = new Dictionary<string, int>
    {
            {"Cube-Hay", 5 },
            {"Cube-Wood", 8 },
            {"Cube-Metal", 15 },
            {"Rectangle-Hay", 4 },
            {"Rectangle-Wood", 6 },
            {"Rectangle-Metal",  12 },
            {"L-Hay", 3 },
            {"L-Wood", 7 },
            {"L-Metal", 10 },
            {"Hut-Hay", 9 },
            {"Hut-Wood", 14 },
            {"Hut-Metal", 18 },
            {"Triangle-Hay", 7 },
            {"Triangle-Wood", 10 },
            {"Triangle-Metal", 13 },
            {"Sphere-Hay", 2 },
            {"Sphere-Wood", 4 },
            {"Sphere-Metal", 6 }
    };

    internal static bool mouseOnPlayArea = true;

    internal static Dictionary<string, GameObject> primitives = new Dictionary<string, GameObject>
        {
            {"Cube-Hay", Resources.Load<GameObject>("Prefabs/Cube-Hay") },
            {"Cube-Wood", Resources.Load<GameObject>("Prefabs/Cube-Wood") },
            {"Cube-Metal", Resources.Load<GameObject>("Prefabs/Cube-Metal") },
            {"Rectangle-Hay", Resources.Load<GameObject>("Prefabs/Rectangle-Hay") },
            {"Rectangle-Wood", Resources.Load<GameObject>("Prefabs/Rectangle-Wood") },
            {"Rectangle-Metal",  Resources.Load<GameObject>("Prefabs/Rectangle-Metal")},
            {"L-Hay", Resources.Load<GameObject>("Prefabs/L-Hay") },
            {"L-Wood", Resources.Load<GameObject>("Prefabs/L-Wood") },
            {"L-Metal", Resources.Load<GameObject>("Prefabs/L-Metal") },
            {"Hut-Hay", Resources.Load<GameObject>("Prefabs/Hut-Hay") },
            {"Hut-Wood", Resources.Load<GameObject>("Prefabs/Hut-Wood") },
            {"Hut-Metal", Resources.Load<GameObject>("Prefabs/Hut-Metal") },
            {"Triangle-Hay", Resources.Load<GameObject>("Prefabs/Triangle-Hay") },
            {"Triangle-Wood", Resources.Load<GameObject>("Prefabs/Triangle-Wood") },
            {"Triangle-Metal", Resources.Load<GameObject>("Prefabs/Triangle-Metal") },
            {"Sphere-Hay", Resources.Load<GameObject>("Prefabs/Sphere-Hay") },
            {"Sphere-Wood", Resources.Load<GameObject>("Prefabs/Sphere-Wood") },
            {"Sphere-Metal", Resources.Load<GameObject>("Prefabs/Sphere-Metal") }
        };
}
