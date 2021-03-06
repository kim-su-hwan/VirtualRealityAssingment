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

    int i = 0;

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
        //int num = Random.Range(0, 10);
        int num = i++;
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
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.cafeLatte_ice);
                return "ICE Caffee Latte"; 
            case 6:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.cafeLatte_hot);
                return "HOT Caffee Latte";
            case 7:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.vanillaLatte_ice);
                return "ICE Vanilla Latte";
            case 8:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.vanillaLatte_hot);
                return "HOT Vanilla Latte";
            case 9:
                pointCalc.GetComponent<PointCalc>().AddOrder(Constant.greenTeaLatte_ice);
                return "ICE GreenTea Latte"; 
            default:
                return null;
        }
    }
}
