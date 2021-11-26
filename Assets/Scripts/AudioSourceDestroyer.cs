using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceDestroyer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForAudio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitForAudio()
    {
        yield return new WaitUntil(() => audioSource.isPlaying == false);
        Destroy(gameObject);
    }
}
