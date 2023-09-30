using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public Animator animator;
   void Death()
   {
      if(GameManager.instance.Hp_Player <= 0)
      {
         animator.SetTrigger("death");
      }
      else
      {
         return;
      }
   }
   private void Update()
   {
      Death();
   }
}
