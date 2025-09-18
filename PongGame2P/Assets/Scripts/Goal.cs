using UnityEngine;

public class Goal : MonoBehaviour
{
    public int playerNumber; // set in Inspector: 1 = left goal (player 2 scored), 2 = right goal (player 1 scored)
    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        if (playerNumber == 1)
            gm.Player2Scores();
        else
            gm.Player1Scores();
    }
}


