using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TwoMouthBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector2(1.2f, 1.2f);

        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
