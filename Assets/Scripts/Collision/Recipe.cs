using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    // 0: water, 1: coffee, 2: ice, 3: milk, 4: strawberry, 5: sprite, 6: mocha

    public static readonly int[] americano_hot_recipe = new int[7] { 250, 1, 0, 0, 0, 0, 0 };
    public static readonly int[] americano_hot_seq = new int[3] {-1, Constant.water, Constant.coffee };

    public static readonly int[] americano_ice_recipe = new int[7] { 220, 1, 1, 0, 0, 0, 0 };
    public static readonly int[] americano_ice_seq = new int[4] {-1, Constant.ice, Constant.coffee, Constant.water };

    public static readonly int[] strawberryAid_recipe = new int[7] { 0, 0, 1, 0, 1, 220, 0 };
    public static readonly int[] strawberryAid_seq = new int[4] { -1, Constant.strawberry, Constant.ice, Constant.sprite };

    public static readonly int[] mochaLatte_ice_recipe = new int[7] { 0, 1, 1, 190, 0, 0, 20 };
    public static readonly int[] mochaLatte_ice_seq = new int[5] { -1, Constant.mocha, Constant.coffee, Constant.ice, Constant.milk };

    public static readonly int[] mochaLatte_hot_recipe = new int[7] { 0, 1, 0, 220, 0, 0, 20 };
    public static readonly int[] mochaLatte_hot_seq = new int[4] { -1, Constant.mocha, Constant.coffee, Constant.milk };

    public static readonly int[] cafeLatte_ice_recipe = new int[7] { 0, 2, 0, 220, 0, 0, 0 };
    public static readonly int[] cafeLatte_ice_seq = new int[4] { -1, Constant.ice, Constant.milk, Constant.coffee };

    public static readonly int[] cafeLatte_hot_recipe = new int[7] { 0, 1, 0, 220, 0, 0, 0 };
    public static readonly int[] cafeLatte_hot_seq = new int[3] { -1, Constant.milk, Constant.coffee };
}


// 레시피 요약

// 아이스 아메리카노 : 얼음 -> 에스프레소 -> 물 (비율 => 에스프레소 : 물 =  1:6)
// 핫 아메리카노 : 물 -> 에스프레소 (비율 => 에스프레소 : 물 = 1:6)
// 아이스 모카라떼 : 모카시럽 -> 에스프레소 -> 얼음 -> 우유 (비율 => 시럽 : 에스프레소 : 우유 = 1 : 3 : 10 )
// 핫 모카라떼 : 모카시럽 -> 에스프레소 -> 우유 (비율 => 시럽 : 에스프레소 : 우유 = 1 : 3 : 10)
// 아이스 카페라떼 : 얼음 -> 우유 -> 에스프레소 (비율 => 에스프레소(2shot) : 우유 = 1 : 4)
// 핫 카페라떼 : 우유 -> 에스프레소 (비율 => 에스프레소 : 우유 = 1 : 5)
// 아이스 바닐라라떼 :
// 핫 바닐라라떼 : 
// 딸기 에이드 : 딸기청 -> 얼음 -> 사이다 (비율 => 딸기청 : 사이다 = 1 : 5)



// ※주의 : 순서를 정확하게 지켜야 감점되지 않습니다.