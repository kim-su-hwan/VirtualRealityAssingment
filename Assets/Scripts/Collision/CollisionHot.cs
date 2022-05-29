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
            // 빈 컵인 경우, Pot 오브젝트와 충돌시 투명했던 내용물이 color_water 색으로 바뀜
            if (collision.gameObject.name == "Pot" && !is_filled)
            {
                mat.color = color_water;
                is_filled = true;
            }
            // 빈 컵이 아닌 경우, Espresso 오브젝트와 충돌시 내용물이 color_coffee 색으로 바뀜
            // Espresso machine 클릭시 Espresso(Clone) 오브젝트가 생성됨
            else if (mat.color == color_water && (collision.gameObject.name == "Espresso" || collision.gameObject.name == "Espresso(Clone)"))
            {
                Debug.Log("water filled");
                mat.color = color_coffee;
                Destroy(collision.gameObject, 0.0f);
            }
        }
    }
}