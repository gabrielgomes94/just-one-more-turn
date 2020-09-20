﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUI.Models;
using Game;

namespace GameUI.View
{
    public class CityLabelButton : MonoBehaviour
    {

        public CityData cityData;

        void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SelectCity()
        {
            Debug.Log("clicou aqui!! pq pq pq ");
            Debug.Log("clicou aqui, na posiçao: " + cityData.hexCoordinates.Value);

            SelectCommand.Create(cityData.hexCoordinates);
        }
    }
}
