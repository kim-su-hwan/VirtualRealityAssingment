using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHot : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    int is_filled = 0;

    void Start()
    {
        mesh = transform.Find("water").GetComponent<MeshRenderer>();
        mat = mesh.material;
        Debug.Log(mat);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Plane"))
        {
            if (collision.gameObject.name == "Pot" && is_filled==0)
            {
                mat.color = new Color(118 / 255f, 255 / 255f, 255 / 255f, 130 / 255f);
                is_filled = 1;
                Debug.Log(mat.color);
            }
            else if(mat.color == new Color(118 / 255f, 255 / 255f, 255 / 255f, 130 / 255f))
            {
                Debug.Log("water filled");
            }
        }
    }
}