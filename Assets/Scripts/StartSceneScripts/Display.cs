using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // �� ������ ���� �߰�

public class Display : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private string[] messages = new string[]
    {
        "�����繫�ҿ��� F�� ���ֹ� �����в� ��� �ȳ� ���� �帳�ϴ�.",
        "���� F�� 404ȣ���� ȭ�簡 �߻��Ͽ����ϴ�.",
        "���ǽÿ��� �߰� ��� ������ ���Ͽ� �� ���� �ֹ��� ������긦 ����ֽð�,",
        "����� �̿��Ͽ� �ǹ� �ܺη� ħ���ϰ� �����Ͻñ� �ٶ��ϴ�.",
        "�ٽ� �ѹ� F�� ���ֹ� �����в� ��� �ȳ����� �帳�ϴ�.",
        "���� F�� 404ȣ���� ȭ�簡 �߻��Ͽ����ϴ�.",
        "���ǽÿ��� �߰� ��� ������ ���Ͽ� �� ���� �ֹ��� ������긦 ����ֽð�,",
        "����� �̿��Ͽ� �ǹ� �ܺη� ħ���ϰ� �����Ͻñ� �ٶ��ϴ�.",
        "�̻� �����繫�ҿ��� �ȳ� ���� ��Ƚ��ϴ�."
    };

    private float[] timings = new float[]
    {
        1.5f,   // ù ��° �޽��� ���� �ð� (��)
        6.2f,   // �� ��° �޽��� ���� �ð� (��)
        9.3f,  // �� ��° �޽��� ���� �ð� (��)
        13.5f,  // �� ��° �޽��� ���� �ð� (��)
        17.5f,  // �ټ� ��° �޽��� ���� �ð� (��)
        21.2f,  // ���� ��° �޽��� ���� �ð� (��)
        25.0f,  // �ϰ� ��° �޽��� ���� �ð� (��)
        29.8f,  // ���� ��° �޽��� ���� �ð� (��)
        34.0f   // ��ȩ ��° �޽��� ���� �ð� (��)
    };

    void Start()
    {
        audioSource.clip = audioClip;
        StartCoroutine(PlayAudioAndDisplayText());
    }

    IEnumerator PlayAudioAndDisplayText()
    {
        audioSource.Play();
        for (int i = 0; i < messages.Length; i++)
        {
            textMeshPro.text = messages[i];
            yield return new WaitForSeconds((i == messages.Length - 1) ? 3.0f : timings[i + 1] - timings[i]);
        }
        textMeshPro.text = ""; // ������ �޽��� ����(���� ���)
        SceneManager.LoadScene("SampleScene"); // �� ��ȯ
    }
}
