using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class DefenceRune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IPointerExitHandler
{
    public float MouseOutOfButton = 0; //離開按鈕記數
    public List<RectTransform> Button;//按鈕
    public List<RectTransform> ButtonReference;//按鈕位置參照
    public UnityEvent failLaunching; //開啟Inspector觸發事件
    public UnityEvent successfulLaunching;
    public float HoldTime;
    //按下按鈕
    public void OnPointerDown(PointerEventData eventData){
    Debug.Log("PressDown");
    }
    //按鈕彈起
    public void OnPointerUp(PointerEventData eventData){
    for(int i = 0; i <= Button.Count; i++)
    {
        if(Button[i] == null)
        {
            continue;
        }
        else if(Button[i].position != ButtonReference[i].position)
        {
            MouseOutOfButton = 0;
        }
        else if(Button[i].position == ButtonReference[i].position)
        {
            GameManager.instance.OnLongClickCount += 1;
        } 
    }
    if(Button[Button.Count] == null)
    {
        return;
    }
    else if(Button[Button.Count].position != ButtonReference[Button.Count].position || GameManager.instance.OnLongClickCount != (Button.Count + 1))
    {
        failLaunching.Invoke();
        GameManager.instance.OnLongClickCount = 0;
    }
    else if(Button[Button.Count].position == ButtonReference[Button.Count].position || GameManager.instance.OnLongClickCount == (Button.Count + 1))
    {
        successfulLaunching.Invoke();
        GameManager.instance.OnLongClickCount = 0;
    }
    }

    public void OnPointerExit(PointerEventData eventData){
    MouseOutOfButton += 1;
    if(MouseOutOfButton >= 20)
    {
        MouseOutOfButton = 0;
    }
    }//當按下按鈕 PressDown = true 時計時
}  