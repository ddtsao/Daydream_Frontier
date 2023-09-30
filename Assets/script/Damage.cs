using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public void GetDamage(int n)
    {
        GameManager.instance.Hp_Player -= n;
        if(GameManager.instance.Hp_Player > 100)
        {
            float dmg = n/20f;
            GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[2].localScale -= new Vector3(dmg, 0f, 0f); 
        }
        else if(GameManager.instance.Hp_Player < 100)
        {
            if(GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[2].localScale != Vector3.zero)
            {
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[2].localScale = Vector3.zero;
            }
            if(GameManager.instance.Hp_Player >= 0)
            {
                float dmg = n/100f;
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[0].localScale -= new Vector3(dmg, 0f, 0f);
            }
            else if(GameManager.instance.Hp_Player < 0)
            {
                GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[0].localScale = Vector3.zero;
            }
        }
        else if(GameManager.instance.Hp_Player == 100)
        {
            GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[2].localScale = Vector3.zero;
            GameObject.Find("Menu").GetComponent<CharacterMenu>().HealthPointBar[0].localScale = Vector3.one;
        }
    }
    public virtual void DealDamage(int dmg)
    {
        
    }
}