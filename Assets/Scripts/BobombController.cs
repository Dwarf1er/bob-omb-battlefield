using UnityEngine;
using UnityEngine.AI;

public class BobombController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;
    [SerializeField] private ParticleSystem explosion;

    private bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasHit)
        {
            hasHit = true;
            // PlayerHeal() adds one coin to the picked up coins
            other.GetComponent<PlayerStats>().PlayerHit();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
