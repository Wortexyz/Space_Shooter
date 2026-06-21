using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject PlayerDestroyEffect ;

    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager=FindFirstObjectByType<GameSceneManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (PlayerDestroyEffect != null)
            {
                Instantiate(PlayerDestroyEffect, transform.position, Quaternion.identity);
            }

            Debug.Log($"Hit : {other.name}");

            Destroy(gameObject);
            gameSceneManager.ReloadScene();

        }
       
    }
}
