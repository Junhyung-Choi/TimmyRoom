using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDanceArea : MonoBehaviour
{
    [SerializeField] protected DanceJudgingPoint Judge;

    /// <summary>
    /// ���� ������ �ʱ�ȭ�� ���� �Լ�.
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// ���� ������ ����ڿ� ���� ���ͷ��ǵǾ��� �� ȣ��Ǵ� �Լ�.
    /// </summary>
    public abstract void GetEntered(int type, GameObject areaObject);

    /// <summary>
    /// ����ڰ� ���� ������ ����� �� ȣ��Ǵ� �Լ�.
    /// </summary>
    public abstract void GetExited(int type, GameObject areaObject);
}
