using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    /// <summary>
    /// ���� �����ʰ� ��Ī�Ǵ� �̹��� ��������Ʈ�� ��ȯ�Ѵ�.
    /// </summary>
    public Sprite ShowProfile()
    {
        // ProfileManager ���� �� �Բ� �۾�
        return null;
    }

    /// <summary>
    /// DataTime ���̺귯���� ���� ���� �ð��� ����Ѵ�.
    /// ������ KST, ������ HHmmss.
    /// </summary>
    public static string ShowCurrentTime()
    {
        DateTime currentDate = DateTime.Now;
        return currentDate.ToString("HH:mm:ss");
    }
}
