using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    [SerializeField]
    private Text lives;
    [SerializeField]
    private GameController g_controller;

    private int live_points = 3; 
    private new Rigidbody rigidbody;
    private Vector3 start_position;
    private bool turnOff_gravity = false;

    public Rigidbody Rigidbody
    {
        get { return rigidbody; }
    }

    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        start_position = transform.position;
        lives.text = "Lives: " + live_points;

        if (rigidbody != null)
        {
            rigidbody.AddForce(Vector3.down * 5F, ForceMode.Impulse);
        }
    }

    private void Update()
    {

        if (g_controller.Score_points == 100)
        {
            live_points += 1;
            g_controller.Score_points += 1;
            lives.text = "Lives: " + live_points;
            gameObject.GetComponent<Collider>().material.bounciness = 0.99f;

        }

        if (live_points<= 0)
        {
            Time.timeScale = 0;
        }

       if(turnOff_gravity)
        {
            rigidbody.useGravity = false; ;
        }

       if(Input.GetKeyDown(KeyCode.Space) && turnOff_gravity)
        {
            rigidbody.useGravity = true;
            turnOff_gravity = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;

        if(obj.tag == "Death")
        {
            live_points -= 1;
            lives.text = "Lives: " + live_points;
            transform.position = start_position;
            turnOff_gravity = true;
            rigidbody.velocity = Vector3.zero;
          
        }
    }
}