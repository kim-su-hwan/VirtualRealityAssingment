using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuSystem : MonoBehaviour
{

    public Queue<string> menu_name = new Queue<string>();
    [SerializeField] private TextMeshProUGUI menutext;
    public string now_order;
    GameObject pointCalc;

    private void Start()
    {
        pointCalc = GameObject.Find("Point");
        for (int i = 0; i < 5; i++)
        {
            menu_name.Enqueue(RandomMenu());
        }
        //        ShowMenu();
    }

    public void ShowMenu()
    {
        if (menu_name.Count > 0)
        {
            now_order = menu_name.Dequeue();
            menutext.text = "Order Menu : " + now_order;
        }
    }



    private string RandomMenu()
    {
        int num = Random.Range(0, 5);
        switch (num)
        {
            case 0:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.americano_ice);
                return "ICE Americano";
            case 1:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.americano_hot);
                return "HOT Americano";
            case 2:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.strawberryAid);
                return "ICE Strawberry Ade";
            case 3:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.mochaLatte_ice);
                return "ICE Mocha Latte";
            case 4:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.mochaLatte_hot);
                return "HOT Mocha Latte";
            case 5:
                return "ICE GreenTea Latte";
            case 6:
                return "ICE Caffee Latte";
            case 7:
                return "HOT Caffee Latte";
            case 8:
                return "HOT Vanilla Latte";
            case 9:
                return "ICE Vanilla Latte";
            default:
                return null;
        }
    }
}
