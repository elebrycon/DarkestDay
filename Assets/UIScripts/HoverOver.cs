using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject DoorLeft;
    public GameObject DoorRight;
    public GameObject Text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("gbm");
        DoorLeft.GetComponent<Animator>().SetBool("isHover",true);
        DoorRight.GetComponent<Animator>().SetBool("isHover", true);
        Text.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DoorLeft.GetComponent<Animator>().SetBool("isHover", false);
        DoorRight.GetComponent<Animator>().SetBool("isHover", false);
        Text.SetActive(false);
    }
}
