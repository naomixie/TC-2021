using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    //音源AudioSource相当于播放器，而音效AudioClip相当于磁带
    public AudioSource music;
    public AudioClip alarm;//这里我要给主角添加跳跃的音效

    // Start is called before the first frame update
    void Start()
    {
        //给对象添加一个AudioSource组件
        music = gameObject.GetComponent<AudioSource>();
        //加载音效文件，我把跳跃的音频文件命名为alarm
        alarm = Resources.Load<AudioClip>("music/alarm");  
        //把音源music的音效设置为alarm
        music.clip = alarm;
        //播放音效
        music.Play();   
    }

}