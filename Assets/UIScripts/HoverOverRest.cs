using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOverRest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Text;

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        Text.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Text.SetActive(false);
    }
}
