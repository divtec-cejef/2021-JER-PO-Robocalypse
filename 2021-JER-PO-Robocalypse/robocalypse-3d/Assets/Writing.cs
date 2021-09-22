using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Writing : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerExitHandler, IPointerEnterHandler
{
    private InputField inputField;

    public void OnDeselect(BaseEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 0);
        Cursor.visible = true;
        GameObject.Find("UFO Cursor Input").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void OnSelect(BaseEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 0);
        Cursor.visible = false;
        GameObject.Find("UFO Cursor Input").GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 0);
        Cursor.visible = true;
        GameObject.Find("UFO Cursor Input").GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1.1f, 1.1f, 0);
        Cursor.visible = false;
        GameObject.Find("UFO Cursor Input").GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }

    void Start()
    {
        inputField = gameObject.GetComponent<InputField>();
        EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
    }
}
