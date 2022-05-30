using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerScipt : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    public float time = 0.0f;
    public float re_time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeCountUp();
        UpdateTimer();
    }
    void TimeCountUp()
    {
        time += Time.deltaTime;
    }
    public void UpdateTimer()
    {
        int minute = (int)time / 60;
        int seconds = (int)time % 60;
        timer.text = minute.ToString() + " : " + seconds.ToString();
    }

}
