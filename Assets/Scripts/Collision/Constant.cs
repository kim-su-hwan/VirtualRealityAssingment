using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    public static readonly Color color_water = new Color(118 / 255f, 255 / 255f, 255 / 255f, 70 / 255f);
    public static readonly Color color_coffee = new Color(77 / 255f, 54 / 255f, 56 / 255f, 255 / 255f);
    public static readonly Color color_milk = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
    public static readonly Color color_strawberry = new Color(255 / 255f, 42 / 255f, 42 / 255f, 255 / 255f);
    public static readonly Color color_latte = new Color(150 / 255f, 90 / 255f, 53 / 255f, 255 / 255f);
    public static readonly Color color_vanilla = new Color(209 / 255f, 209 / 255f, 155 / 255f, 255 / 255f);
    public static readonly Color color_greenTea = new Color(0, 0, 0, 0);

    public const int water = 0;
    public const int coffee = 1;
    public const int ice = 2;
    public const int milk = 3;
    public const int strawberry = 4;
    public const int sprite = 5;
    public const int mocha = 6;
    public const int vanilla = 7;
    public const int greenTea = 8;

    public const int americano_ice = 1001;
    public const int americano_hot = 1002;
    public const int strawberryAid = 1003;
    public const int mochaLatte_ice = 1004;
    public const int mochaLatte_hot = 1005;
    public const int cafeLatte_ice = 1006;
    public const int cafeLatte_hot = 1007;
    public const int vanillaLatte_ice = 1008;
    public const int vanillaLatte_hot = 1009;
    public const int greenTeaLatte_ice = 1010;
}
