using UnityEngine;
using UnityEngine.AI;

public class BobombController : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;

    private bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !hasHit)
        {
            hasHit = true;
            other.GetComponent<PlayerStats>().PlayerHit();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
