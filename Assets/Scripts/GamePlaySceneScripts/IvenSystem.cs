using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IvenSystem : MonoBehaviour
{
    public static IvenSystem iven_instance;

    public int coffee = 0;
    public int water = 0;
    public int milk = 0;
    public int vanilla_syrup = 0;
    public int mocha_syrup = 0;
    public int greenTea = 0;
    public int sprite = 0;


    private void Awake()
    {
        if (iven_instance == null)
        {
            iven_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    private void Start()
    {

    }

    public void InitIven()
    {
        coffee = 0;
        water = 0;
        milk = 0;
        vanilla_syrup = 0;
        mocha_syrup = 0;
        greenTea = 0;
        sprite = 0;
}

    public void AddCoffee()
    {
        coffee++;
    }
    public void AddWater()
    {
        water++;
    }
    public void AddMilk()
    {
        milk++;
    }
    public void AddVanilla()
    {
        vanilla_syrup++;
    }

    public void AddMocha()
    {
        mocha_syrup++;
    }
    public void AddGreenTea()
    {
        greenTea++;
    }
    public void AddSprite()
    {
        sprite++;
    }


}
