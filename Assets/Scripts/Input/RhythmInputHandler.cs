using UnityEngine;

namespace WolfFace
{
    public class RhythmInputHandler : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private bool useInputBuffer = true;

        [SerializeField]
        private float inputBufferTime = 0.1f;

        private InputBuffer _inputBuffer;

        public void HandleInput()
        {
            Debug.Log("RhythmInputHandler: HandleInput");
        }
    }
}
