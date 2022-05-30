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
        Debug.Log(transform.Find("fluid").gameObject.name);
        Debug.Log(is_step);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.position);
        if (!(collision.gameObject.name == "Plane"))
        {
            Debug.Log(is_step);
            // 빈 컵인 경우(step0), Ice 오브젝트와 충돌시 컵 안에(Vector3로 직접 좌표 넣어줌) IceInCup 오브젝트 생성
            if (collision.gameObject.name == "Ice" && is_step == 0)
            {
                Destroy(collision.gameObject, 0.0f);

                GameObject ice = Instantiate(iceobj, transform.position + new Vector3(-0.3f, -0.15f, 0), Quaternion.identity);
                ice.transform.parent = this.transform;
                is_step += 1;
            }
            // 얼음이 들어있는 경우(step1), Pot 오브젝트와 충돌시 투명했던 내용물이 color_water 색으로 바뀜
            else if (is_step == 1 && collision.gameObject.name == "Pot")
            {
                mat.color = color_water;
                is_step += 1;
            }
            // 얼음과 물이 들어있는 경우(step2), Espresso 오브젝트와 충돌시 내용물이 color_coffee 색으로 바뀜
            // Espresso machine 클릭시 Espresso(Clone) 오브젝트가 생성됨
            else if (is_step == 2 && collision.gameObject.name == "Espresso(Clone)")
            {
                Destroy(collision.gameObject, 0.0f);
                mat.color = color_coffee;
                is_step += 1;
            }
        }
    }
}