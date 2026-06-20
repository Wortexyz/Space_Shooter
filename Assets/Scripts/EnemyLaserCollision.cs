using UnityEngine;

public class EnemyLaserCollision : MonoBehaviour
{

    [SerializeField] GameObject DestroyEffect;

    [SerializeField] int HitCount =5 ,PointByEnemy =10;
    ScoreBoard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        HitCount--;
        if (HitCount <= 0)
        {
            scoreboard.IncreaseScore(PointByEnemy);
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
