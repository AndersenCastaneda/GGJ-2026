using UnityEngine;

public class TestDanceInput : MonoBehaviour
{
    DanceSprites danceSpritessScript;
   
    void Start()
    {
        danceSpritessScript = GetComponent<DanceSprites>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                danceSpritessScript.SetMove(KeyCode.W);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                danceSpritessScript.SetMove(KeyCode.S);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                danceSpritessScript.SetMove(KeyCode.A);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))           {
                danceSpritessScript.SetMove(KeyCode.D);
            }
        }
    }
}
