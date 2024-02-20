using System;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GenericTest : MonoBehaviour
{
    private int[] testArr;

    private void Start()
    {
        testArr = new int[2] { 1,1 };
        FunctionOne();
        FunctionTwo();
    }

    public void FunctionOne()
    {
        try
        {
            FunctionThree();
        }
        catch(Exception Ex) 
        {
            Debug.Log(" Function 1 " + Ex);
        }
    }

    public void FunctionThree()
    {
        for (int i = 0; i <= testArr.Length; i++)
        {
            Debug.Log(testArr[i]);
        }
    }

    public void FunctionTwo() 
    {
        try
        {
            for (int i = 0; i <= testArr.Length; i++)
            {
                Debug.Log(testArr[i]);
            }
        }
        catch(Exception Ex)
        {
            Debug.Log(" Function 2 " + Ex);
        }
    }
}
