using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

namespace GameInput
{
    [AlwaysUpdateSystem]
    class PlayerInputSystem : SystemBase//, IPlayerControllerActions
    {
        EntityQuery mouseInputQuery;
        protected override void OnCreate()
        {
            mouseInputQuery = GetEntityQuery(typeof(MouseInput));
        }

        protected override void OnUpdate()
        {
            if (mouseInputQuery.CalculateEntityCount() == 0)
                EntityManager.CreateEntity(typeof(MouseInput));

            if (Input.GetMouseButtonDown(0)) {
                var position = new float3(Input.mousePosition.x, Input.mousePosition.y, 0f);

                mouseInputQuery.SetSingleton(new MouseInput {
                    primaryAction = 1,
                    secondaryAction = 0,
                    mousePosition = position
                });
            }
        }
    }
}