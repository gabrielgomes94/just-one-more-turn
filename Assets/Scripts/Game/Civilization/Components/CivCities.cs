﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[InternalBufferCapacity(8)]
public struct CivCities : IBufferElementData
{
    public int Value;
}
