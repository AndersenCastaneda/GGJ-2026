using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    int lives = 3;
    [SerializeField] TimelineUI _timelineUI;
    [SerializeField] public Image _targetRenderer;

    void Update()
    {
        if(!_timelineUI.IsPlaying())
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            bool isCorrectKey = false;
            
            if (_timelineUI.IsValidTiming())
            {
                Direction direction = _timelineUI.GetCurrentDirection();

                if (direction == Direction.Up)
                {
                    isCorrectKey = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
                }
                else if (direction == Direction.Down)
                {
                    isCorrectKey = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
                }
                else if (direction == Direction.Left)
                {
                    isCorrectKey = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
                }
                else if (direction == Direction.Right)
                {
                    isCorrectKey = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
                }

            }

            if (isCorrectKey)
            {
                Debug.Log("Hit!");
                _targetRenderer.color = Color.green;
            }
            else
            {
                lives--;
                Debug.Log("Miss! Lives left: " + lives);
                _targetRenderer.color = Color.red;
            }
        }
    }
}
