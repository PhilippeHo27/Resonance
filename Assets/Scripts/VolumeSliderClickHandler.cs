using UnityEngine;
using UnityEngine.EventSystems;

public class VolumeSliderClickHandler : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        eventData.Use();
    }
}
