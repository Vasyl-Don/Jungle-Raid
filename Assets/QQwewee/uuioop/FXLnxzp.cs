using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace QVXkvoo.vseioAW.segAIWUt
{
    public class FXLnxzp:MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public string MPEwavu(List<string> stringsToConcatenate)
        {
            StringBuilder resultBuilder = new StringBuilder();
            foreach (var str in stringsToConcatenate)
            {
                resultBuilder.Append(str);
            }

            return resultBuilder.ToString();
        }
    }
}