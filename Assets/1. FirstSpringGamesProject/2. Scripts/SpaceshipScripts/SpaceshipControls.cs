using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SpaceshipControls : MonoBehaviour
{
    [SerializeField] Transform LeftPosition, RightPosition;
    [SerializeField] float Speed = 10;
    [SerializeField] float RotationSpeed = 200;
    Renderer _Renderer;

    IEnumerator Start()
    {
        _Renderer = GetComponent<Renderer>();

        AudioManager.Instance.PlayOnStart();
        while (_Renderer.enabled)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AudioManager.Instance.PlayOnStrafe();
                transform.position = (Vector3.MoveTowards(transform.position, Direction(LeftPosition), Time.deltaTime * Speed));
                transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 30)), RotationSpeed * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                AudioManager.Instance.PlayOnStrafe();
                transform.position = (Vector3.MoveTowards(transform.position, Direction(RightPosition), Time.deltaTime * Speed));
                transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -30)), RotationSpeed * Time.deltaTime));
            }
            else
            {
                AudioManager.Instance.CanPlayStrafeSound = true;
                transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(Vector3.zero), RotationSpeed * Time.deltaTime));
            }
            
            yield return null;
        }
    }
    Vector3 Direction(Transform direction)
    {
        return new Vector3(direction.position.x, transform.position.y, transform.position.z);
    }


}
