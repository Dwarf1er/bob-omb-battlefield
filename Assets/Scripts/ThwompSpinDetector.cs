using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompSpinDetector : MonoBehaviour
{
    [SerializeField] private Transform thwompTransform;

    private Transform playerTransform;
    private float originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Mario").GetComponent<Transform>();
        originalRotation = thwompTransform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerTransform.position.z > thwompTransform.position.z)
            {
                thwompTransform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, originalRotation, transform.rotation.z));
            }

            if (playerTransform.position.z < thwompTransform.position.z)
            {
                thwompTransform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, originalRotation + 180, transform.rotation.z));
            }          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        thwompTransform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, originalRotation, transform.rotation.z));
    }
}
