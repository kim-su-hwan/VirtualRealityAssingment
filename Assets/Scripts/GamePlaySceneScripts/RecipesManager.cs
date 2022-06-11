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
            tmp.text = "Iced Americano\nIce -> Espresso -> Water\n(E1:W6)\n\nHot Americano\nWater -> Espresso\n(E1:W6)";
        }
        if (m_code == 1)
        {
            // Caffe Latte
            tmp.text = "Iced Caffe Latte\nIce -> Milk -> Espresso\n(E(2shots)1:M4)\n\n" + "Hot Caffe Latte\nMilk -> Espresso\n(E1:M5)";
        }
        if (m_code == 2)
        {
            // Vanilla Latte
           tmp.text = "Iced Vanilla Latte\nVanilla Syrup -> Espresso -> Ice -> Milk\n(VS1:E3:M10)\n\n" + "Hot Vanilla Latte\nVanilla Syrup -> Espresso -> Milk\n(VS1:E3:M10).";
        }
        if (m_code == 3)
        {
            // Mocha Latte
            tmp.text = "Iced Mocha Latte\nMocha Syrup -> Espresso -> Ice -> Milk\n(MS1:E3:M10)\n\n" + "Hot Mocha Latte\nMocha Syrup -> Espresso -> Milk\n(MS1:E3:M10)";
        }
        if (m_code == 4)
        {
            // Strawberry Ade
            tmp.text = "Iced Strawberry Ade\nStrawberry Puree -> Ice -> Soda\n(SP1:S5)";
        }
        if (m_code == 5)
        {
            tmp.text = "Iced Green Tea Latte\nGreen Tea Powder -> Ice -> Milk\n(G1:M5)";
        }
        // 딸기 에이드 : 딸기청 -> 얼음 -> 사이다 (비율 => 딸기청 : 사이다 = 1 : 5)
        // 아이스 녹차라떼 : 녹차가루 -> 물 -> 얼음 -> 우유 (비율 => 녹차베이스(물+녹차가루(1팩)) : 우유 = 1 : 5)

    }
}
