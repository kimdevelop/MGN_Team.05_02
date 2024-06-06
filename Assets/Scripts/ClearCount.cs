using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI clearCountText; // TextMeshProUGUI ������Ʈ ����

    private void Start()
    {
        // �ʱ� Ŭ���� ī��Ʈ ���� 0���� ����
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
