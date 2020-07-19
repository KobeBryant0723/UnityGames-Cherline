using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pintu : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    private RectTransform rect;

    public static string Pintuname = "-1";

    public static bool realFinish;

    private int index;

    public void OnBeginDrag(PointerEventData eventData)
    {
        realFinish = false;

        index = this.transform.GetSiblingIndex();
        // throw new System.NotImplementedException();
        for (int i = 0; i < rect.transform.parent.childCount; i++)
        {
            rect.transform.parent.GetChild(i).GetComponent<Image>().raycastTarget = false;
        }

        rect.transform.SetAsLastSibling();
        
        Pintuname = rect.name;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta/ rect.root.GetChild(0).localScale;


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for (int i = 0; i < rect.transform.parent.childCount; i++)
        {
            rect.transform.parent.GetChild(i).GetComponent<Image>().raycastTarget = true;
        }
        rect.transform.SetSiblingIndex(index);

        Pintuname = "-1";

      

        if (PintuFinsh.finish)
        {
            PintuFinsh.rectHideTU.transform.GetComponent<Image>().color = new Color(PintuFinsh.rectHideTU.transform.GetComponent<Image>().color.r,
                 PintuFinsh.rectHideTU.transform.GetComponent<Image>().color.g,
                  PintuFinsh.rectHideTU.transform.GetComponent<Image>().color.b, 1);
            realFinish = true;
            PintuFinsh.finish = false;
            Destroy(this.gameObject);
            Destroy(PintuFinsh.rectHideTU.GetComponent<PintuFinsh>());
            PintuFinsh.rectHideTU = null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       // rect.anchoredPosition = eventData.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();

        index = this.transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
