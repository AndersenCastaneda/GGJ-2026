using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Note
{
    public KeyCode Key;
    public int index;
    public bool HasPlayed;
}

public class TestUI : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip audioClip;

    public GameObject NotePrefab;
    [SerializeField] public RectTransform _parent;
    [SerializeField] public RectTransform _targetPosition;

    private Vector3 _target;

    private GameObject[] _noteObjects;

    private GameObject _currentNote;

    public Note[] InputKeys;

    public float _distance = 1f;

    private int _currentIndex;

    private bool _isPlaying = false;

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _currentIndex = 0;
        _noteObjects = new GameObject[InputKeys.Length];

        for (int i = 0; i < InputKeys.Length; i++)
        {
            InputKeys[i].HasPlayed = false;
        }

        for (int i = 0; i < InputKeys.Length; i++)
        {
            var index = InputKeys[i].index;
            var noteObject = Instantiate(NotePrefab, _parent);
            noteObject.transform.localPosition = new Vector3(index * _distance, 0, 0);
            _noteObjects[i] = noteObject;
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

        if (_currentNote.transform.position.x <= _target.x)
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