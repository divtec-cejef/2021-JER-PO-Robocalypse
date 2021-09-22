using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class hoverExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
    public void OnDeselect(BaseEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 0);
        Cursor.visible = true;
        GameObject.Find("UFO Cursor Exit").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void OnSelect(BaseEventData eventData)
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 0);
        Cursor.visible = false;
        GameObject.Find("UFO Cursor Exit").GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 0);
        Cursor.visible = true;
        GameObject.Find("UFO Cursor Exit").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 0);
        Cursor.visible = false;
        GameObject.Find("UFO Cursor Exit").GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    void Start()
    {
        GameObject.Find("UFO Cursor Exit").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
