using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ark;
using TMPro;
using UnityEngine.UI;
using UI;

public class WorkManager : MonoBehaviour
{
    //������ ���������� NPC �� ������. ��� ������ ������ ��������� ������. ���� ������ - ��������� ������������ � ��������������� ������ ��������� (� �������� �������), �� ����� �������� ���������� ����� �����������
    
    public Bay Bay;
    public TextMeshProUGUI HumanInBay;
    public bool IsAssistant;
    public Button PlusButton;
    public Button MinusButton;
    private UIBridge bridge;
    public void Setup(UIBridge uib)
    {
        bridge = uib;
    }

    private void Start()
    {
        UpdateText();
    }
    public void UpdateText()
    {
        if (!IsAssistant)
        {
            if (Bay != null)
            {
                HumanInBay.text = Bay.WorkersInBay.Count.ToString() + $" /{Bay.WorkZone.Count}";

                if (Bay.WorkersInBay.Count >= Bay.WorkZone.Count)
                {
                    MinusButton.gameObject.SetActive(true);
                    PlusButton.gameObject.SetActive(false);
                }
                else if (Bay.WorkersInBay.Count <= 0)
                {
                    MinusButton.gameObject.SetActive(false);
                    PlusButton.gameObject.SetActive(true);
                }
                else
                {
                    MinusButton.gameObject.SetActive(true);
                    PlusButton.gameObject.SetActive(true);
                }
                if (GameManager.Instance.FreeAssistant.Count == 0)
                {
                    PlusButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            HumanInBay.text = GameManager.Instance.FreeAssistant.Count + $" /{GameManager.Instance.AllCrew.Count}";
        }
    }
    public void AddWorkerInBay()
    {
        Debug.Log("Add");
        if(GameManager.Instance.FreeAssistant.Count > 0 && Bay.WorkersInBay.Count < Bay.WorkZone.Count)
        {
            Bay.WorkersInBay.Add(GameManager.Instance.FreeAssistant[0]);

            Bay.WorkersInBay[Bay.WorkersInBay.Count - 1].NextActions();
            GameManager.Instance.FreeAssistant.RemoveAt(0);
        }
        bridge.UpdateParams();
        UpdateText();
    }
    public void RemoveWorker()
    {
        Debug.Log("Remove");
        if (Bay.WorkersInBay.Count > 0)
        {  
            GameManager.Instance.FreeAssistant.Add(Bay.WorkersInBay[0]);
            Bay.WorkersInBay[0].NextActions();
            Bay.WorkersInBay.RemoveAt(0);
        }
        bridge.UpdateParams();
        UpdateText();
    }
}
