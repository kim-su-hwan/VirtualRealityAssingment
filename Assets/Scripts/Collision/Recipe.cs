using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    // 0: water, 1: coffee, 2: ice, 3: milk, 4: strawberry, 5: sprite

    public static readonly int[] americano_hot_recipe = new int[6] { 280, 1, 0, 0, 0, 0 };
    public static readonly int[] americano_hot_seq = new int[3] {-1, Constant.water, Constant.coffee };

    public static readonly int[] americano_ice_recipe = new int[6] { 280, 1, 1, 0, 0, 0 };
    public static readonly int[] americano_ice_seq = new int[4] {-1, Constant.ice, Constant.coffee, Constant.water };

    public static readonly int[] strawberryAid_recipe = new int[6] { 0, 0, 1, 0, 1, 280 };
    public static readonly int[] strawberryAid_seq = new int[4] { -1, Constant.strawberry, Constant.ice, Constant.sprite };
}


// 레시피 요약

// 아이스 아메리카노 : 얼음 -> 에스프레소 -> 물 
// 핫 아메리카노 : 물 -> 에스프레소
// 딸기 에이드 : 딸기청 -> 얼음 -> 사이다

// ※주의 : 순서를 정확하게 지켜야 감점되지 않습니다.