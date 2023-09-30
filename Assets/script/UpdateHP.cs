using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateHP : MonoBehaviour
{
    public List<RectTransform> rt;
    // Update is called once per frame
    void Update()
    {
        updateHp();
    }
    void updateHp()
    {
        if(GameManager.instance.Hp_Player >= 120)
        {
            rt[0].localScale = new Vector3(1f, 1f, 1f);
        }
        else if(GameManager.instance.Hp_Player > 100)
        {
            int i = GameManager.instance.Hp_Player - 100;
            rt[0].localScale = new Vector3(i/20f, 1f, 1f);
            rt[1].localScale = new Vector3(1f, 1f, 1f);
        }
        else if(GameManager.instance.Hp_Player == 100)
        {
            rt[0].localScale = new Vector3(0f, 1f, 1f);
            rt[1].localScale = new Vector3(1f, 1f, 1f);
        }
        if(SceneManager.GetActiveScene().name == "SampleScene" || SceneManager.GetActiveScene().name == "School")
        {
            if(GameManager.instance.Hp_Player < 100 && GameManager.instance.Hp_Player >= 0)
            {
                int i = GameManager.instance.Hp_Player;
                rt[1].localScale = new Vector3(i/100f, 1f, 1f);
            }
        }
    }
}
