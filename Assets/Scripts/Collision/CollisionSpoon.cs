using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSpoon : MonoBehaviour
{
    MeshRenderer mesh;
    Material mat;
    GameObject jam;
    bool is_Empty;

    void Start()
    {
        is_Empty = true;
        jam = transform.Find("jam").gameObject;
        mesh = jam.GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Plane"))
        {
            if(collision.gameObject.name == "Strawberry")
            {
                is_Empty = false;
                mat.color = Constant.color_strawberry;
            }
            if(collision.gameObject.name == "IceCup")
            {
                mat.color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 0 / 255f);
            }
        }
    }
    public bool get_Empty()
    {
        return is_Empty;
    }
    public void set_Empty(bool e)
    {
        is_Empty = e;
    }
}
