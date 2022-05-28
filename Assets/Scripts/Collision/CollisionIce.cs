using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIce : MonoBehaviour
{
    public GameObject iceobj;
    MeshRenderer mesh;
    Material mat;
    int is_step = 0;
    Color color_water = new Color(0 / 255f, 52 / 255f, 55 / 255f, 60 / 255f);
    Color color_coffee = new Color(77 / 255f, 54 / 255f, 56 / 255f, 255 / 255f);

    void Start()
    {
        mesh = transform.Find("fluid").GetComponent<MeshRenderer>();
        mat = mesh.material;
        Debug.Log(mat);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.position);
        if (!(collision.gameObject.name == "Plane"))
        {
            if (collision.gameObject.name == "Ice" && is_step == 0)
            {
                Destroy(collision.gameObject, 0.0f);
                
                GameObject ice = Instantiate(iceobj, transform.position + new Vector3(-0.3f,-0.15f,0), Quaternion.identity);
                ice.transform.parent=this.transform;
                is_step += 1;
            }
            else if (is_step == 1 && collision.gameObject.name == "Pot")
            {
                mat.color = color_water;
                is_step += 1;
            }
            else if (is_step == 2 && collision.gameObject.name == "Espresso(Clone)")
            {
                Destroy(collision.gameObject, 0.0f);
                mat.color = color_coffee;
                is_step += 1;
            }
        }
    }
}