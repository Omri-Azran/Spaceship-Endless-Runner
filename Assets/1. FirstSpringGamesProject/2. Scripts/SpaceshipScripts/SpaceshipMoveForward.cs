using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipMoveForward : MonoBehaviour
{
    float Speed = 1;

    private void FixedUpdate()
    {
        Speed = Mathf.Round(Time.timeSinceLevelLoad);
        transform.position = (Vector3.MoveTowards
                (transform.position, transform.position + Vector3.forward * Time.timeSinceLevelLoad, Time.fixedDeltaTime * Speed));
    }
}
