using System;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField] private GameObject leftController;
    private double _score;

    void Start()
    {
        _score = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Dart") return;
        var distance = Vector3.Distance(collision.gameObject.transform.position, leftController.transform.position);
        _score += Math.Round(distance);
        Debug.Log("Score: " + _score);
    }
}