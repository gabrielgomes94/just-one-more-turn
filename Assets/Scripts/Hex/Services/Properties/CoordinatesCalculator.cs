using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatesCalculator
{
    public static int GetXFromOffset(int x, int z)
    {
        return x - z / 2;
    }
}
