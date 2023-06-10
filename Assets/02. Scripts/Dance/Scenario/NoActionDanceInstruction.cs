using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoActionDanceInstruction : MonoBehaviour, IScenario
{
    [SerializeField] DanceChartTest danceChart;
    /// <summary>
    /// �ش� �ν�Ʈ���ǿ��� �߻��ϴ� �׼ǵ��� ����Ʈ�� ��ȯ�Ѵ�.
    /// </summary>
    /// <returns>�ν�Ʈ���ǿ��� �߻��ϴ� �׼ǵ��� ����Ʈ</returns>
    public Dictionary<int, UnityAction> GetActions()
    {
        return new Dictionary<int, UnityAction>();
    }

    /// <summary>
    /// ���� �������� ä���� �����Ѵ�.
    /// </summary>
    /// <param name="jsonFile">ä��.</param>
    public void SetJSON(TextAsset jsonFile)
    {
        danceChart.jsonFile = jsonFile;
    }
    /// <summary>
    /// ���� �������� ������ �����Ѵ�.
    /// </summary>
    /// <param name="audioClip">����.</param>
    public void SetSong(AudioClip audioClip)
    {
        danceChart.audioClip = audioClip;
    }
}
