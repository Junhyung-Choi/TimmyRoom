using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NantaInstrumentManager : MonoBehaviour
{
    /// <summary>
    /// 씬 진행에 사용되는 모든 악기들의 집합.
    /// </summary>
    public AbstractNantaInstrument[] Instruments;
    /// <summary>
    /// 악기 교체에 사용되는 코루틴의 리스트.
    /// </summary>
    private List<IEnumerator> changeRoutines = new List<IEnumerator>();
    /// <summary>
    /// 초기 설정을 위한 함수.
    /// </summary>
    public void Initialize()
    {
        foreach(var instrument in Instruments)
        {
            instrument.Initialize();
            instrument.gameObject.SetActive(false);
        }
    }
    /// <summary>
    /// 악기를 교체하는 함수.
    /// </summary>
    public void ChangeInstrument(float time, int instrumentIndex)
    {
        IEnumerator routine = ChangeRoutine(time, instrumentIndex);
        changeRoutines.Add(routine);
        StartCoroutine(routine);
    }
    /// <summary>
    /// 악기를 교체하는 코루틴.
    /// </summary>
    IEnumerator ChangeRoutine(float time, int instrumentIndex)
    {
        yield return new WaitForSeconds(time);
        foreach(var instrument in Instruments)
        {
            instrument.gameObject.SetActive(false);
        }
        Instruments[instrumentIndex].gameObject.SetActive(true);
    }
    /// <summary>
    /// 씬 시작 상태로 되돌리는 함수.
    /// </summary>
    public void ResetAll()
    {
        foreach(var routine in changeRoutines)
        {
            StopCoroutine(routine);
        }
        changeRoutines.Clear();

        foreach(var instrument in Instruments)
        {
            instrument.gameObject.SetActive(false);
        }
    }
}