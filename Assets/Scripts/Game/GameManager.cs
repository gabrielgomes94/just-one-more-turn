using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Hex.Coordinates;
using Game.Turn;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {
            CreateSettlerService.Execute(new HexCoordinates{ Value = new int3(8, -17 ,9) });
            CreateSettlerService.Execute(new HexCoordinates{ Value = new int3(10, -15,5) });
            CreateSettlerService.Execute(new HexCoordinates{ Value = new int3(2, -6 ,4) });
            CreateSettlerService.Execute(new HexCoordinates{ Value = new int3(0, -9 ,9) });
            CreateSettlerService.Execute(new HexCoordinates{ Value = new int3(8, -8 ,0) });
            CreateSettlerService.Execute(new HexCoordinates{ Value = new int3(1, -11, 10) });

            TurnService.Init();
        }
    }
}