using UnityEngine;
using UnityEngine.UI;
using System;

[DefaultExecutionOrder(100)]
public class InputManager : MonoBehaviour
{
    int lives = 3;
    [SerializeField] TimelineUI _timelineUI;
    [SerializeField] public Image _targetRenderer;

    public static event Action<Direction> OnInputChanged;

    private void Update()
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

        var direction = Direction.None;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Direction.Right;
        }

        OnInputChanged?.Invoke(direction);
    }
}
