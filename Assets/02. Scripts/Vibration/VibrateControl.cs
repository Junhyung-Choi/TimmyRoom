using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VibrateControl : MonoBehaviour
{
    public static VibrateControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

    [SerializeField] private ActionBasedController rightController;
    [SerializeField] private ActionBasedController leftController;

    /// <summary>
    /// ������ ��Ʈ�ѷ��� Ȱ��ȭ�� ������ ��� ������ ��Ʈ�ѷ��� ������ ����մϴ�.
    /// </summary>
    /// <param name="amplitude">0.0���� 1.0 ������ ���� ������ �����մϴ�.</param>
    /// <param name="duration">�� �ʵ��� ������ ����� �������� �����մϴ�.</param>
    public IEnumerator CustomVibrateRight(float amplitude, float duration)
    {
        if (rightController != null)
        {
            rightController.SendHapticImpulse(amplitude, duration);
        }
        else
        {
            Debug.LogError("right controller isn't avaliable.");
        }
        yield return null;
    }

    /// <summary>
    /// ���� ��Ʈ�ѷ��� Ȱ��ȭ�� ������ ��� ���� ��Ʈ�ѷ��� ������ ����մϴ�.
    /// </summary>
    /// <param name="amplitude">0.0���� 1.0 ������ ���� ������ �����մϴ�.</param>
    /// <param name="duration">�� �ʵ��� ������ ����� �������� �����մϴ�.</param>
    public IEnumerator CustomVibrateLeft(float amplitude, float duration)
    {
        if (leftController != null)
        {
            leftController.SendHapticImpulse(amplitude, duration);
        }
        else
        {
            Debug.LogError("left controller isn't avaliable.");
        }

        yield return null;
    }
}
