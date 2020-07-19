using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnclickScripts : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject click;

    public void OnPointerEnter(PointerEventData eventData)
    {
        click.SetActive(true);
       

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        click.SetActive(false);


    }
    private void Start()
    {
        if (click == null) click = GameObject.Instantiate(Resources.Load("Onclick") as GameObject);

        click.transform.SetParent(this.transform);
        click.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        click.GetComponent<RectTransform>().localScale = Vector2.one;
       click.SetActive(false);

        click.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0);
        click.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0);

    }

}
