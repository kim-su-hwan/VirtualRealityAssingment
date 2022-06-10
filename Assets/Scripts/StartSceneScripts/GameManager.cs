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


    private bool isGameStart = false;

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



    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
    }


}
