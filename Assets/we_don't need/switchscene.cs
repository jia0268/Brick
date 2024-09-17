using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class switchscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void livingroom()
    {
        //客廳 起始0
        SceneManager.LoadScene(4);
    }
    public void playroom_choose() {
        //選擇引導模式後 選擇模型 1
        SceneManager.LoadScene(1);
    }
    public void playroom_mod1() {
        //小車車 2
        SceneManager.LoadScene(2);
    }
    public void playroom_mod2() {
        //觀測站 3
        SceneManager.LoadScene(3);
    }
    public void playroom_free() {
        //自由模式 4
        SceneManager.LoadScene(0);
    }
    public void playroom()
    {
        //探索Playroom 5
        SceneManager.LoadScene(5);
    }
}
