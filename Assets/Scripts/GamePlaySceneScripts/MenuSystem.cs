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
        int num = Random.Range(0, 6);
        switch (num)
        {
            case 0:
                return "Americano";
            case 1:
                return "Caffee Latte";
            case 2:
                return "Vanilla Latte";
            case 3:
                return "Mocha Latte";
            case 4:
                return "Strawberry Ade";
            case 5:
                return "GreenTea Latte";
            default:
                return null;
        }
    }
}
