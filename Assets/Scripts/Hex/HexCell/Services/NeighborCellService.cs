using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Hex.Cell
{
    public class NeighborCellService
    {
        int[,] hexCoordinatesModifier = new int [,] {
            {0, -1, 1},
            {1, -1, 0},
            {1, 0, -1},
            {0, 1, -1},
            {-1, 1, 0},
            {-1, 0, 1}
        };
        Entity mainHexCell;
        private EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        public NeighborCellService(Entity mainHexCell) {
            this.mainHexCell = mainHexCell;
        }

        public Entity GetNeighborCell(HexDirection direction) {
            HexCoordinates targetHexCoordinates = GetTargetHexCoordinates(direction);

            return HexCellService.FindBy(targetHexCoordinates);
        }

        public Color GetColor(HexDirection direction) {
            Entity neighborCell = GetNeighborCell(direction);
            Color color  = entityManager.GetComponentData<ColorComponent>(mainHexCell).Value;

            if (Entity.Null != neighborCell) {
                color = entityManager.GetComponentData<ColorComponent>(neighborCell).Value;
            }

            return color;
        }

        public int GetElevation(HexDirection direction) {
            Entity neighborCell = GetNeighborCell(direction);
            int elevation = 0;

            if (Entity.Null != neighborCell) {
                elevation = entityManager.GetComponentData<Elevation>(neighborCell).Value;
            }

            return elevation;
        }

        public bool Exists(HexDirection direction)
        {
            Entity neighbor = GetNeighborCell(direction);

            return Entity.Null != neighbor ? true : false;
        }

        private HexCoordinates GetTargetHexCoordinates(HexDirection direction)
        {
            HexCoordinates hexCellCoordinates = entityManager.GetComponentData<HexCoordinates>(mainHexCell);

            return new HexCoordinates{
                Value = new int3(
                    hexCellCoordinates.Value.x + this.hexCoordinatesModifier[(int) direction, 0],
                    hexCellCoordinates.Value.y + this.hexCoordinatesModifier[(int) direction, 1],
                    hexCellCoordinates.Value.z + this.hexCoordinatesModifier[(int) direction, 2]
                )
            };
        }
    }
}
