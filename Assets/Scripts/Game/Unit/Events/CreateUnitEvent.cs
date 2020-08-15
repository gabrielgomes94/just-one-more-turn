using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Hex.Coordinates;

namespace Game
{
    public class CreateUnitEvent : MonoBehaviour {
        private void Start() {
            GameManager gameManager = GetComponent<GameManager>();
            gameManager.OnCivilizationCreated += OnCreateUnitOnCivilizationCreated;
        }

        protected virtual void OnCreateUnitOnCivilizationCreated(object sender, CreateUnitEventArgs e) {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            EntityArchetype createUnitEventArch = entityManager.CreateArchetype(
                typeof(CommandCreateUnitComponent),
                typeof(HexCoordinates)
            );

            Entity entity = entityManager.CreateEntity(createUnitEventArch);

            entityManager.SetComponentData(
                entity,
                new HexCoordinates{
                    Value = new int3(e.Coordinates)
                }
            );
        }
    }
}
