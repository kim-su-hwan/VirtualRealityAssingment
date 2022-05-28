using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHot : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    bool is_filled = false;
    Color color_water = new Color(118 / 255f, 255 / 255f, 255 / 255f, 130 / 255f);
    Color color_coffee = new Color(77 / 255f, 54 / 255f, 56 /255f, 255 / 255f);
    void Start()
    {
        mesh = transform.Find("fluid").GetComponent<MeshRenderer>();
        mat = mesh.material;
        Debug.Log(mat);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Plane"))
        {
            if (collision.gameObject.name == "Pot" && !is_filled)
            {
                mat.color = color_water;
                is_filled = true;
            }
            else if(mat.color == color_water && (collision.gameObject.name == "Espresso" || collision.gameObject.name == "Espresso(Clone)"))
            {
                Debug.Log("water filled");
                mat.color = color_coffee;
                Destroy(collision.gameObject, 0.0f);
            }
        }
    }
}