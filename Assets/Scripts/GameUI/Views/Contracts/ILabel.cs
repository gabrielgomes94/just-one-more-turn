using UnityEngine;
using UnityEngine.UI;
using Unity.Entities;

namespace GameUI.View
{
    public interface ILabel
    {
        void SetContent(GameObject label);
        void SetPosition(Entity cityLabel, Canvas gridCanvas);
    }
}