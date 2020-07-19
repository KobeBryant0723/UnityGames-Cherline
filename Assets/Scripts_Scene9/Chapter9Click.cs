using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chapter9Click : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(m_color.r, m_color.g, m_color.b, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(m_color.r, m_color.g, m_color.b, 0.0f);
    }

    private Color m_color;

    // Start is called before the first frame update
    void Start()
    {
        m_color = this.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
