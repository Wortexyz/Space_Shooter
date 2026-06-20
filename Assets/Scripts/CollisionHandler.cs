using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject PlayerDestroyEffect ;
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
        }
       
    }
}
