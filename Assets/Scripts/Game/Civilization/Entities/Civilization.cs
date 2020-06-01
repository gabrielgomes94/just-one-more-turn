using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Game
{
    public class Civilization
    {
        public void Create()
        {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;


            EntityArchetype archetype = entityManager.CreateArchetype(
                typeof(Name),
                typeof(CivColors),
                typeof(CivCities),
                typeof(CivUnits)
            );

            Entity entity = entityManager.CreateEntity(archetype);

            Debug.Log(entity);
        }
    }
}
