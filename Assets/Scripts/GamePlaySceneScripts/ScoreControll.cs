using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreControll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score_text;

    public void ShowScore()
    {
        score_text.text = $"Score : {GameManager.instance.score}";
        //사용시
        //GameObject.Find("Managers").GetComponent<ScoreControll>().ShowScore();
    }


}
