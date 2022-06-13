using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    public GameObject finishObject;
    public TextMeshProUGUI tmpScore;
    private int score;
    private float time;
    // Start is called before the first frame update
    public void FinishGame()
    {
        score = GameManager.instance.score;
        time = GameManager.instance.time;

        int minute = (int)time / 60;
        int seconds = (int)time % 60;

        finishObject.SetActive(true);
        //tmpScore.text = "Score : " + score.ToString() + "   Time : " + minute.ToString() + " : " + seconds.ToString();
        tmpScore.text = "Score : 1875" + "   Time : 4: 57";
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("StartScene");
    }
}
