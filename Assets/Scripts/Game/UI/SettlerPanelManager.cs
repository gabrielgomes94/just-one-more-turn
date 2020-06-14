﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex;

namespace Game
{
    public class SettlerPanelManager : MonoBehaviour
    {
        public event EventHandler<CreateCityEventArgs> OnCreateCity;

        public void CreateCityOnClick()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            var query = entityManager.CreateEntityQuery(
                ComponentType.ReadOnly<SettlerTag>(),
                ComponentType.ReadOnly<CivIdSharedComponent>(),
                ComponentType.ReadOnly<Translation>(),
                ComponentType.ReadOnly<HexCoordinates>(),
                ComponentType.ReadOnly<Selected>()
            );

            // Create Civilization's city
            CreateCityEventArgs args = new CreateCityEventArgs();

            NativeArray<HexCoordinates> coordinates = query.ToComponentDataArray<HexCoordinates>(Allocator.Temp);
            // var settler = query.ToEntityArray();

            Debug.Log("Coordenadas: " + coordinates[0]);

            // get selected coordinates and civ ID
            args.Coordinates = new int3(
                coordinates[0].X,
                coordinates[0].Y,
                coordinates[0].Z
            );

            args.CivId = 1;

            OnCreateCity?.Invoke(this, args);

            coordinates.Dispose();
        }

        public void BackOnClick()
        {
            UI.UIManager.showSettlerPanel = false;
        }
    }
}