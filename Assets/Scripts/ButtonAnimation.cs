using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector2(1.2f, 1.2f);
        //audio.clip = AudioClip.Instantiate(Resources.Load("close") as AudioClip);
        //audio.PlayOneShot(audio.clip);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
    } 
    public new AudioSource audio;

    void Awake()
    {
       
        if (!this.gameObject.GetComponent<AudioSource>())
        {
            audio= this.gameObject.AddComponent<AudioSource>();
            audio.playOnAwake = false;
            audio.clip = AudioClip.Instantiate(Resources.Load("click") as AudioClip);
        }
        else
        {
            audio = this.gameObject.GetComponent<AudioSource>();
            audio.playOnAwake = false;
        }

        if (this.gameObject.GetComponent<Button>())
        {
            this.gameObject.GetComponent<Button>().onClick.AddListener(delegate {

                audio.clip = AudioClip.Instantiate(audio.clip);
                audio.PlayOneShot(audio.clip);
            });
        }
       
    }
    void Update()
    {
        
    }
}
