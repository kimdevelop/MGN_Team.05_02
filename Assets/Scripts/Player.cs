using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 5.0f;

    private Animator animator;

    private readonly int animKeyRun = Animator.StringToHash("run"); // animator key id, string �Ű����� ���� ����
    private readonly int animKeyIdle = Animator.StringToHash("idle");

    enum PlayerState { Idle, Run }

    private PlayerState state; // ���� Ŭ���������� ���� ������ ��� ����, ���¸� �����ϱ� ������. ������Ƽ ���� ���� X.

    private PlayerState State // ������Ƽ ���Ǹ� ���� State
    {
        get => state;

        // ������Ƽ set : ���� �Ҵ�ȴٸ� �����
        set
        {
            state = value; // ���� �ֱ� ���� �۾�

            // FSM �������� �÷��̾��� ���°� ����ʿ� ���� �ִϸ��̼� ����
            switch (state) // ����ġ ��� state
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
        if (Input.GetKey(KeyCode.A)) // ���� �̵�
        {
            Vector3 currScale = transform.localScale;
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            if (State != PlayerState.Run)
                State = PlayerState.Run;
            transform.localScale = new Vector3(-Mathf.Abs(currScale.x), currScale.y, currScale.z);
        }
        else if (Input.GetKey(KeyCode.D)) // ���� �̵�
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
