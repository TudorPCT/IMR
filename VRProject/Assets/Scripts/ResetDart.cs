using UnityEngine;

public class ResetDart : MonoBehaviour
{
    private Vector3 _initialPosition;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _initialPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Ground") return;
        transform.position = _initialPosition;
        _rigidbody.velocity = new Vector3(0, 0, 0);
    }
}