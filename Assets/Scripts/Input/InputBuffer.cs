using System.Collections.Generic;
using UnityEngine;

namespace WolfFace
{
    public struct BufferedInput
    {
        public EDirectionInput Direction;
        public float Timestamp;
    }

    public class InputBuffer
    {
        private List<BufferedInput> _buffer = new List<BufferedInput>();
        private float _bufferDuration = 0.1f;

        public void Clear()
        {
            _buffer.Clear();
        }

        public List<BufferedInput> GetBufferedInputs()
        {
            return _buffer;
        }
    }
}
