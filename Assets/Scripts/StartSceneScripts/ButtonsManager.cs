using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonsManager : MonoBehaviour
{
    public GameObject mainScreen;
    public GameObject startButton;
    public GameObject settingsScreen;

    public GameObject colorBlindButton;
    public GameObject backButton;

    public void SelectStartButton()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void SelectSettingsButton()
    {
        mainScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }

    public void ChangeColorBlindMode()
    {
        Image img = colorBlindButton.GetComponent<Image>();
        TextMeshProUGUI text = colorBlindButton.GetComponentInChildren<TextMeshProUGUI>();

        if (Settings.isColorBlind == false)
        {
            img.color = new Color32(0, 0, 0, 192);

            text.color = new Color32(255, 255, 255, 255);

            Settings.isColorBlind = true;
        }
        else
        {
            img.color = new Color32(255, 255, 255, 192);

            text.color = new Color32(0, 0, 0, 255);

            Settings.isColorBlind = false;
        }
    }

    public void SelectBackButton()
    {
        mainScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
}
