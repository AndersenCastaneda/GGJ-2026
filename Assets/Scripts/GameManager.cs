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


    private int _currentLevel = 0;
    private int _currentSequence = 0;

    public void SetupLevel()
    {
        var level = _levels[_currentLevel];
        var sequence = level.Sequences[_currentSequence];

        _timelineUI.Setup(sequence.Notes);
    }

    public void StartLevel()
    {
        _timelineUI.enabled = true;
    }

    public void EndLevel()
    {
        _timelineUI.enabled = false;
    }
}
