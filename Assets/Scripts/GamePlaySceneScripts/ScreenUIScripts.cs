using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScreenUIScripts : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;

    private void FixedUpdate()
    {
        UpdateTimer();
    }
    public void UpdateTimer()
    {
        int minute = (int)GameManager.instance.time / 60;
        int seconds = (int)GameManager.instance.time % 60;
        timer.text = minute.ToString() + " : " + seconds.ToString();
    }



}
