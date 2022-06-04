﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : MonoBehaviour
{
    public static readonly Color color_water = new Color(118 / 255f, 255 / 255f, 255 / 255f, 70 / 255f);
    public static readonly Color color_coffee = new Color(77 / 255f, 54 / 255f, 56 / 255f, 255 / 255f);
    public static readonly Color color_milk = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);

    public const int water = 0;
    public const int coffee = 1;
    public const int ice = 2;
    public const int milk = 3;
}