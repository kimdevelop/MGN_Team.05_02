using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro를 사용하기 위해 추가

public class Ending : MonoBehaviour
{

   [SerializeField]
    private Button mainMenuButton; // 메인 메뉴로 돌아가는 버튼*/
    [SerializeField]
    private Button restartButton; // 리스타트 버튼

    private void Start()
    {
     
        // 메인 메뉴 버튼 클릭 이벤트 설정
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        // 리스타트 버튼 클릭 이벤트 설정
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
    }

    // 메인 메뉴 버튼 클릭 시 호출되는 메서드
   private void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("TitleScene"); // 메인 메뉴 씬으로 전환.
    }

    // 리스타트 버튼 클릭 시 호출되는 메서드
    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene"); // SampleScene으로 전환
    }
}
