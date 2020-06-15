using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct CommandCreateCityComponent : IComponentData
{
    public int3 Coordinates;

    public int CivId;
}
