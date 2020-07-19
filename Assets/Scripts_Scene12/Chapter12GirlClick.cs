using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Chapter12GirlClick : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject m_clickIMG;
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_clickIMG.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_clickIMG.SetActive(false);
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
