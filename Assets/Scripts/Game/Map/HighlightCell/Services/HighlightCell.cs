using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex;

namespace Game
{
    public class HighlightCell
    {
        public static void Create(EntityCommandBuffer ecb, HighlightCellPrefab highlightPrefab, HexCoordinates coordinates)
        {
            Entity highlight = ecb.Instantiate(highlightPrefab.Value);
            float3 position = HexCellService.GetTranslationComponentByHexCoordinates(coordinates);

            ecb.SetComponent<Translation>(highlight, new Translation { Value = position });
            ecb.AddComponent<HexCoordinates>(highlight, coordinates);
            ecb.AddComponent<HighlightTag>(highlight, new HighlightTag{ });
        }
    }
}
