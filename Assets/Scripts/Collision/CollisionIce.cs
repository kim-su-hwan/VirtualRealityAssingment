using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionIce : MonoBehaviour
{
    // 0: water, 1: coffee, 2: ice, 3: milk, 4: strawberry, 5: sprite, 6 : mocha
    int[] arr = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
    List<int> seq = new List<int>();
    bool is_Empty;

    GameObject beverage;
    GameObject pointCalc;
    MeshRenderer mesh;
    Material mat;

    public GameObject iceobj;
    public GameObject obj;
    Vector3 scale;

    void Start()
    {
        pointCalc = GameObject.Find("Point");
        is_Empty = true;
        seq.Add(-1);
        beverage = transform.Find("beverage").gameObject;
        mesh = beverage.GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Plane"))
        {
            // Ice 오브젝트와 충돌시 컵 안에(Vector3로 직접 좌표 넣어줌) IceInCup 오브젝트 생성
            if (collision.gameObject.name == "Ice")
            {
                // 컵안에 다른 내용물이 있었던 경우 양이 불어나도록 조정
                if (!is_Empty)
                {
                    beverage.transform.localScale += new Vector3(0.04f, 0.1f, 0.04f);
                   
                }
                Destroy(collision.gameObject, 0.0f);

                GameObject ice = Instantiate(iceobj, transform.position + new Vector3(-0.3f, -0.15f, 0), Quaternion.identity);
                ice.transform.parent = this.transform;
                arr[Constant.ice] += 1;
                add_seq(Constant.ice);
            }
            // Espresso 오브젝트와 충돌시 내용물이 color_coffee 색으로 바뀜
            // Espresso machine 클릭시 Espresso(Clone) 오브젝트가 생성됨
            else if (collision.gameObject.name == "Espresso" || collision.gameObject.name == "Espresso(Clone)")
            {
                Destroy(collision.gameObject, 0.0f);
                beverage.transform.localScale += new Vector3(0.04f, 0.1f, 0.04f);
                if (arr[Constant.milk] != 0)
                {
                    mat.color = Constant.color_latte;
                }
                else
                {
                    mat.color = Constant.color_coffee;
                }
                is_Empty = false;
                arr[Constant.coffee] += 1;
                add_seq(Constant.coffee);
            }
            // Spoon 오브젝트와 충돌시 내용물이 color_strawberry 색으로 바뀜
            else if (collision.gameObject.name == "Spoon")
            {
                if (!collision.gameObject.GetComponent<CollisionSpoon>().get_Empty())
                {
                    arr[Constant.strawberry] += 1;
                    if (arr[Constant.coffee] == 0)
                    {
                        mat.color = Constant.color_strawberry;
                    }
                    beverage.transform.localScale += new Vector3(0.06f, 0.15f, 0.06f);
                    add_seq(Constant.strawberry);
                    collision.gameObject.GetComponent<CollisionSpoon>().set_Empty(true);
                    is_Empty = false;
                }
            }
            over_check(beverage.transform.localScale[1]);

            if (collision.gameObject.name == "Submit")
            {
                pointCalc.GetComponent<PointCalc>().ScoreCalculation(arr, seq);
                Destroy(transform.gameObject);
                Debug.Log(pointCalc.GetComponent<PointCalc>().GetScore());
                GameObject.Find("Managers").GetComponent<ScoreControll>().ShowScore();
                GameObject.Find("Guest(Clone)").GetComponent<GuestMove>().OrderClear();
            }
        }
    }

    // 파티클 충돌 횟수만큼 컵 안에 있는 물의 양이 늘어남(402회 이상 충돌시 내용물이 넘친 것으로 간주하고 cup오브젝트를 삭제함)
    void OnParticleCollision(GameObject other)
    {
        float x = Math.Abs(transform.rotation.eulerAngles[0]) % 360.0f;
        float z = Math.Abs(transform.rotation.eulerAngles[2]) % 360.0f;
        // 컵이 너무 기울어진 경우 내용물이 담기지 않음
        if (((x <= 45 && x >= 0) || (x >= 315 && x <= 360)) && ((z <= 45 && z >= 0) || (z >= 315 && z <= 360)))
        {
            beverage.transform.localScale += new Vector3(0.001f, 0.0025f, 0.001f);

            // 충돌한 Particle의 이름이 water인 경우
            // 컵에 커피나 우유가 들어있지 않은 경우에만 water_color값을 적용
            if (other.name == "water")
            {
                if(arr[Constant.coffee] == 0 && arr[Constant.milk] == 0)
                {
                    mat.color = Constant.color_water;
                }
                arr[Constant.water] += 1;
                add_seq(Constant.water);
            }
            // 충돌한 Particle의 이름이 milk인 경우
            // 커피, 딸기청이 들어있지 않은 경우에만 milk_color값을 적용
            if (other.name == "milk")
            {
                if (arr[Constant.coffee] == 0 && arr[Constant.milk] == 0 && arr[Constant.strawberry] == 0)
                {
                    scale = beverage.transform.localScale;
                    Destroy(beverage, 0.0f);
                    beverage = Instantiate(obj, beverage.transform.position, beverage.transform.rotation);
                    beverage.transform.parent = gameObject.transform;
                    beverage.transform.localScale = scale;
                    mesh = beverage.GetComponent<MeshRenderer>();
                    mat = mesh.material;
                    mat.color = Constant.color_milk;
                }
                arr[Constant.milk] += 1;
                add_seq(Constant.milk);
            }
            // 충돌한 Particle의 이름이 sprite인 경우
            if (other.name == "sprite")
            {
                if (is_Empty)
                {
                    mat.color = Constant.color_water;
                }
                arr[Constant.sprite] += 1;
                add_seq(Constant.sprite);
            }
            // 충돌한 Particle의 이름이 mocha인 경우
            if (other.name == "mocha")
            {
                mat.color = Constant.color_latte;
                arr[Constant.mocha] += 1;
                add_seq(Constant.mocha);
            }
            is_Empty = false;
            over_check(beverage.transform.localScale[1]);
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

    // 순서 저장
    void add_seq(int n)
    {
        if(seq[seq.Count -1] != n)
        {
            seq.Add(n);
        }
    }

    void printList(List<int> l)
    {
        for (int i = 0; i < l.Count; i++)
        {
            Debug.Log("seq " + i.ToString() + ": " + l[i].ToString());
        }
    }
    void printArr(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Debug.Log("index " + i.ToString() + ": " + a[i].ToString());
        }
    }
}