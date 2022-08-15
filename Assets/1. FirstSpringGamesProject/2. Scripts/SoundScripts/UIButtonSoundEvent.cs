using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        AudioManager.Instance.PlayOnHover();
    }

    public void OnPointerDown(PointerEventData ped)
    {
        AudioManager.Instance.PlayOnClick();

    }
}