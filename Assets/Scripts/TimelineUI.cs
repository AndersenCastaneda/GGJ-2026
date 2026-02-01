using System;
using UnityEngine;

public enum Direction
{
    None,
    Up,
    Down,
    Left,
    Right
}

[System.Serializable]
public struct Note
{
    public Direction Direction;
    public int index;
}

public class TimelineUI : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip audioClip;

    public GameObject NotePrefab;
    [SerializeField] public RectTransform _parent;
    [SerializeField] public RectTransform _targetPosition;

    private Vector3 _target;
    private Vector3 _targetLeftRange;
    private Vector3 _targetRightRange;

    private Transform[] _noteObjects;

    private Note[] _notes;

    private Transform _currentNote;

    public float _distance;
    public float _errorTolerance;

    private int _currentIndex;
    private bool _isPlaying = false;

    public void Setup(Note[] notes)
    {
        _notes = notes;
        _currentIndex = 0;
        _noteObjects = new Transform[notes.Length];

        for (int i = 0; i < notes.Length; i++)
        {
            var index = notes[i].index;
            var noteObject = Instantiate(NotePrefab, _parent);
            noteObject.transform.localPosition = new Vector3(index * _distance, 0, 0);
            _noteObjects[i] = noteObject.transform;
        }

        _currentNote = _noteObjects[_currentIndex];
        _target = _targetPosition.transform.position;
        _targetLeftRange = new Vector3(_target.x - _errorTolerance, _target.y, _target.z);
        _targetRightRange = new Vector3(_target.x + _errorTolerance, _target.y, _target.z);

        _isPlaying = true;
    }

    public void Restart()
    {
        enabled = false;
        _currentIndex = 0;
        _currentNote = _noteObjects[_currentIndex];
        _isPlaying = false;
        _parent.localPosition = new Vector3(1100, -270, 0);
    }

    public void StartLevel()
    {
        _isPlaying = true;
        enabled = true;
    }

    private void Update()
    {
        _parent.localPosition += Vector3.left * (Time.deltaTime * 1500f);

        if (_noteObjects[^1].position.x < _target.x - 300)
        {
            enabled = false;
            return;
        }

        if (!_isPlaying)
        {
            return;
        }

        if (_currentNote.position.x <= _target.x)
        {
            _audioSource.PlayOneShot(audioClip);

            ++_currentIndex;
            if (_currentIndex >= _noteObjects.Length)
            {
                _isPlaying = false;
                return;
            }

        }


        // Note: we need this offset to allow the user to press the key a bit later.
        if (_currentNote.position.x < _targetLeftRange.x)
        {
            _currentNote = _noteObjects[_currentIndex];
        }
    }

    public bool IsValidTiming()
    {
        if (!_isPlaying || _currentNote == null || _currentIndex >= _notes.Length)
        {
            return false;
        }

        return _currentNote.position.x >= _targetLeftRange.x && _currentNote.position.x <= _targetRightRange.x;
    }

    public Direction GetValidDirection()
    {
        if (_notes == null || _currentIndex >= _notes.Length)
        {
            return Direction.None;
        }

        return _notes[_currentIndex].Direction;
    }

    public bool IsPlaying()
    {
        return _isPlaying;
    }
}