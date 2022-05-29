using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    public static ObjectControll objcon_instance;
    [SerializeField] private GameObject iceCup;

    private void Awake()
    {
        if (objcon_instance == null)
        {
            objcon_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void InstantiateIceCup( GameObject location)
    {
        Instantiate(iceCup, new Vector3(location.transform.position.x,
            location.transform.position.y, location.transform.position.z), Quaternion.identity);
    }



}
