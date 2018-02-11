using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Collider myCollider;
    private float distanceToCenter;

    [SerializeField]
    private float bounceForce = 1F;

    private void Start()
    {
        myCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            if (ball != null)
            {
                float xForceVal = 0;
                distanceToCenter = collision.contacts[0].point.x - myCollider.bounds.center.x;
                int compareValue = distanceToCenter.CompareTo(0F);

                if (compareValue > 0F)
                {
                    xForceVal = 1F;
                }
                else if (compareValue < 0F)
                {
                    xForceVal = -1F;
                }

                ball.Rigidbody.AddForce(new Vector3(xForceVal * bounceForce, 1, 0F), ForceMode.Impulse);
            }
        }
    }
}