using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionIce : MonoBehaviour
{
    // 0: water, 1: coffee, 2: ice, 3: milk
    int[] list = new int[4] { 0, 0, 0, 0 };
    bool is_Empty = true;

    GameObject beverage;
    MeshRenderer mesh;
    Material mat;

    public GameObject iceobj;
    public GameObject obj;
    Vector3 scale;

    Color color_water = new Color(118 / 255f, 255 / 255f, 255 / 255f, 70 / 255f);
    Color color_coffee = new Color(77 / 255f, 54 / 255f, 56 / 255f, 255 / 255f);
    Color color_milk = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);

    void Start()
    {
        beverage = transform.Find("beverage").gameObject;
        mesh = beverage.GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Plane"))
        {
            // 빈 컵인 경우(step0), Ice 오브젝트와 충돌시 컵 안에(Vector3로 직접 좌표 넣어줌) IceInCup 오브젝트 생성
            if (collision.gameObject.name == "Ice")
            {
                // 컵안에 다른 내용물이 있었던 경우 내용물이 양이 불어나도록 조정
                if (!is_Empty)
                {
                    beverage.transform.localScale += new Vector3(0.08f, 0.2f, 0.08f);
                    over_check(beverage.transform.localScale[1]);
                }
                Destroy(collision.gameObject, 0.0f);

                GameObject ice = Instantiate(iceobj, transform.position + new Vector3(-0.3f, -0.15f, 0), Quaternion.identity);
                ice.transform.parent = this.transform;
                is_Empty = false;
                list[2] += 1;
            }
            // 얼음과 물이 들어있는 경우(step2), Espresso 오브젝트와 충돌시 내용물이 color_coffee 색으로 바뀜
            // Espresso machine 클릭시 Espresso(Clone) 오브젝트가 생성됨
            else if (collision.gameObject.name == "Espresso(Clone)")
            {
                Destroy(collision.gameObject, 0.0f);
                beverage.transform.localScale += new Vector3(0.08f, 0.2f, 0.08f);
                over_check(beverage.transform.localScale[1]);
                mat.color = color_coffee;
                is_Empty = false;
                list[1] += 1;
            }
        }
    }

    // 파티클 충돌 횟수만큼 컵 안에 있는 물의 양이 늘어남(402회 이상 충돌시 내용물이 넘친 것으로 간주하고 cup오브젝트를 삭제함)
    void OnParticleCollision(GameObject other)
    {
        float x = Math.Abs(transform.rotation.eulerAngles[0]) % 360.0f;
        float z = Math.Abs(transform.rotation.eulerAngles[2]) % 360.0f;
        // 컵이 너무 기울어진 경우 물이 담기지 않음
        if (((x <= 45 && x >= 0) || (x >= 315 && x <= 360)) && ((z <= 45 && z >= 0) || (z >= 315 && z <= 360)))
        {
            beverage.transform.localScale += new Vector3(0.001f, 0.0025f, 0.001f);
            Debug.Log(list[0]);
            over_check(beverage.transform.localScale[1]);

            // 충돌한 Particle의 이름이 water인 경우
            // 컵에 커피나 우유가 들어있지 않은 경우에만 water_color값을 적용
            if (list[1]<1 && list[3]<1 && other.name == "water")
            {
                list[0] += 1;
                mat.color = color_water;
            }
            // 충돌한 Particle의 이름이 milk인 경우
            // 커피가 들어있지 않은 경우에만 milk_color값을 적용
            if (list[1] < 1 && other.name == "milk")
            {
                if (list[3] == 0)
                {
                    scale = beverage.transform.localScale;
                    Destroy(beverage, 0.0f);
                    beverage = Instantiate(obj, beverage.transform.position, beverage.transform.rotation);
                    beverage.transform.parent = gameObject.transform;
                    beverage.transform.localScale = scale;
                    mesh = beverage.GetComponent<MeshRenderer>();
                    mat = mesh.material;
                }
                list[3] += 1;
                mat.color = color_milk;
            }
            is_Empty = false;
        }
    }

    // 컵의 내용물이 넘쳤는지 확인
    void over_check(float n)
    {
        if (n >= 1.035)
        {
            Debug.Log("over");
            Destroy(transform.gameObject);
        }
    }
}