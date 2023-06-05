using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ð��� ���� ��Ʈ�� �����ϰ� �̸� ���� ����ڿ��� Ÿ�̹��� ������Ű�� Ŭ����.
/// </summary>
public class DanceJudgingPoint : MonoBehaviour
{
    [SerializeField] float fallingTime = 2;
    /// <summary>
    /// ��Ʈ�� ������ �� �����鿡 ���� �������� �ð�.
    /// </summary>
    public float FallingTime { get => fallingTime; set => fallingTime = value; }

    float noteVelocity = 0;
    /// <summary>
    /// ��Ʈ�� ��� � �ӵ�.
    /// </summary>
    public float NoteVelocity { get => noteVelocity; set => noteVelocity = value; }

    /// <summary>
    /// ���� ����ڰ� ���� ������ Transform.
    /// </summary>
    public Transform JudgePosition;

    /// <summary>
    /// ��Ʈ�� �����Ǵ� ��ġ.
    /// </summary>
    public Transform NoteSpawnTransforms;

    /// <summary>
    /// �����ϴ� ��Ʈ�� ������.
    /// </summary>
    public Rigidbody NotePrefab;

    /// <summary>
    /// ��Ʈ�� ���� ��������Ʈ���� �����ϴ� ����Ʈ.
    /// </summary>
    public List<Sprite> sprites = new List<Sprite>();

    /// <summary>
    /// ������ ��� ��Ʈ���� �����ϴ� ����Ʈ.
    /// </summary>
    private List<Rigidbody> notes = new List<Rigidbody>();

    /// <summary>
    /// ����Ǵ� ��� ��Ʈ ��ƾ�� �����ϴ� ����Ʈ.
    /// </summary>
    private List<IEnumerator> noteRoutines = new List<IEnumerator>();

    /// <summary>
    /// ������ ���� ���� �ߵ��� Ʈ���� ������ ��ü������ �����ϴ� bool �迭.
    /// </summary>
    private bool[] current = new bool[6];

    /// <summary>
    /// ��Ʈ�� �ӷ��� �����Ѵ�.
    /// </summary>
    public void SetVelocity()
    {
        NoteVelocity = (JudgePosition.position - NoteSpawnTransforms.position).magnitude / FallingTime;
    }

    /// <summary>
    /// SpawnNoteRoutine(time, type) ��ƾ ����.
    /// </summary>
    /// <param name="time">��ƾ�� ���۵� �ð�.</param>
    /// <param name="type">��Ʈ�� �����Ǵ� ����</param>
    public void SpawnNote(float time, int type)
    {
        IEnumerator noteRoutine = SpawnNoteRoutine(time, type);
        noteRoutines.Add(noteRoutine);
        StartCoroutine(noteRoutine);
    }

    /// <summary>
    /// SpawnNoteRoutineWithChange(time, type) ��ƾ ����.
    /// </summary>
    /// <param name="time">��ƾ�� ���۵� �ð�.</param>
    /// <param name="type">��Ʈ�� �����Ǵ� ����</param>
    IEnumerator SpawnNoteRoutine(float time, int type)
    {
        yield return new WaitForSeconds(Mathf.Clamp(time - FallingTime, 0, float.MaxValue));
        Rigidbody newNote = GetNote(type);
        newNote.velocity = NoteSpawnTransforms.forward * NoteVelocity;
        yield return new WaitForSeconds(1.1f * fallingTime);
        if (newNote.gameObject.activeInHierarchy) DanceScenarioManager.instance.JudgeNote(type, 0);
        Destroy(newNote?.gameObject);
        notes.Remove(newNote);
    }

    /// <summary>
    /// ���� �ݶ��̴��� ��Ʈ�� ������ �ش� ��Ʈ�� ������ ������ ������.
    /// </summary>
    /// <param name="other">�ݶ��̴��� ������ ��Ʈ ������Ʈ</param>
    private void OnTriggerEnter(Collider other)
    {
        JudgeNote(other.gameObject.GetComponent<DanceNote>().type);
        notes.Remove(other.gameObject.GetComponent<Rigidbody>());
        other.gameObject.SetActive(false);
    }

    /// <summary>
    /// ��Ʈ ������ �ʿ���� �ó������� ���� ��ü ���� ��û�� ������.
    /// ��� �����ϱ⸸ �ϴ� �ó����� 1, 2���� ����.
    /// </summary>
    public void UsingTypeForScenario()
    {
        switch (DanceScenarioManager.instance.currentScenarioNum)
        {
            case 1:
                DanceScenarioManager.instance.JudgeNote(11, 1);
                break;
            case 2:
                DanceScenarioManager.instance.JudgeNote(11, 1);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// �����鿡 ������ ��Ʈ ������Ʈ�� ������ ������ �Ѵ�.
    /// Ʈ���� ������ �ٷ�� Manager���� Ȱ��ȭ ���� �迭�� �޾ƿ� ������ �̿��Ѵ�.
    /// </summary>
    /// <param name="type">��Ʈ�� ����.</param>
    /// <returns>��Ʈ ���� ���.</returns>
    public int JudgeNote(int type)
    {
        int result = -1;

        Array.Copy(DanceScenarioManager.instance.danceAreaManager.area.isTriggered, current, 6);

        string leftValue = "-1";
        string rightValue = "-1";

        if (current[0]) leftValue = "1";
        else if (current[1]) leftValue = "2";
        else if (current[2]) leftValue = "3";

        if (current[3]) rightValue = "1";
        else if (current[4]) rightValue = "2";
        else if (current[5]) rightValue = "3";

        string curPose = leftValue + rightValue;

        if(curPose == type.ToString())
        {
            result = 1;
        }
        else
        {
            result = 0;
        }
        Debug.Log(curPose + ", result = " + result.ToString());
        DanceScenarioManager.instance.JudgeNote(type, result);
        
        return result;
    }

    /// <summary> 
    /// ��Ʈ�� �����ϰ� �ش� ������Ʈ�� RigidBody ������Ʈ�� ��ȯ�Ѵ�.
    /// �� ��, ��Ʈ�� Ÿ�Կ� �´� ��������Ʈ�� ��Ʈ�� �����Ѵ�.
    /// <returns>������ ��Ʈ�� RigidBody.</returns>
    /// </summary>
    Rigidbody GetNote(int type)
    {
        Rigidbody newNote = Instantiate(NotePrefab, NoteSpawnTransforms.position, NoteSpawnTransforms.rotation);
        newNote.gameObject.GetComponent<DanceNote>().type = type;
        switch (type)
        {
            case 11:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[0];
                break;
            case 12:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[1];
                break;
            case 13:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[2];
                break;
            case 21:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[3];
                break;
            case 22:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[4];
                break;
            case 23:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[5];
                break;
            case 31:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[6];
                break;
            case 32:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[7];
                break;
            case 33:
                newNote.gameObject.GetComponent<DanceNote>().image.sprite = sprites[8];
                break;
            default:
                break;
        }
        notes.Add(newNote);
        return newNote;
    }

    /// <summary>
    /// �� ���� ���·� �ǵ����� �Լ�.
    /// </summary>
    public void ResetAll()
    {
        foreach (IEnumerator routine in noteRoutines)
        {
            StopCoroutine(routine);
        }
        noteRoutines.Clear();
        foreach (Rigidbody note in notes)
        {
            Destroy(note.gameObject);
        }
        notes.Clear();
    }
}
