using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QVXkvoo.vseioAW.uicod
{
    public class CEF : MonoBehaviour
    {
        private Transform yukdlaTerxt;

        public void ShowAndScale()
        {
            h.FadeCanvasGroup(gameObject, true);
            ScaleElement();
        }

        private void ScaleElement()
        {
            yukdlaTerxt.localScale = new Vector3(1, 0.8f, 1);
            ;
        }

        private void Awake()
        {
            yukdlaTerxt = GetComponentInChildren<TMP_Text>().transform;
            GetComponentInChildren<Button>().onClick.AddListener(DisableCanvas);
        }

        private void DisableCanvas()
        {
            h.FadeCanvasGroup(gameObject, false);
            FindObjectOfType<h>().asxacagtk();
        }
    }
}