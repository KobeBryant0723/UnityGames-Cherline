using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Chapter2Controller : MonoBehaviour
{

    public GameObject _Question1;
    public GameObject _Question2;
    public GameObject _Question3;
    public int[] answers = { -1, -1, -1 };//Correct Answer:d,d,a
    //public List<int> answers =new List<int> ();

    public GameObject result;
    public Button resultBtn;

    public GameObject _Rethink;
    public Button _RethinkBtn;

    public GameObject _Cry;
    public Button _CryBtn;

    public GameObject _VedioPlayers;
    public Button _VideoBtn;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _Question1.transform.childCount; i++)
        {
            int count = i;
            _Question1.transform.GetChild(i).GetComponent<Button>().
                onClick.AddListener(delegate
                {
                    answers[0] = count;
                    QuestionTransmit(_Question1, _Question2);
                });
        }
        for (int i = 0; i < _Question2.transform.childCount; i++)
        {
            int count = i;
            _Question2.transform.GetChild(i).GetComponent<Button>().
                onClick.AddListener(delegate
                {
                    answers[1] = count;
                    QuestionTransmit(_Question2, _Question3);
                });
        }
        for (int i = 0; i < _Question3.transform.childCount; i++)
        {
            int count = i;
            _Question3.transform.GetChild(i).GetComponent<Button>().
                onClick.AddListener(delegate
                {
                    answers[2] = count;
                    StartCoroutine(ExamResult());
                });
        }
        resultBtn.onClick.AddListener(delegate
        {
            StartCoroutine(ReThinkAnimation());
        });
        _RethinkBtn.onClick.AddListener(delegate
        {
            StartCoroutine(StopRethinkNCry());
        });
        _CryBtn.onClick.AddListener(delegate
        {
           

            StartCoroutine(Waiting());
         

        });
        _VideoBtn.onClick.AddListener(delegate
        {
            SceneManager.LoadSceneAsync(4);
        });

        
        _Question2.SetActive(false);
        _Question3.SetActive(false);
        result.SetActive(false);
        _Rethink.SetActive(false);
        _Cry.SetActive(false);
        _RethinkBtn.gameObject.SetActive(false);
        _CryBtn.gameObject.SetActive(false);
        _VedioPlayers.SetActive(false);
        _VideoBtn.gameObject.SetActive(false);
    }
  

    //ResultAnimation :DDA
    IEnumerator ExamResult()
    {
        QuestionTransmit(_Question3, result);
        if(answers[0]==3&& answers[1]==3&& answers[2] ==0)
        {
            //Error occur
            result.GetComponent<Image>().overrideSprite = Resources.Load("小学/" +"好结果", typeof(Sprite)) as Sprite;
        }
        else
        {
            //0 errors,0 warnings
            result.GetComponent<Image>().overrideSprite = Resources.Load("小学/" + "坏结果", typeof(Sprite)) as Sprite;
        }
        yield return new WaitForSeconds(0.8f);
    }
    //StopRethinkNCry
    IEnumerator StopRethinkNCry()
    {
        yield return new WaitForSeconds(0.1f);
        _RethinkBtn.gameObject.SetActive(false);
        _Cry.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        _Rethink.SetActive(false);
        //while (_Rethink.GetComponent<VideoPlayer>().isPlaying)
        //{
        //    yield return null;
        //}
        yield return new WaitForSeconds(4f);
        _CryBtn.gameObject.SetActive(true);
       
    }
    //ReThinkAnimation
    IEnumerator ReThinkAnimation()
    {
        result.SetActive(false);
        _Rethink.gameObject.SetActive(true);
        _Rethink.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _Rethink.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        _RethinkBtn.gameObject.SetActive(true);
    }

    private void QuestionTransmit(GameObject first, GameObject second)
    {
        StartCoroutine(Wait(first,second));
      
    }
    IEnumerator Wait(GameObject first, GameObject second)
    {
        yield return new WaitForSeconds(0.1f);
        first.SetActive(false);
        second.SetActive(true);
    }
    //wait 0.5s
    IEnumerator Waiting()
    {
        _VedioPlayers.SetActive(true);
        _VideoBtn.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);

        _CryBtn.gameObject.SetActive(false);
        _Cry.SetActive(false);
      
    }
}
