using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Text score;

    private int score_points = 0;
    private int max_bricks;
    private int bricks_alive;
    private GameObject[] bricks;

    public int Score_points
    {
        get { return score_points; }
        set { score_points = value; }
    }

    // Use this for initialization
    void Start ()
    {
        bricks_alive = transform.childCount;
        bricks = new GameObject[bricks_alive];
        Asign();
	}
	
	// Update is called once per frame
	void Update ()
    {
        bricks_alive = transform.childCount;

        Validate();

        if (bricks_alive <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("EL JUGADOR GANA!");
        }

        score.text = "Score: " + Score_points;
	}

    private void Asign()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Validate()
    {
        for(int i=0; i<bricks.Length;i++)
        {
            if(bricks[i] == null)
            {
                Score_points += 20;
                bricks[i] = new GameObject();
            }
        }
    }
}
