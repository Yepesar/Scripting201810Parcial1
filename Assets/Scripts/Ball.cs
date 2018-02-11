using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public Rigidbody Rigidbody
    {
        get { return rigidbody; }
    }

    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.down * 5F, ForceMode.Impulse);
        }
    }
}