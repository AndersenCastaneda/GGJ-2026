using UnityEngine;
using UnityEngine.UI;
using System;

[DefaultExecutionOrder(102)]
public class UserInputAnalyzer : MonoBehaviour
{
    [SerializeField] TimelineUI _timelineUI;
    [SerializeField] public Image _targetRenderer;

    public static event Action OnErrorInput;
    public static event Action OnCorrectInput;

    private void Awake()
    {
        InputManager.OnInputChanged += HandleInputChanged;
    }

    private void OnDestroy()
    {
        InputManager.OnInputChanged -= HandleInputChanged;
    }

    private void HandleInputChanged(Direction direction)
    {
        bool isCorrectKey = false;

        if (_timelineUI.IsValidTiming())
        {
            var validDirection = _timelineUI.GetValidDirection();
            isCorrectKey = direction == validDirection;
        }

        if (isCorrectKey)
        {
            OnCorrectInput?.Invoke();
            Debug.Log("Hit!");
            _targetRenderer.color = Color.green;
        }
        else
        {
            OnErrorInput?.Invoke();
            _targetRenderer.color = Color.red;
        }
    }
}
