using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chapter15MoveBo : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
    private bool hasSelect;
    public GameObject m_hug1;
    public GameObject m_move;
    public void OnPointerClick(PointerEventData eventData)
    {
        hasSelect = !hasSelect;
        this.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 1);
    }


    private Color cl;
    // Start is called before the first frame update
    void Start()
    {
        hasSelect = false;
        cl = this.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSelect)
        {
            this.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, this.GetComponent<RectTransform>().position.y);
        }else
        {
            if (this.GetComponent<RectTransform>().anchoredPosition.x > 296.0f)
            {
                StartCoroutine(DelayToAction(delegate
                {
                    m_hug1.SetActive(true);
                    m_move.SetActive(false);
                }, 0.7f));

            }
        }
    }
    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
}
