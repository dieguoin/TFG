using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knive : MonoBehaviour
{
    private BoxCollider bc;
    public void ChangeCollider(float scale)
    {
        bc.size = bc.size * scale;
    }
}
