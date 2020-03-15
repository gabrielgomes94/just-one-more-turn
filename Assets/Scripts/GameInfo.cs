using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public Settler settler;

    void Start()
    {
        Instantiate(settler);
    }
}
