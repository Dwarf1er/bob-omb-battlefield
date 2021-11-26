using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] public AudioSource jumpSound;
    [SerializeField] private Camera playerCamera;
    [SerializeField] public static float playerSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 5f;
    [SerializeField] private Vector3 playerCameraOffset = new Vector3(0, 0, -5f);
    [SerializeField] float playerCameraRotationCap = 70f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField, Min(0)] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField, Min(0)] private float jumpHeight = 2f;
    [SerializeField] public Animator animator;

    private Vector3 playerVelocity;
    private Vector3 playerRotation;
    private float playerCameraRotation;
    private float liveCameraRotation = 0f;
    private float playerHeight;
    private Vector3 gravitationalForce;
    private bool isGrounded;
    private bool isRunning;
    private bool jumpMomentumCheck;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerHeight = GetComponent<CharacterController>().height;
    }

    private void Update()
    {
        playerCameraOffset = new Vector3(0, 0, -5f);

        CalculatePlayerVelocity();
        CalculatePlayerRotation();
        CalculatePlayerCameraRotation();
        CalculatePlayerCameraOffset();

        ApplyPlayerVelocity();
        ApplyPlayerRotation();
        ApplyCameraRotation();
        ApplyCameraOffset();

        animator.SetBool("Jump", !isGrounded);
        animator.SetBool("Run", isRunning);
    }

    private void CalculatePlayerVelocity()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 forward = Vector3.ProjectOnPlane(playerCamera.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(playerCamera.transform.right, Vector3.up).normalized;

        Vector3 finalMovement = right * horizontal + forward * vertical;

        playerVelocity = finalMovement;
    }

    private void CalculatePlayerRotation()
    {
        float rotationY = Input.GetAxisRaw("Mouse X");
        Vector3 finalRotation = new Vector3(0, rotationY, 0) * mouseSensitivity;

        playerRotation = finalRotation;
    }

    private void CalculatePlayerCameraRotation()
    {
        float rotationX = Input.GetAxisRaw("Mouse Y");
        float finalCameraRotation = rotationX * mouseSensitivity;

        playerCameraRotation = finalCameraRotation;
    }

    private void CalculatePlayerCameraOffset()
    {
        Vector3 finalCameraOffset = playerCameraOffset;
        Vector3 raycastOrigin = gameObject.transform.position + (Vector3.up * playerHeight) + playerCameraOffset.z * playerCamera.transform.TransformDirection(Vector3.forward);
        Vector3 raycastDirection = playerCamera.transform.TransformDirection(Vector3.forward);
        float raycastRange = 5f;
        int raycastMask = LayerMask.GetMask("Player", "Environment");

        RaycastHit raycastHit;

        if (Physics.Raycast(raycastOrigin, raycastDirection, out raycastHit, raycastRange, raycastMask))
        {
            if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Environment"))
            {
                Debug.DrawRay(raycastOrigin, raycastDirection * raycastHit.distance, Color.red);
                float translateFactor = (raycastHit.point - raycastOrigin).magnitude / playerCameraOffset.magnitude;
                finalCameraOffset *= (0.9f - translateFactor);
            }

            if (raycastHit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Debug.DrawRay(raycastOrigin, raycastDirection * raycastHit.distance, Color.blue);
            }
        }

        playerCameraOffset = finalCameraOffset;
    }

    private void ApplyPlayerVelocity()
    {
        IsGrounded();
        IsRunning();

        if (Input.GetButton("Jump") && isGrounded)
        {
            gravitationalForce.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
            jumpSound.Play();
        }

        characterController.Move((playerVelocity * playerSpeed * Time.deltaTime) + (gravitationalForce * Time.deltaTime));
    }

    private void ApplyPlayerRotation()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(playerRotation);
    }

    private void ApplyCameraRotation()
    {
        liveCameraRotation -= playerCameraRotation;
        liveCameraRotation = Mathf.Clamp(liveCameraRotation, -playerCameraRotationCap, playerCameraRotationCap);
        playerCamera.transform.localEulerAngles = new Vector3(liveCameraRotation, 0f, 0f);
    }

    private void ApplyCameraOffset()
    {
        playerCamera.transform.localPosition = Vector3.up * playerHeight;
        playerCamera.transform.Translate(playerCameraOffset);
    }

    private void IsGrounded()
    {
        isGrounded = false;

        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, whatIsGround);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            if (hitColliders[i].gameObject == this.gameObject)
                continue;

            if (!hitColliders[i].isTrigger)
            {
                isGrounded = true;
                break;
            }
        }

        jumpMomentumCheck = jumpMomentumCheck && Input.GetButton("Jump") && !isGrounded;

        if (isGrounded)
        {
            gravitationalForce.y = gravity * Time.deltaTime;
            jumpMomentumCheck = true;
        }
        else
        {
            if (!jumpMomentumCheck && gravitationalForce.y > 0)
                gravitationalForce.y = 0;
            else
            {
                gravitationalForce.y += gravity * Time.deltaTime;
            }
        }
    }

    public void IsRunning()
    {
        if (playerVelocity != Vector3.zero && isGrounded)
            isRunning = true;

        else
            isRunning = false;
    }
}
