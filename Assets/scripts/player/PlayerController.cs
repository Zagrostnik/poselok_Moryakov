
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float horizontalLimit = 4.8f;

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");

        Vector3 movement =
            Vector3.right * input * moveSpeed * Time.deltaTime;

        transform.position += movement;

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(
            position.x,
            -horizontalLimit,
            horizontalLimit
        );

        transform.position = position;
    }
}
