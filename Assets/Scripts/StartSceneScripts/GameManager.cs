using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    //시간관련
    public static bool onRecipes = false;
    public float time = 0.0f;
    public float re_time = 0.0f;
    //점수관련
    [HideInInspector] public int score = 0;
    [HideInInspector] public bool isColorBlind = false;
    GameObject pointCalc;


    private bool isGameStart = false;

    void Start()
    {
        pointCalc = GameObject.Find("Point");
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    void Update()
    {
        GameObject.Find("CVDFilter").GetComponent<CVDFilter>().SetBlind();
    }

    public void AddScore()
    {
        score = pointCalc.GetComponent<PointCalc>().GetScore();
    }

    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
    }


}
