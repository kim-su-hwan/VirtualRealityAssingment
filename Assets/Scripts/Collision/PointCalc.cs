using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PointCalc : MonoBehaviour
{
    private static int totalScore;
    private int defaultScore;
    private int[] recipe;
    private int[] sequence;

    [SerializeField] private TextMeshProUGUI scoreUI;

    // 주문 리스트
    private List<int> order;
    private int beverage;

    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        order = new List<int>();

        // 테스트용
        order.Add(1001);
        order.Add(1002);
    }
    
    public int ScoreCalculation(int[] cup, List<int> seq)
    {
        if(order.Count == 0)
        {
            Debug.Log("Empty Order List");
            return 0;
        }
        beverage = order[0];

        // 음료 하나당 최대 획득 가능 점수는 1000점
        defaultScore = 1000;
        if (beverage == Constant.americano_ice)
        {
            recipe = Recipe.americano_ice_recipe;
            sequence = Recipe.americano_ice_seq;
        }
        else if (beverage == Constant.americano_hot)
        {
            recipe = Recipe.americano_hot_recipe;
            sequence = Recipe.americano_hot_seq;
        }
        else if (beverage == Constant.strawberryAid)
        {
            recipe = Recipe.strawberryAid_recipe;
            sequence = Recipe.strawberryAid_seq;
        }

        // 불필요한 재료가 들어간 경우 or 재료를 빼먹은 경우 원래 점수에서 -500점
        for (int i = 0; i < recipe.Length; i++)
        {
            if (recipe[i]==0 && cup[i] != 0)
            {
                totalScore -= 500;
                order.RemoveAt(0);
                scoreUI.text = "Score : " + totalScore.ToString();
                return -500;
            }
            if (recipe[i]!=0 && cup[i] == 0)
            {
                totalScore -= 500;
                order.RemoveAt(0);
                scoreUI.text = "Score : " + totalScore.ToString();
                return -500;
            }
        }
        // 물이 들어가는 음료의 경우, 적정량에서 벗어난 만큼 획득점수 감소
        if (recipe[Constant.water] != 0)
        {
            defaultScore -= (Math.Abs(recipe[Constant.water] - cup[Constant.water])*2);
        }
        // 우유가 들어가는 음료의 경우, 적정량에서 벗어난 만큼 획득점수 감소
        if (recipe[Constant.milk] != 0)
        {
            defaultScore -= (Math.Abs(recipe[Constant.milk] - cup[Constant.milk])*2);
        }
        // 샷이 들어가는 음료의 경우, 틀린 갯수 하나당 200점 획득점수 감소
        if (recipe[Constant.coffee] != 0)
        {
            defaultScore -= (Math.Abs(recipe[Constant.coffee] - cup[Constant.coffee]) * 200);
        }
        // 얼음이 들어가는 음료의 경우, 틀린 갯수 하나당 200점 획득점수 감소
        if (recipe[Constant.ice] != 0)
        {
            defaultScore -= (Math.Abs(recipe[Constant.ice] - cup[Constant.ice]) * 200);
        }
        // 딸기청이 들어가는 음료의 경우, 틀린 갯수 하나당 200점 획득점수 감소
        if (recipe[Constant.strawberry] != 0)
        {
            defaultScore -= (Math.Abs(recipe[Constant.strawberry] - cup[Constant.strawberry]) * 200);
        }
        // 사이다가 들어가는 음료의 경우, 적정량에서 벗어난 만큼 획득점수 감소
        if (recipe[Constant.sprite] != 0)
        {
            defaultScore -= (Math.Abs(recipe[Constant.sprite] - cup[Constant.sprite])*2);
        }

        // 재조 순서가 틀린 경우, 300점 획득점수 감소
        if (seq.Count != sequence.Length)
        {
            defaultScore -= 300;
        }
        else
        {
            for(int i = 0; i < sequence.Length; i++)
            {
                if (seq[i] != sequence[i])
                {
                    defaultScore -= 300;
                    break;
                }
            }
        }
        totalScore += defaultScore;
        order.RemoveAt(0);
        scoreUI.text = "Score : " + totalScore.ToString();
        return defaultScore;
    }

    // 주문 추가
    public void AddOrder(int n)
    {
        order.Add(n);
    }

    // total 점수 얻어오기
    public int GetScore()
    {
        return totalScore;
    }

}
