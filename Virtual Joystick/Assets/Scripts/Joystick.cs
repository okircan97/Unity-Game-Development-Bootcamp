using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// IDragHandler is an interface that is part of the Unity UI system
// and is used for handling drag events on UI elements. 

// In Unity, IPointerDownHandler is an interface that is part of the Unity UI system. 
// It is used for handling pointer (e.g., mouse click or touch) down events on UI elements. 
public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    private Image outerJS, innerJS;
    public Vector3 inputDir { set; get; }

    void Start()
    {
        // Get the joystick images.
        outerJS = GetComponent<Image>();
        innerJS = transform.GetChild(0).GetComponent<Image>();
    }

    // void Update()
    // {

    // }

    // This will be called on drag.
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(outerJS.rectTransform,
                                                                    eventData.position,
                                                                    eventData.pressEventCamera,
                                                                    out pos))
        {
            float x = (outerJS.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float z = (outerJS.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            inputDir = new Vector3(x, 0, z);
            // innerJs'in, outer'ın dışına çıkmamasını sağlıyor.
            inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;

            // Final pos.
            innerJS.rectTransform.anchoredPosition =
                new Vector3(inputDir.x * (outerJS.rectTransform.sizeDelta.y / 3),
                            inputDir.z * (outerJS.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        innerJS.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
