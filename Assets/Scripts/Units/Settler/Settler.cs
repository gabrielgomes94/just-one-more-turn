using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

namespace GameUnit
{
    public class Settler : MonoBehaviour, IInteractable
    {
        public SettlerData settlerData;

        public bool isSelected { get; set; }

        public GameObject gameObject;
        public Settler()
        {
            settlerData = new SettlerData();
        }

        public void Awake()
        {
            this.isSelected = false;
            ShowActionsPanel();
        }

        public void Select()
        {
            this.isSelected = (this.isSelected == true) ? false : true;

            ShowActionsPanel();
        }

        private void ShowActionsPanel()
        {
            gameObject.GetComponentInChildren<Canvas>().enabled = this.isSelected;
        }
    }
}
