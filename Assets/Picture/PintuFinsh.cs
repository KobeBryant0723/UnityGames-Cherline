using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PintuFinsh : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public static RectTransform rectHideTU;

    public static bool finish;

    private Color color;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Pintu.Pintuname == this.transform.name)
        {
            rectHideTU = this.GetComponent<RectTransform>();

            this.transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);

            finish = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!Pintu.realFinish)
        this.transform.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);

        finish = false;

        rectHideTU = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        color = this.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
