using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneManager : AbstractSceneManager
{
    /// <summary>
    /// ���� �����ʰ� ��Ī�Ǵ� �̹��� ��������Ʈ�� ��ȯ�Ѵ�.
    /// </summary>
    public Sprite ShowProfile()
    {
        // ProfileManager ���� �� �Բ� �۾�
        throw new NotImplementedException();
    }

    /// <summary>
    /// DataTime ���̺귯���� ���� ���� �ð��� ����Ѵ�.
    /// ������ KST, ������ HHmmss.
    /// </summary>
    public static string GetCurrentTime()
    {
        DateTime currentDate = DateTime.Now;
        return currentDate.ToString("HH:mm:ss");
    }

    public override void MoveScene(string sceneName)
    {
        SceneMover.instance.MoveScene(sceneName);
    }

    public override void MoveScene(int sceneIndex)
    {
        SceneMover.instance.MoveScene(sceneIndex);
    }
}
