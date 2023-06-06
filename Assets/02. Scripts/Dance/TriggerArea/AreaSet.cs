using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ���࿡ ���Ǵ� ��� �������� ����.
/// </summary>
public class AreaSet : AbstractDanceArea
{
    /// <summary>
    /// �� ���� ������ ���� ������ ��� �ִ� ����ü.
    /// </summary>
    public DanceTriggerArea[] TriggerAreas;

    /// <summary>
    /// �� ���� ������ Ȱ��ȭ ���θ� ��� �ִ� �迭.
    /// </summary>
    public bool[] isTriggered = { false, false, false, false, false, false };

    /// <summary>
    /// �ø� ����ũ ������ ���� �ſ� ������Ʈ.
    /// </summary>
    public ReflectionProbe mirror;

    /// <summary>
    /// �� ���� ������ ���� �����ϰų� ���ߴµ� ����ϴ� ���׸���.
    /// </summary>
    public Material blue;
    public Material origin;
    public Material transparent;

    /// <summary>
    /// �� ���� ������ ���̵带 Ȱ��ȭ��Ų��.
    /// </summary>
    public void EnableGuide()
    {
        foreach(var area in TriggerAreas)
        {
            area.areaObject.GetComponent<MeshRenderer>().material = origin;
        }
        mirror.cullingMask |= 1 << LayerMask.NameToLayer("Guide");
    }

    /// <summary>
    /// �� ���� ������ ���̵带 ��Ȱ��ȭ��Ų��.
    /// </summary>
    public void DisableGuide()
    {
        foreach (var area in TriggerAreas)
        {
            area.areaObject.GetComponent<MeshRenderer>().material = transparent;
        }
        mirror.cullingMask = ~(1 << LayerMask.NameToLayer("Guide"));
    }

    public override void GetEntered(int type, GameObject areaObject)
    {
        if(DanceScenarioManager.instance.currentScenarioNum == 1)
            areaObject.GetComponent<MeshRenderer>().material = blue;

        switch (type)
        {
            case 11:
                isTriggered[0] = true;
                isTriggered[1] = false; isTriggered[2] = false;
                break;
            case 12:
                isTriggered[1] = true;
                isTriggered[0] = false; isTriggered[2] = false;
                break;
            case 13:
                isTriggered[2] = true;
                isTriggered[0] = false; isTriggered[1] = false;
                break;
            case 21:
                isTriggered[3] = true;
                isTriggered[4] = false; isTriggered[5] = false;
                break;
            case 22:
                isTriggered[4] = true;
                isTriggered[3] = false; isTriggered[5] = false;
                break;
            case 23:
                isTriggered[5] = true;
                isTriggered[3] = false; isTriggered[4] = false;
                break;
            default:
                break;
        }
        Judge.UsingTypeForScenario();
    }

    public override void GetExited(int type, GameObject areaObject)
    {
        if (DanceScenarioManager.instance.currentScenarioNum == 1)
            areaObject.GetComponent<MeshRenderer>().material = origin;
    }

    public override void Initialize()
    {
        foreach (var triggerArea in TriggerAreas)
        {
            triggerArea.enterAction = () => { GetEntered(triggerArea.AreaType, triggerArea.gameObject); };
            triggerArea.exitAction = () => { GetExited(triggerArea.AreaType, triggerArea.gameObject); };
        }
        Debug.Log("Area Initialized");
        Judge = FindAnyObjectByType<DanceJudgingPoint>();
    }
}
