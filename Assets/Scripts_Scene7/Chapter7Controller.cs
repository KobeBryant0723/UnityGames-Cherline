using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Chapter7Controller : MonoBehaviour
{
    public GameObject InitialImage;
    public GameObject _Girl1;
    public GameObject _Question;
    public GameObject _Yes;
    public GameObject _No;

    public GameObject _HaveTry;
    public GameObject _Girl2;
    public GameObject _AnyWay;
    public GameObject _NextStep;
    
    public GameObject _SendLetter;
    public GameObject _ClickBTN;
    public GameObject _ClickImage;

    public GameObject _Sorry;
    // Start is called before the first frame update
    void Start()
    {
        _Girl1.GetComponent<Button>().onClick.AddListener(delegate
        {
            _Question.SetActive(true);
            _Girl1.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            Destroy(_Girl1.GetComponent<ButtonAnimation>());
            Destroy(_Girl1.GetComponent<Button>());
         
        });
        _Question.GetComponent<Button>().onClick.AddListener(delegate
        {
            _Yes.SetActive(true);
            _No.SetActive(true);
            _Question.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            Destroy(_Question.GetComponent<ButtonAnimation>());
            Destroy(_Question.GetComponent<Button>());
          
        });
        _Yes.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(Yes());
        });
        _No.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(No());
        });
        _Girl2.GetComponent<Button>().onClick.AddListener(delegate
        {
            _Girl2.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            _AnyWay.SetActive(true);
            Destroy(_Girl2.GetComponent<ButtonAnimation>());
            Destroy(_Girl2.GetComponent<Button>());
        
        });
        _AnyWay.GetComponent<Button>().onClick.AddListener(delegate
        {
            _AnyWay.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            _NextStep.SetActive(true);
            Destroy(_AnyWay.GetComponent<ButtonAnimation>());
            Destroy(_AnyWay.GetComponent<Button>());
        });
        _NextStep.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(NextStep());
        });
        _ClickBTN.GetComponent<Button>().onClick.AddListener(delegate
        {
        
            StartCoroutine(SorryBeforeSit());
        });
        _GirlSit.GetComponent<Button>().onClick.AddListener(delegate
        {
            _GirlSit.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            _BoysaysSorry.SetActive(true);
            Destroy(_GirlSit.GetComponent<ButtonAnimation>());
            Destroy(_GirlSit.GetComponent<Button>());
        });
        _BoysaysSorry.GetComponent<Button>().onClick.AddListener(delegate
        {
            _BoysaysSorry.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
            _WhatWouldyouDo.SetActive(true);
            StartCoroutine(WhatWoulduDO());
            Destroy(_BoysaysSorry.GetComponent<ButtonAnimation>());
            Destroy(_BoysaysSorry.GetComponent<Button>());
        });
        _A.GetComponent<Button>().onClick.AddListener(delegate
        {
            StartCoroutine(A());
        });
        _B.GetComponent<Button>().onClick.AddListener(delegate
        {
            SceneManager.LoadScene(7);
        });
        _OvereatingBTN.GetComponent<Button>().onClick.AddListener(delegate
        {
           
            StartCoroutine(BackToTheMenu());
        });
        _Question.SetActive(false);
        _Yes.SetActive(false);
        _No.SetActive(false);
        _HaveTry.SetActive(false);
        _Girl2.SetActive(false);
        _AnyWay.SetActive(false);
        _NextStep.SetActive(false);
        _SendLetter.SetActive(false);
        _Sorry.SetActive(false);
        _InitialImageSitting.SetActive(false);
        _BoysaysSorry.SetActive(false);
        _WhatWouldyouDo.SetActive(false);
        _A.SetActive(false);
        _B.SetActive(false);
        _Overeating.SetActive(false);
        _BadResult.SetActive(false);
    }
    //_Yes
    IEnumerator Yes()
    {
        _SendLetter.SetActive(true);
        _SendLetter.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(0.2f);
        InitialImage.SetActive(false);
    }
    //NO
    IEnumerator No()
    {
        yield return new WaitForSeconds(0.1f);
        _HaveTry.SetActive(true);
        _Girl2.SetActive(true);
        InitialImage.SetActive(false);
    }
    //_NextStep
    IEnumerator NextStep()
    {
        _SendLetter.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _HaveTry.SetActive(false);
       
    }
    //__ClickBTN
    IEnumerator A()
    {
        yield return new WaitForSeconds(0.1f);
        _InitialImageSitting.SetActive(false);
        _Overeating.SetActive(true);
    }
    public GameObject _InitialImageSitting;
    public GameObject _GirlSit;
    public GameObject _BoysaysSorry;
    public GameObject _WhatWouldyouDo;
    public GameObject _A;
    public GameObject _B;
    public GameObject _Overeating;
    public GameObject _OvereatingBTN;
    public GameObject _BadResult;
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SorryBeforeSit()
    {
        yield return new WaitForSeconds(0.1f);
        _Sorry.SetActive(true);
        _SendLetter.SetActive(false);
        while (_Sorry.GetComponent<VideoPlayer>().frame + 1 == (long)_Sorry.GetComponent<VideoPlayer>().frameCount)
        {
            yield return null;
        }
        _Sorry.SetActive(false);
        _InitialImageSitting.SetActive(true);
        _GirlSit.SetActive(true);

    }

    //What would you do
    IEnumerator WhatWoulduDO()
    {
        yield return new WaitForSeconds(2);
        _A.SetActive(true);
        _B.SetActive(true);
    }
    //Back to the Menu automatically
    IEnumerator BackToTheMenu()
    {
        yield return new WaitForSeconds(0.1f);
        _Overeating.SetActive(false);
        _BadResult.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadSceneAsync(0);
    }

}
