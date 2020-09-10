using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Hex.Coordinates;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
            SettlerService.Create(new HexCoordinates{ Value = new int3(8, -17 ,9) });
            SettlerService.Create(new HexCoordinates{ Value = new int3(10, -15,5) });
            SettlerService.Create(new HexCoordinates{ Value = new int3(2, -6 ,4) });
            SettlerService.Create(new HexCoordinates{ Value = new int3(0, -9 ,9) });
            SettlerService.Create(new HexCoordinates{ Value = new int3(8, -8 ,0) });
            SettlerService.Create(new HexCoordinates{ Value = new int3(1, -11, 10) });
        }
    }
}