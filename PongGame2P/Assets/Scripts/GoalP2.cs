using UnityEngine;

public class GoalP2 : MonoBehaviour
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

        if (playerNumber == 2)
            gm.Player1Scores();
        else
            gm.Player2Scores();
    }
}


