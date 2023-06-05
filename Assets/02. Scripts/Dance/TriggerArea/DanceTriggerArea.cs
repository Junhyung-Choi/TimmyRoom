using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DanceTriggerArea : MonoBehaviour
{
    // ���� ������ Ÿ�� ��ȣ
    public int AreaType;
    public UnityAction enterAction;
    public UnityAction exitAction;
    public GameObject areaObject;

    private void Start()
    {
        areaObject = this.gameObject;
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
