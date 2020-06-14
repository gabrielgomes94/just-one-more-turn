using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;

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
                typeof(CommandCreateUnitComponent)
            );

            Entity entity = entityManager.CreateEntity(createUnitEventArch);

            entityManager.SetComponentData(
                entity,
                new CommandCreateUnitComponent {
                    Coordinates = e.Coordinates
                }
            );
        }
    }
}