using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DanceChartTest : DanceNoteTest
{
    /// <summary>
    /// ���� �ó������� �Ѿ�� ���� �ʿ��� ���߷�.
    /// </summary>
    [Range(0, 1)]
    [SerializeField] float clearRate = 0.6f;
    /// <summary>
    /// ���� �� �����ϴ� �ؽ�Ʈ ������.
    /// </summary>
    [SerializeField] List<string> failTexts;
    /// <summary>
    /// ���� Ƚ��.
    /// </summary>
    private int hitCount = 0;
    /// <summary>
    /// ���� Ƚ��.
    /// </summary>
    private int failCount = 0;

    public void Start()
    {
        countText.text = $"{hitCount}/{hitCount + failCount}";
    }

    /// <summary>
    /// ���� ������ ������ ���� Ƚ�� ī��Ʈ�� ������Ŵ.
    /// </summary>
    public override void SetCount()
    {
        hitCount++;
        countText.text = $"{hitCount}/{hitCount + failCount}";
    }

    protected override IEnumerator MusicCoroutine()
    {
        yield return new WaitForSeconds(DanceScenarioManager.instance.GetWaitTime());
        float hitRate = (float)hitCount / (hitCount + failCount);
        if (hitRate < clearRate && clear > 0)
        {
            notifyText.text = failTexts[failTexts.Count - (clear--)];
            hitCount = 0;
            failCount = 0;
            countText.text = $"{hitCount}/{hitCount + failCount}";
        }
        else
        {
            StopCoroutine(barCoroutine);
            DanceScenarioManager.instance.ResetAll();
            DanceScenarioManager.instance.SetScenario(nextScenario);
        }
    }

    /// <summary>
    /// ��Ʈ�� ������ �� ȣ��Ǵ� �Լ�.
    /// </summary>
    public void MissNote()
    {
        failCount++;
        countText.text = $"{hitCount}/{hitCount + failCount}";
    }

    public override Dictionary<int, UnityAction> GetActions()
    {
        return new Dictionary<int, UnityAction>() { { 0, SetCount }, { 1, MissNote }, { 2, StartBar } };
    }
}
