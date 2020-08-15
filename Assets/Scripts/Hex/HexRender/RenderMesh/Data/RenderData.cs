using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Hex.Cell;

namespace Hex.Mesh
{
    public class RenderData: IRenderData
    {
        private Vector3 bridge;
        public Vector3 Bridge
        {
            get { return bridge; }
        }

        private Vector3 vertex1;
        public Vector3 Vertex1
        {
            get { return vertex1; }
        }

        private Vector3 vertex2;
        public Vector3 Vertex2
        {
            get { return vertex2; }
        }

        public Vector3 vertex3;
        public Vector3 Vertex3
        {
            get { return vertex3; }
        }

        private Vector3 vertex4;
        public Vector3 Vertex4
        {
            get { return vertex4; }
        }

        private Vector3 centerPosition;
        public Vector3 CenterPosition
        {
            get { return centerPosition; }
        }

        private NeighborCellService neighborService;
        public NeighborCellService NeighborService
        {
            get { return neighborService; }
        }

        private Entity entity;
        public Entity Entity
        {
            get { return entity; }
        }

        public RenderData(
            HexDirection direction,
            Entity entity,
            int neighborElevation
        ) {
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var translation = entityManager.GetComponentData<Translation>(entity);

            this.entity = entity;

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

            vertex3.y = vertex4.y = neighborElevation * HexMetrics.elevationStep;
        }
    }
}
