using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionHot : MonoBehaviour
{
    // 0: water, 1: coffee, 2: ice, 3: milk
    int[] arr = new int[4] {0, 0, 0, 0};
    List<int> seq = new List<int>();

    GameObject beverage;
    GameObject pointCalc;

    public GameObject obj;
    MeshRenderer mesh;
    Material mat;

    void Start()
    {
        seq.Add(-1);
        pointCalc = GameObject.Find("Scripts");
        beverage = transform.Find("beverage").gameObject;
        mesh = beverage.GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.name == "Plane"))
        {
            // �� ���� �ƴ� ���, Espresso ������Ʈ�� �浹�� ���빰�� color_coffee ������ �ٲ�
            // Espresso machine Ŭ���� Espresso(Clone) ������Ʈ�� ������
            if (collision.gameObject.name == "Espresso" || collision.gameObject.name == "Espresso(Clone)")
            {
                arr[Constant.coffee] += 1;
                mat.color = Constant.color_coffee;
                beverage.transform.Translate(new Vector3(0, 0.02f, 0), Space.Self);
                Destroy(collision.gameObject, 0.0f);
                add_seq(Constant.coffee);
            }
            over_check(beverage.transform.localPosition[1]);

            if (collision.gameObject.name == "Submit")
            {
                pointCalc.GetComponent<PointCalc>().ScoreCalculation(arr, seq);
                Destroy(transform.gameObject);
                Debug.Log(pointCalc.GetComponent<PointCalc>().GetScore());
            }
        }
    }

    // ��ƼŬ �浹 Ƚ����ŭ �� �ȿ� �ִ� ���� ���� �þ(441ȸ �̻� �浹�� ���빰�� ��ģ ������ �����ϰ� cup������Ʈ�� ������)
    void OnParticleCollision(GameObject other)
    {
        float x = Math.Abs(transform.rotation.eulerAngles[0]) % 360.0f;
        float z = Math.Abs(transform.rotation.eulerAngles[2]) % 360.0f;

        // ���� �ʹ� ������ ��� ���� ����� ����
        if (((x <= 45 && x >= 0) || (x >= 315 && x <= 360)) && ((z <= 45 && z >= 0) || (z >= 315 && z <= 360)))
        {
            beverage.transform.Translate(new Vector3(0, 0.0005f, 0), Space.Self);
            over_check(beverage.transform.localPosition[1]);

            // �浹�� Particle�� �̸��� water�� ���
            // �ſ� Ŀ�ǳ� ������ ������� ���� ��쿡�� water_color���� ����
            if (other.name == "water")
            {
                if(arr[Constant.coffee] == 0 && arr[Constant.milk] == 0)
                {
                    mat.color = Constant.color_water;
                }
                arr[Constant.water] += 1;
                add_seq(Constant.water);
            }
            // �浹�� Particle�� �̸��� milk�� ���
            // Ŀ�ǰ� ������� ���� ��쿡�� milk_color���� ����
            if (other.name == "milk")
            {
                if (arr[Constant.coffee] == 0 && arr[Constant.milk] == 0)
                {
                    Destroy(beverage, 0.0f);
                    beverage = Instantiate(obj, beverage.transform.position, beverage.transform.rotation);
                    beverage.transform.parent = gameObject.transform;
                    mesh = beverage.GetComponent<MeshRenderer>();
                    mat = mesh.material;
                    mat.color = Constant.color_milk;
                }
                arr[Constant.milk] += 1;
                add_seq(Constant.milk);
            }
        }
    }

    // ���� ���빰�� ���ƴ��� Ȯ��
    void over_check(float n)
    {
        if (n >= 0.02)
        {
            Debug.Log("over");
            Destroy(transform.gameObject);
        }
    }

    // ���� ����
    void add_seq(int n)
    {
        if (seq[seq.Count - 1] != n)
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
            Debug.Log("index " + i.ToString() + " : " + a[i].ToString());
        }
    }
}