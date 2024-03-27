using System;
using UnityEngine;
using System.Threading.Tasks;

namespace Delegates_and_Events.Scripts
{
    public class Delegates : MonoBehaviour
    {
        public delegate void PointerToMath(int num1, int num2);
        public PointerToMath _mathFunctions;
        public event PointerToMath MathCalcEvents;

        #region Untiy Events

        private void OnEnable()
        {
            _mathFunctions = DebugParams;
            _mathFunctions += Add;
            _mathFunctions += Sub;
            _mathFunctions += Mul;
            _mathFunctions += Div;
            MathCalcEvents += _mathFunctions;
        }

        private void Start()
        {
            //AsyncTaskTest();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                _mathFunctions(5, 2);
                //MathCalcEvents?.Invoke(5, 2);
            }
        }
    
        private void OnDisable()
        {
            _mathFunctions -= Add;
            _mathFunctions -= Sub;
            _mathFunctions -= Mul;
            _mathFunctions -= Div;
        }
    
        #endregion
        
        private delegate Task<int> CalculateAsyncDelegate(int a, int b);

        #region Member Functions

        private async void AsyncTaskTest()
        {
            CalculateAsyncDelegate calculateDelegate = CalculateAsync;

            Debug.Log("Starting calculation...");

            // Invoke the async method using the delegate and await the result
            var result = await calculateDelegate(10, 20);

            Debug.Log($"Calculation result: {result}");
        }

        private static async Task<int> CalculateAsync(int a, int b)
        {
            // Simulate a time-consuming operation (e.g., complex calculation)
            await Task.Delay(2000); // Delay for 2 seconds

            var result = a + b;
            return result;
        }

        private void DebugParams(int a, int b)
        {
            Debug.Log("Params: " + a + " " + b);
        }

        private void Add(int a, int b)
        {
            Debug.Log("Addition: "+(a+b));
        }
    
        private void Sub(int a, int b)
        {
            Debug.Log("Subtraction: " +(a-b));
        }
        private void Mul(int a, int b)
        {
            Debug.Log("Multiplication: " +(a*b));
        }
        private void Div(int a, int b)
        {
            Debug.Log("Division: " +(a/b));
        }

        #endregion
    }
}
