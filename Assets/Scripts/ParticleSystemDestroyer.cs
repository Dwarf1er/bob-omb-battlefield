using System.Collections;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForParticle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator WaitForParticle()
    {
        yield return new WaitUntil(() => particle.isEmitting == false);
        Destroy(gameObject);
    }
}
