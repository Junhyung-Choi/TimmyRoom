using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ���� Ʈ���� ������ ����ϴ� Ŭ�����̴�.
/// </summary>
public class DanceAreaManager : MonoBehaviour
{
    /// <summary>
    /// �� ���࿡ ���Ǵ� ��� �������� ����.
    /// </summary>
    public AreaSet area;

    /// <summary>
    /// �ʱ� ������ ���� �Լ�.
    /// </summary>
    public void Initialize()
    {
        area.Initialize();
    }

    /// <summary>
    /// �� ���� ���·� �ǵ����� �Լ�.
    /// </summary>
    public void ResetAll()
    {
        area.gameObject.SetActive(false);
    }
}
