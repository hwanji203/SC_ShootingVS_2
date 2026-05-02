using UnityEngine;

namespace Text
{
    public class TestAgent : MonoBehaviour
    {
        private void Update()
        {
            transform.eulerAngles += new Vector3(0, 5, 0);
        }
    }
}

