using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class SkillRune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerExitHandler
{
    public float MouseOutOfButton = 0; //離開按鈕記數
    public List<RectTransform> Button;//按鈕
    public List<RectTransform> ButtonReference;//按鈕位置參照
    public List<RectTransform> StartPosition;
    public UnityEvent FailLaunching; //開啟Inspector觸發事件
    public UnityEvent SuccessfulLaunching;
    public UnityEvent Check;
    public Animator animator;
    public Animator missAnimation;
    public GameObject startPos;
    public float[] PressDownPos;
    public int Moob;
    public float HoldTime;  
    public Camera cam;
    bool noRepeat = false;
    bool HadNoPress = false;
    //按下按鈕
    private void Update()
    {
        Check.Invoke();
    }
    void PlayMiss()
    {
        if(missAnimation != null)
        {
            missAnimation.SetTrigger("play");
        }
    }
    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            return;
        }
        noRepeat = false;
        if(SceneManager.GetActiveScene().name == "FightingMode")
        {
            if(PressDownPos.Length == 0)
            {
                return;
            }
            else if((eventData.position.x - PressDownPos[1]) / ( PressDownPos[0] - eventData.position.x) < 0 || (eventData.position.y - PressDownPos[3]) / (PressDownPos[2] - eventData.position.y) < 0)
            {
                Debug.Log("8");
                GameManager.instance.OnLongClickCount = 0;
                MouseOutOfButton = 0;
                HadNoPress = true;
                PlayMiss();
            }
            Debug.Log(eventData.position);
        } 
        if(SceneManager.GetActiveScene().name == "Boss")
        {
            if(PressDownPos.Length == 0)
            {
                return;
            }
            else if((eventData.position.x - PressDownPos[1]) / ( PressDownPos[0] - eventData.position.x) < 0 || (eventData.position.y - PressDownPos[3]) / (PressDownPos[2] - eventData.position.y) < 0)
            {
                Debug.Log("8");
                GameManager.instance.OnLongClickCount = 0;
                MouseOutOfButton = 0;
                PlayMiss();
            }
        }
    }
    //按鈕彈起
    public void OnPointerUp(PointerEventData eventData){
    if(eventData.button == PointerEventData.InputButton.Right)
    {
        return;
    }
    for(int i = 0; i < Button.Count; i++)
    {
        if(Button[i] == null)
        {
            continue;
        }
        else if(Button[i].position != ButtonReference[i].position)
        {
            MouseOutOfButton = 0;
            PlayMiss();
        }
        else if(Button[i].position == ButtonReference[i].position)
        {
            GameManager.instance.OnLongClickCount += 1;
        } 
    }
    if(Button[Button.Count - 1] == null)
    {
        return;
    }
    else if(Button[Button.Count - 1].position != ButtonReference[Button.Count - 1].position || GameManager.instance.OnLongClickCount < Button.Count || HadNoPress)//這裡改過!=
    {
        if(!noRepeat)
        {
            Debug.Log("3");
            GameManager.instance.OnLongClickCount = 0;
            FailLaunching.Invoke();
            MouseOutOfButton = 0;
        }
        
    }
    else if(Button[Button.Count - 1].position == ButtonReference[Button.Count - 1].position || GameManager.instance.OnLongClickCount >= Button.Count)
    {
        Debug.Log("6");
        GameManager.instance.OnLongClickCount = 0;
        SuccessfulLaunching.Invoke();
        MouseOutOfButton = 0;
    }
    }

    public void OnPointerExit(PointerEventData eventData){
    if(eventData.button == PointerEventData.InputButton.Right)
    {
        return;
    }
    MouseOutOfButton += 1;
    if(MouseOutOfButton >= Moob)
    {
        Debug.Log("7");
        FailLaunching.Invoke();
        MouseOutOfButton = 0;
    }
    }//當按下按鈕 PressDown = true 時計時
    public void NoPress(string animName)
    {
        AnimatorStateInfo animatorStateInfo;
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if((animatorStateInfo.normalizedTime > 1.0f) && animatorStateInfo.IsName(animName))
        {
            MouseOutOfButton = 0;
            if(GameManager.instance.OnLongClickCount != Button.Count)//這裡改過!= Button.Count
            {
                Debug.Log("1");
                GameManager.instance.OnLongClickCount = 0;
                Debug.Log("2");
                FailLaunching.Invoke();
                noRepeat = true;
            }
            else if(GameManager.instance.OnLongClickCount == Button.Count)
            {
                Debug.Log("4");
                GameManager.instance.OnLongClickCount = 0;
                Debug.Log("5");
                SuccessfulLaunching.Invoke();
            }
        }
    }
}