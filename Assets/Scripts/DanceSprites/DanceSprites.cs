using UnityEngine;

public class DanceSprites : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite up;
    [SerializeField] Sprite down;
    [SerializeField] Sprite right;
    [SerializeField] Sprite left;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetMove(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W:
                spriteRenderer.sprite = up;
                break;
            case KeyCode.S:
                spriteRenderer.sprite = down;
                break;
            case KeyCode.D:
                spriteRenderer.sprite = right;
                break;
            case KeyCode.A:
                spriteRenderer.sprite = left;
                break;
        }
    }
}
