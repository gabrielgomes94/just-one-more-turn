using System;
using UnityEngine;
using Unity.Entities;
using Hex;

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
                    X = e.Coordinates.x,
                    Y = e.Coordinates.y,
                    Z = e.Coordinates.z
                }
            );
        }
    }
}
