using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int _score;

    void Start()
    {
        _score = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Dart") return;
        _score++;
        Debug.Log("Score: " + _score);
    }
}