using UnityEngine;

namespace Hex
{
    public class HexColor
    {
        static Color[] colors = {
            Color.white,
            Color.green,
            Color.yellow,
            Color.gray,
        };

        public static Color GetRandomColor()
        {
            return colors[Random.Range(0, colors.Length)];
        }
    }
}
