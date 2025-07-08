using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FruitItem", menuName = "Frutas")]
public class FruitsScriptable : ScriptableObject
{
    [Header("Model")]
    public Mesh fruitMesh;
    public Material fruitMaterial;
    [Header("Stats")]
    [Range(.1f, 2f)]
    public float size;
    [Range(1, 100)]
    public float speed;
    [Range(1, 100)]
    public float speedY;

    public GameObject DestroyFruit;

}
