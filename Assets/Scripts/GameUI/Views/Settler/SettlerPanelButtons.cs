﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex.Coordinates;
using Game;
using GameUI.Models;

namespace GameUI.View
{
    public class SettlerPanelButtons : MonoBehaviour
    {
        public void CreateCity()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            Entity entity = Settler.GetSelected(entityManager);

            SettlerActions.AddCommandCreateCity(entity);
            UISettlerPanel.Hide();
        }

        public void BackButton()
        {
            UISettlerPanel.Hide();
        }
    }
}
