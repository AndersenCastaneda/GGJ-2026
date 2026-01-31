using UnityEngine;

[CreateAssetMenu(fileName = "New Rythm", menuName = "ScriptableObject/Rythm")]
public class Rythm : ScriptableObject
{
    public Note[] Notes;
}