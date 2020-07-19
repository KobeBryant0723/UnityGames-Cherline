using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Chapter9Controller : MonoBehaviour
{
    public GameObject m_nextBtn;
    public GameObject m_image;
    public GameObject m_BookStore;
    public GameObject m_open;
    public GameObject m_light;
    public GameObject m_pointBtn;
    public GameObject m_girlBookImage;
    public GameObject m_clickBook;

    public GameObject m_bookDesk;
    public GameObject m_bookFirst;
    public GameObject m_bookSecond;

    public GameObject m_DoorBook;
    public GameObject m_DoorBookBtn;
    public GameObject m_Leg;
    public GameObject m_hand;
    // Start is called before the first frame update
    void Start()
    {
        handCount = 0;
        m_nextBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
                m_image.SetActive(false);
                m_BookStore.SetActive(true);
            }, 0.2f));

        });
        m_open.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
                m_BookStore.SetActive(false);
                m_light.SetActive(true);
            }, 0.2f));

        });
        m_pointBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
                m_light.SetActive(false);
                m_girlBookImage.SetActive(true);
            }, 0.2f));

        });
        m_clickBook.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
                m_girlBookImage.SetActive(false);
                m_bookDesk.SetActive(true);
                m_bookFirst.SetActive(true);
                m_bookSecond.SetActive(true);
            }, 0.2f));

        });
        m_DoorBookBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate ()
            {
                m_Leg.SetActive(true);
                if (handCount <= 2)
                {
                    m_hand.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, 234);
                    handCount++;
                }
            }, 0.0f));

        });

  



        m_BookStore.SetActive(false);
        m_light.SetActive(false);
        m_girlBookImage.SetActive(false);
        m_bookDesk.SetActive(false);
        m_bookFirst.SetActive(false);
        m_bookSecond.SetActive(false);
        m_DoorBook.SetActive(false);
        m_Leg.SetActive(false);
        m_DoorBookBtn.SetActive(false);
    }
    [SerializeField]
    private int handCount;

    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 100 == 0)
        {
            if (m_bookFirst.activeInHierarchy && m_bookSecond.activeInHierarchy)
            {
                if(m_bookFirst.GetComponent<Chapter9TheFirst>().hasArrange&&
                   m_bookSecond.GetComponent<Chapter9TheSecond>().hasArrange)
                {
                    m_DoorBook.SetActive(true);
                    m_DoorBookBtn.SetActive(true);
                    m_bookFirst.SetActive(false);
                    m_bookSecond.SetActive(false);
                    
                }
            }
            if (handCount == 3)
            {
                handCount = 0;
                m_DoorBookBtn.SetActive(false);
                StartCoroutine(DelayToAction(delegate { SceneManager.LoadScene(9); }, 2.0f));
                
            }
        }
    }
        
}
