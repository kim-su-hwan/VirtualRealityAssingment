using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public static readonly int[] americano_hot_recipe = new int[4] { 280, 1, 0, 0 };
    public static readonly int[] americano_hot_seq = new int[3] {-1, Constant.water, Constant.coffee };

    public static readonly int[] americano_ice_recipe = new int[4] { 280, 1, 1, 0 };
    public static readonly int[] americano_ice_seq = new int[4] {-1, Constant.ice, Constant.coffee, Constant.water };
}
