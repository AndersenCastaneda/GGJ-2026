using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(101)]
public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Sprite Idle1;
    [SerializeField] private Sprite Idle2;
    [SerializeField] private Sprite Up;
    [SerializeField] private Sprite Down;
    [SerializeField] private Sprite Left;
    [SerializeField] private Sprite Right;
    [SerializeField] private Sprite Missed;

    [SerializeField] private Image Image;

    void Awake()
    {
        InputManager.OnInputChanged += HandleInputChanged;
        UserInputAnalyzer.OnErrorInput += HandleMissed;
    }

    private void OnDestroy()
    {
        InputManager.OnInputChanged -= HandleInputChanged;
        UserInputAnalyzer.OnErrorInput -= HandleMissed;
    }

    private void HandleInputChanged(Direction direction)
    {
        Image.sprite = direction switch
        {
            Direction.None => Idle1,
            Direction.Up => Up,
            Direction.Down => Down,
            Direction.Left => Left,
            Direction.Right => Right,
            _ => Idle2
        };
    }

    private void HandleMissed()
    {
        Image.sprite = Missed;
    }
}
