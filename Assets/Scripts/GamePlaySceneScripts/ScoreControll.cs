using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreControll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private GameObject point;
    public void ShowScore()
    {
        score_text.text = $"Score : {point.GetComponent<PointCalc>().GetScore()}";
        //사용시
        //GameObject.Find("Managers").GetComponent<ScoreControll>().ShowScore();
    }


}
