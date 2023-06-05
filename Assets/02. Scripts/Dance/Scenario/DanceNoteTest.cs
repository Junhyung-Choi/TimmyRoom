using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DanceNoteTest : MonoBehaviour, IScenario
{
    /// <summary>
    /// ������ ǥ���ϴ� �ؽ�Ʈ.
    /// </summary>
    [SerializeField] protected TextMeshProUGUI notifyText;
    /// <summary>
    /// ���� Ƚ���� ǥ���ϴ� �ؽ�Ʈ.
    /// </summary>
    [SerializeField] protected TextMeshProUGUI countText;

    /// <summary>
    /// ä�� ������ ���ִ� json ����.
    /// </summary>
    [SerializeField] protected TextAsset jsonFile;
    /// <summary>
    /// ä���� ���� ����� Ŭ��.
    /// </summary>
    [SerializeField] protected AudioClip audioClip;
    /// <summary>
    /// ���� �ó����� ��ȣ.
    /// </summary>
    [SerializeField] protected int nextScenario = 4;
    protected IEnumerator barCoroutine;
    /// <summary>
    /// Ŭ��� ���� ���� ���� Ƚ��.
    /// </summary>
    protected int clear = 8;

    /// <summary>
    /// ���� ������ ������ ���� Ƚ�� ī��Ʈ�� ���ҽ�Ŵ.
    /// </summary>
    public virtual void SetCount()
    {
        countText.text = (--clear).ToString();
        if (clear < 0)
        {
            clear = 0;
            countText.text = clear.ToString();
        }
    }

    /// <summary>
    /// ä���� ������ ����ϴ� �Լ�.
    /// </summary>
    public void StartBar()
    {
        countText.text = clear.ToString();
        barCoroutine = BarCoroutine();
        StartCoroutine(barCoroutine);
    }

    /// <summary>
    /// ���� ����� ���� ����Ǵ� �ڷ�ƾ.
    /// </summary>
    protected IEnumerator BarCoroutine()
    {
        do
        {
            GameChart chart = DanceScenarioManager.instance.PlayChart(jsonFile.text, audioClip);
            yield return new WaitForSeconds(chart.SongLength);
            StartCoroutine(MusicCoroutine());
        } while (clear > 0);
    }

    /// <summary>
    /// ä�� ����� ���� ����Ǵ� �ڷ�ƾ.
    /// </summary>
    protected virtual IEnumerator MusicCoroutine()
    {
        yield return new WaitForSeconds(DanceScenarioManager.instance.GetWaitTime());
        if (clear <= 0)
        {
            StopCoroutine(barCoroutine);
            DanceScenarioManager.instance.ResetAll();
            DanceScenarioManager.instance.SetScenario(nextScenario);
        }
    }

    /// <summary>
    /// �ش� �ν�Ʈ���ǿ��� �߻��ϴ� �׼ǵ��� ����Ʈ�� ��ȯ�Ѵ�.
    /// </summary>
    /// <returns>�ν�Ʈ���ǿ��� �߻��ϴ� �׼ǵ��� ����Ʈ</returns>
    public virtual Dictionary<int, UnityAction> GetActions()
    {
        return new Dictionary<int, UnityAction>() { { 0, SetCount }, { 2, StartBar } };
    }
}
