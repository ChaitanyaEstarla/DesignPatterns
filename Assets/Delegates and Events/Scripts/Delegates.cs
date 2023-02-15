using UnityEngine;

public class Delegates : MonoBehaviour
{
    delegate void PointerToMath(int num1, int num2);

    private PointerToMath _mathFunctions;

    #region Untiy Events

    private void OnEnable()
    {
        _mathFunctions += Add;
        _mathFunctions += Sub;
        _mathFunctions += Mul;
        _mathFunctions += Div;
    }

    private void Start()
    {
        _mathFunctions += Add;
        _mathFunctions += Sub;
        _mathFunctions += Mul;
        _mathFunctions += Div;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            _mathFunctions(5, 2);
        }
    }
    
    private void OnDisable()
    {
        _mathFunctions -= Add;
        _mathFunctions -= Sub;
        _mathFunctions -= Mul;
        _mathFunctions -= Div;
    }
    
    private void OnDestroy()
    {
        _mathFunctions -= Add;
        _mathFunctions -= Sub;
        _mathFunctions -= Mul;
        _mathFunctions -= Div;
    }

    #endregion

    #region Member Functions

    private void Add(int a, int b)
    {
        Debug.Log(a+b);
    }
    
    private void Sub(int a, int b)
    {
        Debug.Log(a-b);
    }
    private void Mul(int a, int b)
    {
        Debug.Log(a*b);
    }
    private void Div(int a, int b)
    {
        Debug.Log(a/b);
    }

    #endregion
}
