using System;
using System.Collections;
using UnityEngine;

public enum MoveDisableGroundType
{
    Bridge,
    Fence,
    Incline,
    Decline,
    Count
}

public class PlayerMove : MonoBehaviour
{
    public sfxPlayer soundManager;
    [SerializeField]
    private float laneDistance = 1f;

    [SerializeField]
    private float jumpForce = 5f;
    private float moveSpeed = 2f;

    private int currentLane = 1;
    private bool isjumping = false;
    private Rigidbody playerRb;

    private Vector3 targetPosition;
    private bool isMoving = false;

    float totalTravelDistance = 0f;

    public event Action OnJump;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        OnJump += Jump;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveLane(1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isjumping)
        {
            OnJump?.Invoke();
        }
    }

    void MoveLane(int direction)
    {
        if (isjumping || isMoving || !CheckCanMoveGround()) return;

        int targetLane = currentLane + direction;
        if (targetLane < 0 || targetLane > 2)
        {
            return;
        }

        soundManager.PlaySFXSound(sfxSoundType.SideStep);
        currentLane = targetLane;
        targetPosition = transform.position;
        targetPosition.x = (currentLane - 1) * laneDistance;

        // 양수라면 1, 음수라면 -1 (현재 위치 x좌표가 이동할 위치 x 좌표보다 크다 = 왼쪽으로 이동한다.)
        StartCoroutine(ApplyMove(Mathf.Sign(transform.position.x - targetPosition.x)));
    }
    void Jump()
    {
        if (!isjumping)
        {
            soundManager.PlaySFXSound(sfxSoundType.Jump);
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isjumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }

    IEnumerator ApplyMove(float isLeft)
    {
        isMoving = true;

        while (totalTravelDistance < laneDistance)
        {

            transform.position += new Vector3(-laneDistance * isLeft * Time.deltaTime, 0, 0) * moveSpeed;

            totalTravelDistance += laneDistance * Time.deltaTime * moveSpeed;

            yield return null;
        }

        totalTravelDistance = 0f;

        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        isMoving = false;
    }

    bool CheckCanMoveGround()
    {
        Ray downRay = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // 아래의 발판이 이동 불가능한 발판일 때
        if (Physics.Raycast(downRay, out hit))
        {
            for (int i = 0; i < (int)MoveDisableGroundType.Count; i++)
            {
                if (hit.collider.name.Contains(Enum.GetName(typeof(MoveDisableGroundType), i)))
                {
                    return false;
                }
            }
        }

        // Ray의 시작점이 아래에 있어 살짝 올려줌.
        Vector3 sideVector = new Vector3(0, 1, 0);
        Ray sideRay = new Ray(transform.position + sideVector, (transform.position.x < 0 ? Vector3.right : Vector3.left) * 5);
        //옆의 발판이 이동 불가능한 발판일 때
        if (Physics.Raycast(sideRay, out hit))
        {
            for (int i = 0; i < (int)MoveDisableGroundType.Count; i++)
            {
                if (hit.collider.name.Contains(Enum.GetName(typeof(MoveDisableGroundType), i)))
                {
                    return false;
                }
            }
        }
        return true;
    }
}
