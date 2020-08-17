﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex.Coordinates;
using GameUI.Events;
using Game;

namespace GameUI.Managers
{
    public class SettlerPanelManager : MonoBehaviour
    {
        public GameObject settlerPanelPrefab;
        EntityManager entityManager;
        EntityQuery query;

        void Awake()
        {
            entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            query = entityManager.CreateEntityQuery(
                ComponentType.ReadOnly<SettlerPanelTag>(),
                ComponentType.ReadOnly<HexCoordinates>()
            );
        }

        void Start()
        {

        }

        void Update()
        {

        }

        void LateUpdate()
        {
            NativeArray<Entity> panels = query.ToEntityArray(Allocator.TempJob);

            foreach(var panel in panels)
            {
                settlerPanelPrefab.SetActive(true);
            }

            panels.Dispose();
        }

        public void CreateCity()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            Entity entity = SettlerEntity.GetSelected(entityManager);

            SettlerEntity.AddCommandCreateCity(entityManager, entity);

            Debug.Log("Criação de cidade");
        }
    }
}
