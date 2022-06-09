using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GuestMove : MonoBehaviour
{
    NavMeshAgent nav_agent;
    bool isShow = false;
    private void Awake()
    {
        nav_agent = gameObject.GetComponent<NavMeshAgent>();
        nav_agent.SetDestination(GameObject.Find("GuestDestination").transform.position);
    }

    private void Update()
    {
        IsArrive();
    }

    public void IsArrive()
    {
        if(nav_agent.remainingDistance < 0.1f)
        {
            if (!isShow)
            {
                GameObject.Find("Managers").GetComponent<MenuSystem>().ShowMenu();
                isShow = true;
            }
        }
    }

    public void OrderClear()
    {

        GuestControll.guestcon_instance.isOrderClear = true;
        Destroy(this.gameObject);
    }

}
