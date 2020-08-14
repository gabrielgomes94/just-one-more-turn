using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

namespace Game
{

    namespace UI
    {
        public class UIManager : MonoBehaviour
        {
            public static bool showSettlerPanel = false;

            public GameObject settlerPanelGameObject;

            void Start()
            {
                showSettlerPanel = false;
            }

            void Update()
            {
                settlerPanelGameObject.SetActive(showSettlerPanel);
            }
        }
    }
}