using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex.Coordinates;
using GameUI.Models;

namespace GameUI.View
{
    public class SettlerPanelManager : MonoBehaviour
    {
        public GameObject settlerPanelPrefab;
        EntityManager entityManager;
        EntityQuery query;
        Entity panel;

        void Awake()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        void Start()
        {
            settlerPanelPrefab.SetActive(false);
        }

        void LateUpdate()
        {
            query = entityManager.CreateEntityQuery(
                ComponentType.ReadOnly<SettlerPanelTag>(),
                ComponentType.ReadOnly<HexCoordinates>()
            );

            panel = Entity.Null;

            if (query.CalculateEntityCount() > 0) {
                settlerPanelPrefab.SetActive(true);
                return;
            }

            settlerPanelPrefab.SetActive(false);
        }
    }
}
