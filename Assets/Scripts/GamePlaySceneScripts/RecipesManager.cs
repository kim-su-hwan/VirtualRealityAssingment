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
            tmp.text = "Iced Americano : Ice -> Espresso -> Water (E1:W6).\n" + "Hot Americano : Water -> Espresso (E1:W6)";
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
            tmp.text = "Iced Mocha Latte : Mocha Syrup -> Espresso -> Ice -> Milk ->(MS1:E3:M10).\n" + "Hot Mocha Latte : Mocha Syrup -> Espresso -> Milk (MS1:E3:M10)";
        }
        if (m_code == 4)
        {
            // Ade
            tmp.text = "Ade recipe is in here.";
        }
// 아이스 카페라떼 : 얼음 -> 우유 -> 에스프레소 (비율 => 에스프레소(2shot) : 우유 = 1 : 4)
// 핫 카페라떼 : 우유 -> 에스프레소 (비율 => 에스프레소 : 우유 = 1 : 5)
// 아이스 바닐라라떼 : 바닐라시럽 -> 에스프레소 -> 얼음 -> 우유 (비율 => 시럽 : 에스프레소 : 우유 = 1 : 3 : 10)
// 핫 바닐라라떼 : 바닐라시럽 -> 에스프레소 -> 우유 (비율 => 시럽 : 에스프레소 : 우유 = 1 : 3 : 10)
// 딸기 에이드 : 딸기청 -> 얼음 -> 사이다 (비율 => 딸기청 : 사이다 = 1 : 5)
// 아이스 녹차라떼 : 녹차가루 -> 물 -> 얼음 -> 우유 (비율 => 녹차베이스(물+녹차가루(1팩)) : 우유 = 1 : 5)

    }
}
