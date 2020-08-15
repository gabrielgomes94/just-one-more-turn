using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;
using Hex;

namespace Game
{
    public class SelectUnitSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .WithoutBurst()
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    in Selected selected
                ) => {
                    if (EntityManager.HasComponent<SettlerTag>(entity))
                    {
                        // UI.UIManager.showSettlerPanel = true;
                    }
                })
                .Run();
        }
    }
}
