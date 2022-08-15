using System.Collections;
using UnityEngine;

public class SpaceshipOnCollision : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffectChild;
    [SerializeField] GameObject FlameEffectChild;
    [SerializeField] GameObject PointWall;
    Renderer _Renderer;
    Collider SpaceshipCollider;
    
    
    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
        SpaceshipCollider = GetComponent<Collider>();
    }
    //lose on collision with asteroid
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AsteroidBehaviour>())
        {
            StartCoroutine(EndGame());
        }
    }
    
    IEnumerator EndGame()
    {
        AudioManager.Instance.PlayOnCollision();
        SpaceshipCollider.enabled = false;
        PointWall.SetActive(false);
        FlameEffectChild.SetActive(false);
        _Renderer.enabled = false;
        ExplosionEffectChild.transform.parent = null;
        ExplosionEffectChild.SetActive(true);
        yield return new WaitForSeconds(ExplosionEffectChild.GetComponent<ParticleSystem>().main.duration);
        SceneMover.MoveScene();
    }
}
