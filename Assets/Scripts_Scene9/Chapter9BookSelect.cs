using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chapter9BookSelect : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler

{
    public static RectTransform momentLastSelectedBook;

    public static Transform momentSelectedBookParent;

    public static RectTransform momentNowSelectedBook;

    public static Transform momentNowBookParent;

    public Transform parent;

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (momentNowSelectedBook == null)
        {
            momentNowSelectedBook = this.GetComponent<RectTransform>();
            momentNowBookParent = momentNowSelectedBook.parent;
            ChangeColor(momentNowSelectedBook, 0.5f);
        }
        else
        {
            momentLastSelectedBook = momentNowSelectedBook;
            momentSelectedBookParent = momentNowBookParent;

            momentNowSelectedBook = this.GetComponent<RectTransform>();
            momentNowBookParent = momentNowSelectedBook.parent;
            ChangeBook(momentLastSelectedBook, momentNowSelectedBook);
            ChangeColor(momentLastSelectedBook, 1);
            ChangeColor(momentNowSelectedBook, 1);
            momentNowSelectedBook = null;
            momentNowBookParent = null;
            momentLastSelectedBook = null;
            momentNowBookParent = null;

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector2(1.2f, 1.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
    }

    void ChangeBook(RectTransform a,RectTransform b)
    {
        Transform aParent = a.parent;
        Transform bParent = b.parent;
        int indexA = a.GetSiblingIndex();
        int indexB = b.GetSiblingIndex();

        //a.SetParent(parent);
        //b.SetParent(parent);

        b.SetParent(aParent);
        b.SetSiblingIndex(indexA);
        a.SetParent(bParent);
        a.SetSiblingIndex(indexB);
    }

    void ChangeColor(Transform a,float value)
    {
        a.GetComponent<Image>().color = new Color(a.GetComponent<Image>().color.r,
            a.GetComponent<Image>().color.g, a.GetComponent<Image>().color.b,
            value);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
