using System.Collections.Generic;
using UnityEngine;

namespace QVXkvoo.vseioAW.uicod
{
    public class h : MonoBehaviour
    {
        private bool isPooolkj;
        private int indexppol;
        private int qqqsqdiiopljh;

        [SerializeField] private List<CanvasElement> tjdmaca;

        public void asxacagtk()
        {
            if (indexppol < qqqsqdiiopljh)
            {
                tjdmaca[indexppol].Activate();
                indexppol++;
            }
            else
            {
                if (isPooolkj)
                    return;

                FindObjectOfType<n>().tgdhaa();
                isPooolkj = true;
            }
        }

        public static void FadeCanvasGroup(GameObject canvasObject, bool fadeIn)
        {
            canvasObject.SetActive(true);
            CanvasGroup canvasGroup = canvasObject.GetComponent<CanvasGroup>();
            float targetAlpha = fadeIn ? 1f : 0f;
            canvasObject.SetActive(false);
        }
    }

    [System.Serializable]
    public class CanvasElement
    {
        [SerializeField] private CEF cef;

        public void Activate()
        {
            cef.ShowAndScale();
        }
    }
}