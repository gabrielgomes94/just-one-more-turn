using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInput
{
    public class PrimaryActionHandler
    {
        public void handle(Vector3 position)
        {
            Ray inputRay = Camera.main.ScreenPointToRay(position);
            Debug.Log(inputRay);
            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit)) {
                Debug.Log("tocou");
                IInteractable interfaceInteractable = hit.transform.gameObject.GetComponent<IInteractable>();
                interfaceInteractable.Select();
            }
        }
    }
}

