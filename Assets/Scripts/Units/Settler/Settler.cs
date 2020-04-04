using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settler : MonoBehaviour, IInteractable
{
    public SettlerData settlerData;

    public Settler()
    {
        settlerData = new SettlerData();
    }

    public void Selection()
    {
        Debug.Log("Settler ==========|| interface");
    }
}
