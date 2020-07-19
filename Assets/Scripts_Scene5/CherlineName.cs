using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CherlineName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject classroom;
    public GameObject classroomNName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        classroomNName.SetActive(true);
        classroom.SetActive(false);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        classroomNName.SetActive(false);
        classroom.SetActive(true);
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
