using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Hex.Coordinates;
using Game;
using GameUI.Entities;

namespace GameUI.Input
{
    public class SettlerPanelButtons : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CreateCity()
        {
            Debug.Log("Criação de cidade");
            EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            Entity entity = SettlerRepository.GetSelected(entityManager);

            SettlerService.AddCommandCreateCity(entityManager, entity);

            UISettlerPanel.Hide();
        }

        public void BackButton()
        {
            Debug.Log("Destrua o painel");

            UISettlerPanel.Hide();
        }
    }
}
