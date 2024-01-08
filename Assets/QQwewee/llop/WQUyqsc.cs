using QVXkvoo.vseioAW.pllj;
using UnityEngine;

namespace QVXkvoo.vseioAW.lkjnmldadf
{
    public class WQUyqsc : MonoBehaviour
    {
        public brejpzrg OGWhzvk;

        public void OnEnable()
        {
            OGWhzvk.OVWsuaa();
        }

        public string MEOirvi;

        public string BYDcmxq
        {
            get => HOSqdhk;
            set => HOSqdhk = value;
        }

        public int LZYmmem = 70;

        private string HOSqdhk;
        private UniWebView UYNifmr;
        private GameObject AKNxaaw;

        private void Start()
        {
            XLVfcdo();
            ZIHicko(HOSqdhk);
            DKKsyea();
        }

        private void XLVfcdo()
        {
            ZOSptda();

            switch (BYDcmxq)
            {
                case "0":
                    UYNifmr.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    UYNifmr.SetShowToolbar(false);
                    break;
            }

            UYNifmr.Frame = new Rect(0, LZYmmem, Screen.width, Screen.height - LZYmmem);

            // Other setup logic...

            UYNifmr.OnPageFinished += (_, _, url) =>
            {
                if (PlayerPrefs.GetString("LastLoadedPage", string.Empty) == string.Empty)
                {
                    PlayerPrefs.SetString("LastLoadedPage", url);
                }
            };
        }

        private void ZOSptda()
        {
            UYNifmr = GetComponent<UniWebView>();
            if (UYNifmr == null)
            {
                UYNifmr = gameObject.AddComponent<UniWebView>();
            }

            UYNifmr.OnShouldClose += _ => false;

            // Other initialization logic...
        }

        private void ZIHicko(string url)
        {
            print("URL_" + url);
            if (!string.IsNullOrEmpty(url))
            {
                UYNifmr.Load(url);
            }
        }

        private void DKKsyea()
        {
            if (AKNxaaw != null)
            {
                AKNxaaw.SetActive(false);
            }
        }
    }
}