using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScripts : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    bool is_filled = false;
    Color color_water = new Color(118 / 255f, 255 / 255f, 255 / 255f, 130 / 255f);
    Color color_coffee = new Color(77 / 255f, 54 / 255f, 56 / 255f, 255 / 255f);

    void Start()
    {
        mesh = transform.Find("fluid").GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
