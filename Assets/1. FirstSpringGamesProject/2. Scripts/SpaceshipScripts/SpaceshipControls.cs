using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SpaceshipControls : MonoBehaviour
{
    [SerializeField] Transform LeftPosition, RightPosition;
    [SerializeField] float Speed = 10;
    [SerializeField] float RotationSpeed = 200;
    
    IEnumerator Start()
    {
        if (AudioManager.Instance)
            AudioManager.Instance.PlayOnStart();
        else
            Debug.Log("No Audio Manager in the scene. Please start game from Main Menu");
        while (true)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (AudioManager.Instance)
                    AudioManager.Instance.PlayOnStrafe();
                else
                    Debug.Log("No Audio Manager in the scene. Please start game from Main Menu");
                transform.position = (Vector3.MoveTowards(transform.position, Direction(LeftPosition), Time.deltaTime * Speed));
                transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 30)), RotationSpeed * Time.deltaTime));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (AudioManager.Instance)
                    AudioManager.Instance.PlayOnStrafe();
                else
                    Debug.Log("No Audio Manager in the scene. Please start game from Main Menu");
                transform.position = (Vector3.MoveTowards(transform.position, Direction(RightPosition), Time.deltaTime * Speed));
                transform.rotation = (Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -30)), RotationSpeed * Time.deltaTime));
            }
            else
            {
                if (AudioManager.Instance)
                    AudioManager.Instance.CanPlayStrafeSound = true;
                else
                    Debug.Log("No Audio Manager in the scene. Please start game from Main Menu");
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
