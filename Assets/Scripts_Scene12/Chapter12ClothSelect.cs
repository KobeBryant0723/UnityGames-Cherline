using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Chapter12ClothSelect : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private Color color;
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);
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
