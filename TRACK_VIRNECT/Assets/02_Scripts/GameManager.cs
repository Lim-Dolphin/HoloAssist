using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    public TextMeshProUGUI debugText;
    
    public GameObject clepsydraPrefab;
    private Vector3 targetTransform;
    public TextMeshProUGUI infoText;

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

    // book target ã���� �� �ݹ� 
    public void Callback_StartBookTarget()
    {

        //targetTransform = GameObject.FindWithTag("TrackTarget").transform.position;
        targetTransform = GameObject.Find("Placeholder").transform.position;

        debugText.text = "Book Detected";
        debugText.color = Color.green;

        // target ��ġ�� �� ���� 
        Instantiate(clepsydraPrefab, targetTransform, Quaternion.identity);

        // �ȳ� UI ����
        infoText.enabled = true;

        // �ȳ� ���� ��� 


    }

    public void Callback_StopBookTarget()
    {
        debugText.text = "Searching...";
        debugText.color = Color.yellow;
    }

    // �� ����
    public void Quit()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }

}
