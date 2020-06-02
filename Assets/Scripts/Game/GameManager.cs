using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public event EventHandler<CreateUnitEventArgs> OnCivilizationCreated;

        void Start()
        {
            // Create Civilization
            Civilization civ = new Civilization();
            civ.Create();

            // Create Civilization's settler
            CreateUnitEventArgs args = new CreateUnitEventArgs();
            args.position = new float3(10, 20, 30);


            OnCivilizationCreated?.Invoke(this, args);
        }
    }
}