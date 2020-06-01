using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[InternalBufferCapacity(8)]
public struct CivUnits : IBufferElementData
{
    public int Value;
}
