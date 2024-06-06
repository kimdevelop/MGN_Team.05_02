using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI clearCountText; // TextMeshProUGUI 컴포넌트 참조

    private void Start()
    {
        // 초기 클리어 카운트 값을 0으로 설정
        UpdateClearCountText(0);
    }

    public void UpdateClearCountText(int count)
    {
        if (clearCountText != null)
        {
            clearCountText.text = count.ToString();
        }
    }
}
