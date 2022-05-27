﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;
    //시간관련
    public float time = 600.0f;
    public float re_time = 600.0f;
    //점수관련
    [HideInInspector] public int score = 0;

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
    void Start()
    {

    }

    void Update()
    {
        TimeCountUp();
    }


    void TimeCountUp()
    {
        time -= Time.deltaTime;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
