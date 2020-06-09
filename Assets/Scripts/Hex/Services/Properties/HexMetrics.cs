using UnityEngine;

namespace Hex
{
    public class HexMetrics
    {
        public const float outerRadius = 10f;
        public const float innerRadius = outerRadius * 0.866025404f;

        public const float solidFactor = 0.75f;

        public const float blendFactor = 1f - solidFactor;

        public const float elevationStep = 5f;

        public static readonly Vector3[] corners = {
            new Vector3(0f, 0f, outerRadius),                       // vertex 1
            new Vector3(innerRadius, 0f, 0.5f * outerRadius),       // vertex 2
            new Vector3(innerRadius, 0f, -0.5f * outerRadius),      // vertex 3
            new Vector3(0f, 0f, -outerRadius),                      // vertex 4
            new Vector3(-innerRadius, 0f, -0.5f * outerRadius),     // vertex 5
            new Vector3(-innerRadius, 0f, 0.5f * outerRadius),      // vertex 6
            new Vector3(0f, 0f, outerRadius)                        // vertex 1 - again, to close the hex
        };

        public static Vector3 GetFirstCorner (HexDirection direction) {
            return corners[(int)direction];
        }

        public static Vector3 GetSecondCorner (HexDirection direction) {
            return corners[(int)direction + 1];
        }

        public static Vector3 GetFirstSolidCorner (HexDirection direction) {
            return corners[(int)direction] * solidFactor;
        }

        public static Vector3 GetSecondSolidCorner (HexDirection direction) {
            return corners[(int)direction + 1] * solidFactor;
        }

        public static Vector3 GetBridge (HexDirection direction) {
            return (corners[(int)direction] + corners[(int)direction + 1]) * blendFactor;
        }
    }
}

