using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRect : MonoBehaviour
{
    //声明符合canvas的最大背景图
    private RectTransform rect;
    private Vector2 vec2;
    private Vector3 position;
    // Use this for initialization
    void Awake()
    {
        rect = this.transform.GetComponent<RectTransform>();
        vec2 = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y);
        position = rect.position;
    }
    void Start()
    {
        //对canvas进行调整

        for (int i = 0; i < this.transform.childCount; i++)
        {
            Vector2 percent = vec2 / this.transform.GetChild(i).GetComponent<RectTransform>().sizeDelta;
            this.transform.GetChild(i).GetComponent<RectTransform>().localScale *= percent;
            this.transform.GetChild(i).GetComponent<RectTransform>().position = position;
        }

    }
}
