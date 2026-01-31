using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Note
{
    public KeyCode Key;
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

    private Transform[] _noteObjects;

    private Transform _currentNote;

    public float _distance = 1f;

    private int _currentIndex;
    private bool _isPlaying = false;

    public void Setup(Note[] notes)
    {
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
        _isPlaying = true;
    }

    private void Update()
    {
        _parent.localPosition += Vector3.left * (Time.deltaTime * 1500f);

        if (!_isPlaying)
        {
            return;
        }

        if (_currentNote.position.x <= _target.x)
        {
            if (_currentNote.TryGetComponent(out Image image))
            {
                image.color = Color.red;
            }
            _audioSource.PlayOneShot(audioClip);

            ++_currentIndex;
            if (_currentIndex >= _noteObjects.Length)
            {
                _isPlaying = false;
                return;
            }

            _currentNote = _noteObjects[_currentIndex];
        }
    }
}