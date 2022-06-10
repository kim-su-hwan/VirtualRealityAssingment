using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuSystem : MonoBehaviour
{

    public Queue<string> menu_name = new Queue<string>();
    [SerializeField] private TextMeshProUGUI menutext;
    public string now_order;
    private void Start()
    {
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
        int num = Random.Range(0, 10);
        switch (num)
        {
            case 0:
                return "ICE Americano";
            case 1:
                return "ICE Caffee Latte";
            case 2:
                return "ICE Vanilla Latte";
            case 3:
                return "ICE Mocha Latte";
            case 4:
                return "ICE Strawberry Ade";
            case 5:
                return "ICE GreenTea Latte";
            case 6:
                return "Hot Americano";
            case 7:
                return "HOT Caffee Latte";
            case 8:
                return "HOT Vanilla Latte";
            case 9:
                return "HOT Mocha Latte";
            default:
                return null;
        }
    }
}
