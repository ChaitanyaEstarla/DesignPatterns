using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private bool clicked = false;

    [SerializeField] private GameObject logo;

    private void Update()
    {
        if(clicked)
        {
            logo.SetActive(false);
            clicked = false;
        }
    }

    private void OnMouseDown()
    {
        clicked = true;
    }
}
