using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceGhost : MonoBehaviour
{
    // �ʵ忡�� ����
    [SerializeField]
    private float floatSpeed = 4.0f;

    private GameObject player;
    private float floatRange = 0.7f; // (1.7 - 0.3) / 2
    private float baseY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        baseY = transform.position.y;
        StartCoroutine(FloatEffect());
    }

    void Update()
    {
        if (player != null)
        {
            // ������ �÷��̾ �����ϵ��� ����
            float step = floatSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    private IEnumerator FloatEffect()
    {
        while (true)
        {
            // y ��ǥ�� 0.3�� 1.7 �������� õõ�� �����ߴٰ� �����ϴ� �ݺ� ����(�յ� ���ٴϴ� ���)
            float newY = baseY + Mathf.Sin(Time.time) * floatRange;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.ResetClearCount();
            GameManager.instance.ResetPlayerPosition();
            GameManager.instance.DeactivateTracerAndActivateRandomPrefab();
        }
    }
}
