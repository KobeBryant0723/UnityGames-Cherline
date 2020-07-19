using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chapter11Controller : MonoBehaviour
{
    public GameObject m_chapter;
    public GameObject m_next;

    public GameObject m_huoji;
    public GameObject m_click;
    public GameObject m_cake;

    public GameObject m_left;
    public GameObject m_right;

    public GameObject m_electric;
    public GameObject m_ele1;
    public GameObject m_ele2;
    public GameObject m_ele3;
    public GameObject m_ele4;

    //public Texture2D ClickedCursorImg;
    // Start is called before the first frame update
    void Start()
    {
        m_next.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                m_chapter.SetActive(false);
                m_huoji.SetActive(true);
                m_cake.SetActive(true);
                m_left.SetActive(true);
                m_right.SetActive(true);
            }, 0.2f));
        });
        m_left.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
               StartCoroutine( FlareFire(m_left));
               k++;
               Destroy(m_left.GetComponent<Button>()); 
            }, 0.0f));
        });
        m_right.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(DelayToAction(delegate
            {
                StartCoroutine(FlareFire(m_right));
                k++;
                Destroy(m_right.GetComponent<Button>());
            }, 0.0f));
        });

        girl1.GetComponent<Button>().onClick.AddListener(delegate
        {
            boy.SetActive(true);
            girl1.SetActive(false);
        });
        m_huoji.SetActive(false);
        m_click.SetActive(false);
        m_cake.SetActive(false);
        m_left.SetActive(false);
        m_right.SetActive(false);
        m_electric.SetActive(false);
        m_ele1.SetActive(false);
        m_ele2.SetActive(false);
        m_ele3.SetActive(false);
        m_ele4.SetActive(false);
        girl1.SetActive(false);
        boy.SetActive(false);
    }
    private int k = 0;

    IEnumerator DelayToAction(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

    IEnumerator FlareFire(GameObject obj)
    {
        int k = 0;
        while (obj.activeInHierarchy)
        {
            if (k == 0)
            {
                obj.transform.GetChild(0).gameObject.SetActive(true);
                obj.transform.GetChild(1).gameObject.SetActive(false);
                k=1;
                yield return new WaitForSeconds(1f);
            }else if (k == 1)
            {
                obj.transform.GetChild(0).gameObject.SetActive(false);
                obj.transform.GetChild(1).gameObject.SetActive(true);
                k = 0;
                yield return new WaitForSeconds(1f);
            }
         

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 5 == 0)
        {
            if (k == 2)
            {
                k = 0;
                StartCoroutine(DelayToAction(delegate
                {
                    m_electric.SetActive(true);

                      Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    StartCoroutine(Loving());
                }, 0.5f));
            }
        }
    }

    private void OnDisable()
    {
        m_ele1.SetActive(false);
        m_ele2.SetActive(false);
        m_ele3.SetActive(false);
        m_ele4.SetActive(false);
    }
    public GameObject back;
    public GameObject boy;
    public GameObject girl1;
    IEnumerator Loving()
    {
        while (m_electric.activeInHierarchy)
        {
            yield return new WaitForSeconds(0.1f);
            m_ele1.SetActive(true);
            GameObject temp1 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
            GameObject temp2 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
            temp1.transform.SetAsLastSibling();
            while (temp1.transform.childCount != 0)
            {
                yield return null;
            }
            Destroy(temp1);
            Destroy(temp2);
            girl1.SetActive(true);
            yield return new WaitForSeconds(1.7f);
            while (!boy.activeInHierarchy)
            {
                yield return null;
            }

            GameObject temp11 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
            GameObject temp22 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
            temp11.transform.SetAsLastSibling();
            while (temp11.transform.childCount != 0)
            {
                yield return null;
            }
            boy.SetActive(false);
            Destroy(temp11);
            Destroy(temp22);
            girl1.SetActive(true);
            m_ele1.SetActive(false);
            m_ele2.SetActive(true);
            yield return new WaitForSeconds(1.7f);

            GameObject temp111 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
            GameObject temp222 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
            temp111.transform.SetAsLastSibling();
            while (temp111.transform.childCount != 0)
            {
                yield return null;
            }
            boy.SetActive(false);
            Destroy(temp111);
            Destroy(temp222);
            girl1.SetActive(true);
            m_ele2.SetActive(false);
            m_ele3.SetActive(true);
            yield return new WaitForSeconds(1.7f);
            while (!boy.activeInHierarchy)
            {
                yield return null;
            }

            GameObject temp1111 = GameObject.Instantiate(Resources.Load("Empty1") as GameObject, back.transform);
            GameObject temp2222 = GameObject.Instantiate(Resources.Load("Empty") as GameObject, back.transform);
            temp1111.transform.SetAsLastSibling();
            while (temp1111.transform.childCount != 0)
            {
                yield return null;
            }
            boy.SetActive(false);
            Destroy(temp1111);
            Destroy(temp2222);
            m_ele3.SetActive(false);
            m_ele4.SetActive(true);
            yield return new WaitForSeconds(1.7f);
           // m_ele4.SetActive(false);
            SceneManager.LoadScene(11);

        }
    }
}
