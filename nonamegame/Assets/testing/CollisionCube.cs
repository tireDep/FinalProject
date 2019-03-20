using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCube : MonoBehaviour
{
    Material material;
    Color baseColor;
    void OnCollisionEnter(Collision collision)
    {
        material.color = Color.yellow;
    }

    void OnCollisionExit(Collision collision)
    {
        material.color = baseColor;
    }
}
