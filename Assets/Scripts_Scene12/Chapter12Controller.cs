using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Chapter12Controller : MonoBehaviour
{
    public static int cloth;

    public GameObject m_chapter5;
    public GameObject m_Next;

    public GameObject m_back;

    public GameObject m_passerbyBtn;
    public GameObject ImageVideo;
    public Canvas canvas;

    public GameObject m_video;
    public GameObject m_GirlClick;

    public GameObject m_cry;
    public GameObject m_girlPoint;

    public GameObject m_Clothnext;
    public GameObject m_ChooseOne;
    public GameObject m_Appear;
    public GameObject m_girlSay;
    public GameObject m_boySay;
    public GameObject m_endSay;
    public GameObject m_endSayBtn;
    // Start is called before the first frame update
    void Start()
    {
        canvas.GetComponent<Animator>().enabled = false;
        cry = 1;
        m_Next.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_chapter5.SetActive(false);
                m_back.SetActive(true);
                StartCoroutine(DelayToAction(delegate
                {
                    canvas.GetComponent<Animator>().enabled = true;
                    StartCoroutine(DelayToAction(delegate
                    {
                      
                        m_passerbyBtn.SetActive(true);
                    }, 1f));
                  
                }, 1f));
            }, 0.2f));
         
        });

        m_passerbyBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            canvas.GetComponent<Animator>().enabled = false;
            ImageVideo.SetActive(true);

            m_video.GetComponent<VideoPlayer>().frame = 0;

            m_video.SetActive(true);
            m_passerbyBtn.SetActive(false);
            StartCoroutine(DelayToAction(delegate
            {
                m_video.GetComponent<VideoPlayer>().Play();

                Destroy(m_passerbyBtn.GetComponent<Button>());
                
                m_back.transform.GetChild(0).GetComponent<RectTransform>().localScale = Vector3.one;

                m_back.SetActive(false);
            }, 0.2f));
          

            StartCoroutine(PlayingVideo());
        });

        m_GirlClick.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_back.SetActive(false);
                m_GirlClick.SetActive(false);
                m_girlPoint.SetActive(true);
                m_cry.SetActive(true);
                m_cry.transform.GetChild(0).gameObject.SetActive(true);
            }, 0.2f));
        });
        m_Clothnext.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_ChooseOne.SetActive(true);
            }, 0.2f));
        }); 
        m_girlPoint.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                for (int i = 0; i < m_cry.transform.childCount; i++)
                {
                    if (i == cry)
                    {
                        m_cry.transform.GetChild(i).gameObject.SetActive(true);
                        cry++;
                        if (cry == 4)
                        {
                            m_girlPoint.SetActive(false);
                          //Destroy(m_girlPoint.GetComponent<Button>());
                          cry = 1;
                        }
                        return;
                    }else
                    {
                        m_cry.transform.GetChild(i).gameObject.SetActive(false);
                    }
                }
            }, 0.2f));
        });

        for (int i = 0; i < m_ChooseOne.transform.childCount; i++)
        {
            int count = i;
            m_ChooseOne.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate
            {
                m_Appear.SetActive(true);
                cloth = count;
                for (int j = 0; j < m_ChooseOne.transform.childCount; j++)
                {
                    Destroy(m_ChooseOne.transform.GetChild(j).GetComponent<Button>());
                }

            });
        }
        m_Appear.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_girlSay.SetActive(true);
            }, 0.2f));
        });
        m_girlSay.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_boySay.SetActive(true);
            }, 0.2f));
        });
        m_boySay.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_endSay.SetActive(true);
            }, 0.2f));
        });
        m_endSayBtn.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                SceneManager.LoadScene(12);
            }, 0.2f));
        });
        m_back.SetActive(false);
        m_passerbyBtn.SetActive(false);
        ImageVideo.SetActive(false);
        m_video.SetActive(false);
        m_girlPoint.SetActive(false);
        m_GirlClick.SetActive(false);
        m_cry.SetActive(false);
        m_ChooseOne.SetActive(false);
        m_Appear.SetActive(false);
        m_girlSay.SetActive(false);
        m_boySay.SetActive(false);
        m_endSay.SetActive(false);


    }

    private int cry;

    IEnumerator PlayingVideo()
    {
        //我也搞不懂为什么差了2
        while (m_video.GetComponent<VideoPlayer>().frame + 2 != (long)m_video.GetComponent<VideoPlayer>().frameCount)
        {
        
            yield return null;
        }
        Debug.Log("ending");
        m_back.SetActive(true);
        m_back.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        m_video.SetActive(false);
        m_GirlClick.SetActive(true);
        ImageVideo.SetActive(false);
    }


    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
