using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Chapter11HuoJi : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    private bool hasClick;
    public Texture2D ClickedCursorImg;
    public void OnPointerClick(PointerEventData eventData)
    {
        hasClick = true;
        StartCoroutine(DelayToAction(delegate
        {
            Texture2D td = Resources.Load("大学/火机") as Texture2D;
            Sprite sp = Sprite.Create(td, new Rect(0, 0, td.width, td.height), Vector2.zero);
            this.GetComponent<Image>().overrideSprite = sp;
            this.GetComponent<Image>().raycastTarget = false;
            Cursor.SetCursor(ClickedCursorImg, Vector2.zero, CursorMode.Auto);
        }, 0.0f));
    }

    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }


    // Start is called before the first frame update
    void Start()
    {

        hasClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasClick)
        {
            this.gameObject.GetComponent<RectTransform>().position = Input.mousePosition;
        }   
    }

    public GameObject m_click;

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_click.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_click.SetActive(false);
    }
}
