using UnityEngine;

public class HexMetrics : MonoBehaviour
{
    public const float outerRadius = 10f;

    public const float innerRadius = outerRadius * 0.866025404f;

	public static Vector3[] corners = {
		new Vector3(0f, 0f, outerRadius),						// vertex 1
		new Vector3(innerRadius, 0f, 0.5f * outerRadius),		// vertex 2
		new Vector3(innerRadius, 0f, -0.5f * outerRadius),		// vertex 3
		new Vector3(0f, 0f, -outerRadius),						// vertex 4
		new Vector3(-innerRadius, 0f, -0.5f * outerRadius),		// vertex 5
		new Vector3(-innerRadius, 0f, 0.5f * outerRadius)		// vertex 6
	};
}
