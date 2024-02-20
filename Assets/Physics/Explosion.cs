using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] Rigidbody2D rigidbody;

    private bool explode = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Invoke(nameof(ReduceGravity), 1);
    }

    private void Update()
    {
        if(explode) { return; }
        rigidbody.AddForce(transform.up * 5f);
    }

    private void ReduceGravity()
    {
        explode = true;
        rigidbody.gravityScale = 0.05f;
        CancelInvoke();
    }
}
