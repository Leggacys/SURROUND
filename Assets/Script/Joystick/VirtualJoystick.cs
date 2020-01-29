using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class VirtualJoystick : MonoBehaviour , IDragHandler ,IPointerUpHandler,IPointerDownHandler
{
    private Image bnimg;
    private Image Joystickimg;
    public Vector3 Directions { set; get; }

    private void Start()
    {
        bnimg = GetComponent<Image>();
        Joystickimg = transform.GetChild(0).GetComponentInChildren<Image>();
        Directions = Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2  pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bnimg.rectTransform
            ,ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x /bnimg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bnimg.rectTransform.sizeDelta.y);
            float x = (bnimg.rectTransform.pivot.x == 1) ? pos.x * 2: pos.x * 2;
            float y = (bnimg.rectTransform.pivot.y == 1) ? pos.y * 2: pos.y * 2;
            Directions = new Vector3(x, 0, y);
            Directions = (Directions.magnitude > 1) ? Directions.normalized : Directions;
            Joystickimg.rectTransform.anchoredPosition = new Vector3(Directions.x*(bnimg.rectTransform.sizeDelta.x/3),
                Directions.z* (bnimg.rectTransform.sizeDelta.y / 3));
        }
     }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        Directions = Vector3.zero;
        Joystickimg.rectTransform.anchoredPosition = Vector3.zero;
    }


    


}
