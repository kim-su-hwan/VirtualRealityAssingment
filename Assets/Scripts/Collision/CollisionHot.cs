using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionHot : MonoBehaviour
{
    // 0: water, 1: coffee, 2: ice, 3: milk
    int[] list = new int[4] {0, 0, 0, 0};
    bool is_Empty = true;

    GameObject beverage;
    public GameObject obj;
    MeshRenderer mesh;
    Material mat;

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
            // �� ���� �ƴ� ���, Espresso ������Ʈ�� �浹�� ���빰�� color_coffee ������ �ٲ�
            // Espresso machine Ŭ���� Espresso(Clone) ������Ʈ�� ������
            if (collision.gameObject.name == "Espresso" || collision.gameObject.name == "Espresso(Clone)")
            {
                list[1] += 1;
                mat.color = color_coffee;
                beverage.transform.Translate(new Vector3(0, 0.02f, 0), Space.Self);
                Debug.Log(list);
                Destroy(collision.gameObject, 0.0f);
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
            Debug.Log(list[0]);
            over_check(beverage.transform.localPosition[1]);

            // �浹�� Particle�� �̸��� water�� ���
            // �ſ� Ŀ�ǳ� ������ ������� ���� ��쿡�� water_color���� ����
            if (list[1] < 1 && list[3] < 1 && other.name == "water")
            {
                list[0] += 1;
                mat.color = color_water;
            }
            // �浹�� Particle�� �̸��� milk�� ���
            // Ŀ�ǰ� ������� ���� ��쿡�� milk_color���� ����
            if (list[1] < 1 && other.name == "milk")
            {
                if (list[3] == 0)
                {
                    Destroy(beverage, 0.0f);
                    beverage = Instantiate(obj, beverage.transform.position, beverage.transform.rotation);
                    beverage.transform.parent = gameObject.transform;
                    mesh = beverage.GetComponent<MeshRenderer>();
                    mat = mesh.material;
                }
                list[3] += 1;
                mat.color = color_milk;
            }
            is_Empty = false;
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
}