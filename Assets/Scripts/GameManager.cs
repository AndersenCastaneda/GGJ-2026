using System.Collections;
using UnityEngine;

[System.Serializable]
public class Level
{
    public Sequence[] Sequences;
}

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Level[] _levels;
    [SerializeField] TimelineUI _timelineUI;
    [SerializeField] InputManager _inputManager;

    private int _currentLevel = 0;
    private int _currentSequence = 0;

    private void Start()
    {
        StartCoroutine(RunLevel());
    }

    IEnumerator RunLevel()
    {
        RunExampleSequence();
        
        while (_timelineUI.IsPlaying())
        {
            yield return new WaitForSeconds(1f);
        }

        EndLevel();

        RunUserSequence();

        while (_timelineUI.IsPlaying())
        {
            yield return new WaitForSeconds(1f);
        }

        EndLevel();
    }

    public void SetupLevel()
    {
        var level = _levels[_currentLevel];
        var sequence = level.Sequences[_currentSequence];

        _timelineUI.Setup(sequence.Notes);
    }

    public void RunExampleSequence()
    {
        SetupLevel();
        _timelineUI.Restart();
        _timelineUI.StartLevel();
        _inputManager.enabled = false;
    }

    public void RunUserSequence()
    {
        SetupLevel();
        _timelineUI.Restart();
        _timelineUI.StartLevel();
        _inputManager.enabled = true;
    }

     public void EndLevel()
    {
        _timelineUI.enabled = false;
        _inputManager.enabled = false;
    }
}
