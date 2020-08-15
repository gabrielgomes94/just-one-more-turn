using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex;
using Hex.Cell;

namespace Game
{
    public class MoveUnitSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities
                .ForEach((
                    Entity entity,
                    int entityInQueryIndex,
                    ref Translation translation,
                    in Movable movable,
                    in CommandMoveComponent cmdMove
                ) => {
                    translation.Value =  HexCellService.GetTranslationComponentByHexCoordinates(
                        new HexCoordinates{ Value = new int3(cmdMove.moveToCoordinates) }
                    );

                    // EntityManager.RemoveComponent<CommandMoveComponent>(entity);
                })
                .Schedule();
        }
    }
}