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
        //���U �_�l0
        SceneManager.LoadScene(4);
    }
    public void playroom_choose() {
        //��ܤ޾ɼҦ��� ��ܼҫ� 1
        SceneManager.LoadScene(1);
    }
    public void playroom_mod1() {
        //�p���� 2
        SceneManager.LoadScene(2);
    }
    public void playroom_mod2() {
        //�[���� 3
        SceneManager.LoadScene(3);
    }
    public void playroom_free() {
        //�ۥѼҦ� 4
        SceneManager.LoadScene(0);
    }
    public void playroom()
    {
        //����Playroom 5
        SceneManager.LoadScene(5);
    }
}
