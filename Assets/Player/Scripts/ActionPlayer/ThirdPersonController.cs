using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class ThirdPersonController : MonoBehaviour
{
    //input Player
    private InputPlayer playerActionsAsset;
    private InputAction move;

    //di chuyển và lực nhảy của Player
    private Rigidbody rb;
    [SerializeField]
    private float movementForce = 1f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float maxSpeed = 5f;
    private Vector3 forceDirection = Vector3.zero;

    //main camera
    [SerializeField]
    private Camera playerCamera;

    //animator player
    private Animator animator;

    //ràng buộc tấn công và di chuyển
    private bool isMoving = false;

    [SerializeField] private ParticleSystem particleSword01;
    [SerializeField] private ParticleSystem particleSword02;
    [SerializeField] private ParticleSystem particleSword03;
    [SerializeField] private GameObject positionSlashSword01;
    [SerializeField] private GameObject positionSlashSword02;
    [SerializeField] private GameObject positionSlashSword03;


    [SerializeField] private bool isRotaion = false;
    [SerializeField] private float speedRotation = 500f;
    [SerializeField] private float timeRotation = 4f;
    private float rotaionPlayer;


    //kiểm tra player có cầm kiếm hay không
    public GameObject sword;
    [SerializeField] private GameObject sword2;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActionsAsset = new InputPlayer();
        animator = this.GetComponent<Animator>();
    }

    //bật tắt trạng thái input
    private void OnEnable()
    {
        playerActionsAsset.Player.Jump.started += DoJump;
        playerActionsAsset.Player.Attack.started += DoAttack;
        playerActionsAsset.Player.SkillAttack01.started += DoSkill01;
        move = playerActionsAsset.Player.Move;
        playerActionsAsset.Player.Enable();
    }
    private void OnDisable()
    {
        playerActionsAsset.Player.Jump.started -= DoJump;
        playerActionsAsset.Player.Attack.started -= DoAttack;
        playerActionsAsset.Player.SkillAttack01.started -= DoSkill01;
        playerActionsAsset.Player.Disable();
    }


    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void DoSkill01(InputAction.CallbackContext context)
    {
        if (!isRotaion)
        {
            isRotaion = true;
            StartRotaion();
        }
        if (isRotaion)
        {
            RotatePlayer();
        }
    }

    private void StartRotaion()
    {
        isRotaion = true;
        Invoke("StopRotaion", timeRotation);
    }
    private void StopRotaion()
    {
        isRotaion = false;
    }
    private void RotatePlayer()
    {
        rotaionPlayer = speedRotation * Time.deltaTime;
        transform.Rotate(Vector3.up, rotaionPlayer);
    }

    //move player
    private void MovementPlayer()
    {

        //kiểm tra di chuyển của player
        isMoving = move.ReadValue<Vector2>().sqrMagnitude > 0.1f;

        //di chuyển và theo hướng của cam 
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        //fix thêm lực để người chơi rơi xuống khi không ở mặt đất
        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }
    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            animator.SetTrigger("jump");
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }

    private void DoAttack(InputAction.CallbackContext context)
    {
        if (!isMoving && IsGrounded() && sword.activeSelf || sword2.activeSelf)  // Kiểm tra không đang di chuyển và đang ở trên mặt đất
        {
            animator.SetTrigger("attack");
            StartCoroutine(MovingCooldown()); // Gọi hàm xử lý cooldown tấn công
        }
    }
    private IEnumerator MovingCooldown()
    {
        isMoving = true;
        // Đợi một khoảng thời gian cooldown trước khi có thể di chuyển tiếp
        yield return new WaitForSeconds(2);
        isMoving = false;
    }

    public void Attacking01()
    {
        if (sword.activeSelf)
        {
            ParticleSystem newParticle = Instantiate(particleSword01, positionSlashSword01.transform.position, positionSlashSword01.transform.rotation);
            float destroyDelay = 0.5f;
            StartCoroutine(DestroyParticle(newParticle, destroyDelay));
        }
    }
    public void Attacking02()
    {
        if (sword.activeSelf)
        {
            ParticleSystem newParticle = Instantiate(particleSword02, positionSlashSword02.transform.position, positionSlashSword02.transform.rotation);
            float destroyDelay = 0.5f;
            StartCoroutine(DestroyParticle(newParticle, destroyDelay));
        }
    }
    public void Attacking03()
    {
        if (sword.activeSelf)
        {
            ParticleSystem newParticle = Instantiate(particleSword03, positionSlashSword03.transform.position, positionSlashSword03.transform.rotation);
            float destroyDelay = 0.5f;
            StartCoroutine(DestroyParticle(newParticle, destroyDelay));
        }
    }
    private IEnumerator DestroyParticle(ParticleSystem particle, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(particle.gameObject);
    }
}