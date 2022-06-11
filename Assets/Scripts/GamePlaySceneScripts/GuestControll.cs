using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class GuestControll : MonoBehaviour
{
    public static GuestControll guestcon_instance;
    [SerializeField] private GameObject guest;
    [SerializeField] private GameObject guestinit;
    [SerializeField] private GameObject cupCanvas;

    [SerializeField] private GameObject point;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TextMeshProUGUI scoreAndTime;
    [HideInInspector] public bool isOrderClear = true;

    

    public int orderCount = 0;

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
        if(orderCount ==6)
        {
            Time.timeScale = 0;
            gameOverCanvas.SetActive(true);
            scoreAndTime.text = $"Score : {point.GetComponent<PointCalc>().GetScore()} " + timer.text;
        }
        if(isOrderClear == true)
        {
            cupCanvas.SetActive(true);
            Instantiate(guest,guestinit.transform);
            isOrderClear = false;
            orderCount++;
        }
    }
}
