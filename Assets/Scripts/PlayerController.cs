using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[Range(0F, 1F)]
    [SerializeField]
    private float movementSpeed = 0.5F;

    private new Rigidbody rigidbody;

    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (rigidbody == null)
        {
            enabled = false;
        }

        float axisVal = Input.GetAxis("Horizontal");
        Vector3 currentPosition = gameObject.transform.position;

        if (axisVal < 0F)
        {
            //rigidbody.MovePosition(Vector3.right * movementSpeed * Time.deltaTime);
            //rigidbody.AddForce(Vector3.left * movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
            gameObject.transform.position = new Vector3(currentPosition.x - movementSpeed + Time.deltaTime, currentPosition.y, currentPosition.z);
        }
        else if (axisVal > 0F)
        {
            //rigidbody.AddForce(Vector3.right * movementSpeed * Time.deltaTime, ForceMode.VelocityChange);
            //rigidbody.MovePosition(Vector3.right * movementSpeed * Time.deltaTime);
            gameObject.transform.position = new Vector3(currentPosition.x + movementSpeed + Time.deltaTime, currentPosition.y, currentPosition.z);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}