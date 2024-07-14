using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region SingleTon Pattern
    public static UIManager Instance { get; private set; }
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

    public string filePath; // �ؽ�Ʈ ������ ���
    public TextMeshProUGUI textUI; //  Text UI
    public TextMeshProUGUI videoUI; //  Video UI


    // ����� ������ ���� �����ϰ� �Ǿ�������, �ؽ�Ʈ �Ŵ����� ����� �̸� �����ϵ���.
    void ReadTextFile()
    {
        if (File.Exists(filePath))
        {
            string text = File.ReadAllText(filePath);
            textUI.text = text;
        }
        else
        {
            Debug.LogError("������ ã�� �� �����ϴ�: " + filePath);
        }
    }

    // ����� ������ ���� �����ϰ� �Ǿ�������, ���� �Ŵ����� ����� �̸� �����ϵ���.
    void ReadVideoFile()
    {

    }
}
