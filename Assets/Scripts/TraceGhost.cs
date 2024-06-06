using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceGhost : MonoBehaviour
{
    // 필드에서 수정
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
            // 유령이 플레이어를 추적하도록 설정
            float step = floatSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    private IEnumerator FloatEffect()
    {
        while (true)
        {
            // y 좌표를 0.3과 1.7 범위에서 천천히 증가했다가 감소하는 반복 동작(둥둥 떠다니는 모습)
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
