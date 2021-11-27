using UnityEngine;
using UnityEngine.AI;

public class BobombPlayerDetector : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform player;

    private bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChasing)
            enemy.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isChasing = false;
        }
    }
}
