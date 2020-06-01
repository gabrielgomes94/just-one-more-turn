using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        void Start()
        {

            // Create Civilization
            Civilization civ = new Civilization();
            civ.Create();
        }

        void Update()
        {

        }
    }
}