using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuestControll : MonoBehaviour
{
    public static GuestControll guestcon_instance;
    [SerializeField] private GameObject guest;
    [SerializeField] private GameObject guestinit;
    [HideInInspector] public bool isOrderClear = true;

    private void Awake()
    {
        if (guestcon_instance == null)
        {
            guestcon_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOrderClear == true)
        {
            Instantiate(guest,guestinit.transform);
            isOrderClear = false;
        }
    }
}
