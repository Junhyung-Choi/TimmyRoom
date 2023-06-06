using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DanceTriggerArea : MonoBehaviour
{
    // ���� ������ Ÿ�� ��ȣ
    public int AreaType;
    /// <summary>
    /// �ش� ������Ʈ�� Ʈ���ſ� �������� �� �߻��ϴ� �׼�.
    /// </summary>
    public UnityAction enterAction;
    /// <summary>
    /// �ش� ������Ʈ�� Ʈ���Ÿ� ������ �� �߻��ϴ� �׼�.
    /// </summary>
    public UnityAction exitAction;
    /// <summary>
    /// ���׸��� ��ü�� ���� ���� ���� ������Ʈ ��ü�� ����.
    /// </summary>
    public GameObject areaObject;

    private void Start()
    {
        areaObject = gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        enterAction.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        exitAction.Invoke();
    }
}
