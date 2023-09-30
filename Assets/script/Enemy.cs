using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject go;
    public int Hp_Enemy;
    public List<GameObject> Enemies;
    public GameObject enemy;
    public RectTransform bar;

    public void DealDamage(int dmg)
    {
        this.GetComponent<Enemy>().Hp_Enemy -= dmg;
    }
    public void EnemyDefeated()
    {
        if(Hp_Enemy <= 0)
        {
            if(this.gameObject.name == "enemy_wolf")
            {
                animator.SetTrigger("enemy_die");
                StartCoroutine(ReloadScene("win"));
            }
        }
        else if(Hp_Enemy <= 25)
        {
            if(this.gameObject.name == "Enemy_man")
            {
                GameObject.Find("InteractionField").GetComponent<SmokeBlast>().CountUlt = 2;
                animator.SetInteger("atk_int", 5);
                animator.SetTrigger("dead");
            }
        }
        else
        {
            return;
        }
    }
    public void TurnOffSkill()
    {
        go.SetActive(false);
        GameObject.Find("HealthPoints").SetActive(false);
        GameObject.Find("HpBar").SetActive(false);
        GameObject.Find("Backpack").SetActive(false);
        animator.SetTrigger("play_dead");
    } 
    IEnumerator ReloadScene(string c)
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(c);
    }
    private void Update()
    {
       EnemyDefeated(); 
    }
}