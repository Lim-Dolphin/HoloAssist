using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    #region SingleTon Pattern
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set this as the instance and ensure it persists across scenes
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public void LoadMainSceneCall()
    {
        StartCoroutine(LoadScene("Main")); //�񵿱��̹Ƿ� �ڷ�ƾ���� ȣ�� 
    }

    // Ÿ��Ʋ ������ ���� ������ �̵� 
    private IEnumerator LoadScene(string sceneName)
    {
        Debug.Log("���ӸŴ��� - �ε�� ���� ��  ");

        // �񵿱������� �� �ε�
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);


        // �� �ε��� �Ϸ�� ������ ���
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // �ٲ� ���� ���� ������ �����ϰ� �ʱ�ȭ����

    }

    // �� ����
    public void Quit()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

}
