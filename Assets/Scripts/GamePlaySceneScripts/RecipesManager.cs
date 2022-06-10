using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipesManager : MonoBehaviour
{
    public RawImage recipesBackground;

    public GameObject recipesButtons;

    public GameObject americano;
    public GameObject caffeLatte;
    public GameObject vanillaLatte;
    public GameObject mochaLatte;
    public GameObject strawberryAde;
    public GameObject greenTeaLatte;

    public GameObject recipePaper;
    // Start is called before the first frame update

    public void OpenRecipesUI()
    {
        if (GameManager.onRecipes == false)
        {
            GameManager.onRecipes = true;
            recipesBackground.enabled = true;
            recipesButtons.SetActive(true);
        }
        else
        {
            GameManager.onRecipes = false;
            recipesBackground.enabled = false;
            recipesButtons.SetActive(false);
            recipePaper.SetActive(false);
        }
    }

    public void OpenRecipePaper(int m_code)
    {
        recipesButtons.SetActive(false);
        recipePaper.SetActive(true);
        
        TextMeshProUGUI tmp = recipePaper.GetComponentInChildren<TextMeshProUGUI>();
        if(m_code == 0)
        {
            // Americano
            tmp.text = "Americano recipe is in here.";
        }
        if (m_code == 1)
        {
            // Caffe Latte
            tmp.text = "Caffe Latte recipe is in here.";
        }
        if (m_code == 2)
        {
            // Vanilla Latte
            tmp.text = "Vanilla Latte recipe is in here.";
        }
        if (m_code == 3)
        {
            // Mocha Latte
            tmp.text = "Mocha Latte recipe is in here.";
        }
        if (m_code == 4)
        {
            // Ade
            tmp.text = "Ade recipe is in here.";
        }
    }
}
