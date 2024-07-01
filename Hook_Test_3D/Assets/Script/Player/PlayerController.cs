using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    [SerializeField]
    private bool groundedPlayer;

    private InputManager inputManager;
    private GameManager gameManager;
    private Transform cameraTransform;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField]
    private GameObject hookOBJ;
    [SerializeField]
    private GameObject spawnerHook;

    private bool canHook;
    public bool Hooking;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        gameManager = GameManager.Instance;
        cameraTransform = Camera.main.transform;
        canHook = true;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
            playerVelocity.y = 0f;

        if(!Hooking)
        {
            Vector2 movement = inputManager.GetPlayerMovement();
            Vector3 move = new Vector3(movement.x, 0f, movement.y);
            move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
            move.y = 0f;
            controller.Move(move * Time.deltaTime * playerSpeed);
        }

        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);

        if (canHook && inputManager.PlayerHookedThisFrame())
        {
            Hook();
            StartCoroutine(CooldownHook(1.5f));
        }


        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Hook()
    {
        var hook = Instantiate(hookOBJ, cameraTransform.position  + cameraTransform.forward, cameraTransform.rotation);
        hook.GetComponent<HookScript>().caster = spawnerHook.transform;
    }

    private IEnumerator CooldownHook(float time)
    {
        canHook = false;
        Hooking = true;
        yield return new WaitForSeconds(time);
        Hooking = false;
        canHook = true;
    }
}
