using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Actions : MonoBehaviour
{
    private Button _mAddButton;
    private Renderer _mRenderer;
    private UnityAction _mMyFirstAction;
    //This is the number that the script updates
    private float _mMyNumber; 
    
    private void Start()
    {
        _mAddButton = GetComponent<Button>();
        _mRenderer = GetComponent<SpriteRenderer>();
        //Make a Unity Action that calls your function
        _mMyFirstAction += MyFunction;
        _mMyFirstAction += MySecondFunction;
        //Register the Button to detect clicks and call your Unity Action
        _mAddButton.onClick.AddListener(_mMyFirstAction);
    }
    private void MyFunction()
    {
        _mMyNumber++;
        Debug.Log("First Added : " + _mMyNumber);
    } 
    private void MySecondFunction()
    {
        _mRenderer.material.color = Color.blue;
        Debug.Log("Second Added");
    }
}