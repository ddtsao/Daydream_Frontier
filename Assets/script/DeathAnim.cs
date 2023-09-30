using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAnim : MonoBehaviour
{
   public List<AudioSource> audioSource;
   public List<RectTransform> go;
   public Animator animator;
   void Death()
   {
      if(GameManager.instance.Hp_Player <= 0)
      {
         if(SceneManager.GetActiveScene().name == "SampleScene")
         {
            return;
         }
         else if(SceneManager.GetActiveScene().name == "Boss")
         {
            animator.SetTrigger("death");
            Invoke("ReloadScene2", 2.3f);
            GameManager.instance.Hp_Player = 20;
            go[0].localScale = new Vector3(0f, 1f, 1f);
         }
         else if(SceneManager.GetActiveScene().name == "FightingMode")
         {
            animator.SetTrigger("death");
            GameObject.Find("InteractionField").GetComponent<NormalATKController>().animator1.speed = 0;
            Invoke("ReloadScene", 5f);
            GameManager.instance.Hp_Player = 20;
            go[0].localScale = new Vector3(0f, 1f, 1f);
         }
      }
      else
      {
         return;
      }
   }
   void ReloadScene()
   {
      SceneManager.LoadScene("SampleScene");
   }
   IEnumerator Dead()
   {
      animator.SetTrigger("death");
      GameObject.Find("InteractionField").GetComponent<NormalATKController>().animator1.speed = 0;
      yield return new WaitForSeconds(4f);
      Debug.Log("G");
      GameManager.instance.Hp_Player = 20;
      yield return new WaitForSeconds(2f);
      Debug.Log("l");
      SceneManager.LoadScene("SampleScene");
      GameManager.instance.Hp_Player = 20;
   }
   void ReloadScene2()
   {
      animator.SetTrigger("death");
      SceneManager.LoadScene("School");
   }
   void DeathAudio()
   {
      audioSource[0].Play();
   }
   private void Update()
   {
      Death();
   }
}
