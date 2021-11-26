using System.Collections;
using UnityEngine;

public class ParticleSystemDestroyer : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForAudio()
    {
        yield return new WaitUntil(() => particle.isPlaying == false);
        Destroy(gameObject);
    }
}
