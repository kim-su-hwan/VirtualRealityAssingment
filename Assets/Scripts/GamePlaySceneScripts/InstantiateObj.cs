using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InstantiateObj : MonoBehaviour
{
    [SerializeField] private GameObject milk;
    [SerializeField] private GameObject milk_respon;
    [SerializeField] private GameObject sprite;
    [SerializeField] private GameObject sprite_respon;

    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject ice_respon;
    [SerializeField] private GameObject coffee;
    [SerializeField] private GameObject coffee_respon;


    public void InitMilk()
    {
        Instantiate(milk, milk_respon.transform);
    }
    public void InitSprite()
    {
        Instantiate(sprite, sprite_respon.transform);
    }
    public void InitIce()
    {
        Instantiate(ice, ice_respon.transform);
    }
    public void InitCoffee()
    {
        Instantiate(coffee, coffee_respon.transform);
    }


}
