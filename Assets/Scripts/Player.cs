using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 5.0f;

    private Animator animator;

    private readonly int animKeyRun = Animator.StringToHash("run"); // animator key id, string 매개변수 보다 빠름
    private readonly int animKeyIdle = Animator.StringToHash("idle");

    enum PlayerState { Idle, Run }

    private PlayerState state; // 내부 클래스에서만 정의 가능한 멤버 변수, 상태를 정의하기 위함임. 프로퍼티 정의 위함 X.

    private PlayerState State // 프로퍼티 정의를 위한 State
    {
        get => state;

        // 프로퍼티 set : 값이 할당된다면 실행됨
        set
        {
            state = value; // 값을 넣기 위한 작업

            // FSM 패턴으로 플레이어의 상태가 변경됨에 따라 애니메이션 변경
            switch (state) // 스위치 대상 state
            {
                case PlayerState.Idle:
                    animator.SetTrigger(animKeyIdle);
                    break;
                case PlayerState.Run:
                    animator.SetTrigger(animKeyRun);
                    break;
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) // 좌측 이동
        {
            Vector3 currScale = transform.localScale;
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            if (State != PlayerState.Run)
                State = PlayerState.Run;
            transform.localScale = new Vector3(-Mathf.Abs(currScale.x), currScale.y, currScale.z);
        }
        else if (Input.GetKey(KeyCode.D)) // 우측 이동
        {
            Vector3 currScale = transform.localScale;
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
            if (State != PlayerState.Run)
                State = PlayerState.Run;
            transform.localScale = new Vector3(Mathf.Abs(currScale.x), currScale.y, currScale.z);
        }
        else if (!Input.anyKey)
        {
            if (State != PlayerState.Idle)
            {
                State = PlayerState.Idle;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NoticeWall"))
        {
            GameManager.instance.ASKUIActive();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NoticeWall"))
        {
            GameManager.instance.ASKUIDelete();
        }
    }
}
