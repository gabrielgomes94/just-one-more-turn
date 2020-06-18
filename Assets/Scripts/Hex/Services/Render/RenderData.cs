using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Hex
{
    public class RenderData
    {
        public Vector3 bridge;
        public Vector3 vertex1;
        public Vector3 vertex2;
        public Vector3 vertex3;
        public Vector3 vertex4;

        public Vector3 centerPosition;

        public NeighborCellService neighborService;

        public RenderData(
            HexDirection direction,
            Translation translation,
            NeighborCellService neighborService
        ) {
            this.centerPosition = new Vector3(
                translation.Value.x,
                translation.Value.y,
                translation.Value.z
            );

            this.bridge = HexMetrics.GetBridge(direction);
            this.vertex1 = centerPosition + HexMetrics.GetFirstSolidCorner(direction);
            this.vertex2 = centerPosition + HexMetrics.GetSecondSolidCorner(direction);
            this.vertex3 = vertex1 + bridge;
            this.vertex4 = vertex2 + bridge;

            this.neighborService = neighborService;

            vertex3.y = vertex4.y = neighborService.GetNeighborElevation(direction) * HexMetrics.elevationStep;
        }
    }
}