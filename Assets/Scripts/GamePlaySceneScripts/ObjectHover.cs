using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHover : MonoBehaviour
{
    [SerializeField] private GameObject nameCanvas;


    public void OnMenu()
    {
        nameCanvas.SetActive(true);
    }

    public void OffMenu()
    {
        nameCanvas.SetActive(false);
    }

}
