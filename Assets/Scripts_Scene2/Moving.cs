using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Moving : MonoBehaviour
{
    public Image image;
    public GameObject _TwoYear;
    public Button _TwoYearBtn;
    public GameObject _VideoPlayer;
    public Scrollbar _ScBar;
    public Button twoMouthBtn;
   
    // Start is called before the first frame update

    private bool left;
    private bool right;
    private int num=1;

    void Start()
    {
        _TwoYear.SetActive(false);
        _VideoPlayer.SetActive(false);
        left = false;
        right = false;
        num = 0;
        twoMouthBtn.onClick.AddListener(delegate
        {
            StartCoroutine(TwoMouth());
        });
        _TwoYearBtn.onClick.AddListener(delegate
        {
            _VideoPlayer.SetActive(true);
           // _VideoPlayer.GetComponent<VideoPlayer>().frame = 0;
            _VideoPlayer.GetComponent<VideoPlayer>().Play();
            StartCoroutine(WaitingLoading());
        });
    }
    //TwoMouth
    IEnumerator TwoMouth()
    {
        yield return new WaitForSeconds(0.1f);
        twoMouthBtn.gameObject.SetActive(false);
        num++;
        image.overrideSprite = Resources.Load("婴儿/" + "1", typeof(Sprite)) as Sprite;
    }



    IEnumerator WaitingLoading()
    {
        yield return new WaitForSeconds(0.5f);
        _TwoYear.SetActive(false);
        yield return new WaitForSeconds(4.0f); //vp.frame >=（long）vp.frameCount
        while (_VideoPlayer.GetComponent<VideoPlayer>().frame+2< (long)_VideoPlayer.GetComponent<VideoPlayer>().frameCount)
        {
            yield return null;
        }
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
     
        if (num == 6)
        {
            _TwoYear.SetActive(true);
            image.transform.gameObject.SetActive(false);
            _ScBar.transform.gameObject.SetActive(false);
            num++;
        }
        if (num == 0) return;
        if (Input.mousePosition.x / Screen.width < 0.4f)
        {
            left = true;
        }
        if (Input.mousePosition.x / Screen.width > 0.6f)
        {
            right = true;
        }
        if (left && right&&num<=5)
        {
            left = false;
            right = false;
            num++;
            _ScBar.size = (float)(num / 6.0f);
            image.overrideSprite = Resources.Load("婴儿/"+num.ToString(), typeof(Sprite)) as Sprite;
        }
      
    }
}
