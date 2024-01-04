using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using QVXkvoo.vseioAW.lkjnmldadf;
using QVXkvoo.vseioAW.uicod;
using Unity.Advertisement.IosSupport;
using UnityEngine;
using UnityEngine.Networking;

namespace QVXkvoo.vseioAW.segAIWUt
{
    public class UBSlvdb : MonoBehaviour
    {
        [SerializeField] private WQUyqsc BSUprdj;
        [SerializeField] private LUHfbiv BKUovac;

        [SerializeField] private FXLnxzp ADKaqmq;


        [SerializeField] private List<string> longoDetalisimo;

        private string QDUbeil;

        private void Awake()
        {
            UCNntul();
        }


        private bool BINknei = true;
        private NetworkReachability HFRdhfq = NetworkReachability.NotReachable;

        private string ZCUckuu;
        private string DERrnku;
        private int FMFqhyk;

        private string ITYjero;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            BKUovac.YRRpjoe();
            StartCoroutine(ZEKtpsb());

            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    IWKxgvg();
                    break;
                default:
                    CORmwwt();
                    break;
            }
        }


        private void CORmwwt()
        {
            if (PlayerPrefs.GetString("eera", string.Empty) != string.Empty)
            {
                ZUDeasu();
            }
            else
            {
                MWAsosf();
            }
        }

        private void ZUDeasu()
        {
            ZCUckuu = PlayerPrefs.GetString("eera", string.Empty);
            DERrnku = PlayerPrefs.GetString("eeraa", string.Empty);
            FMFqhyk = PlayerPrefs.GetInt("eerad", 0);
            JCAtuxz();
        }

        private void MWAsosf()
        {
            Invoke(nameof(UZLvyln), 7.4f);
        }

        private void UZLvyln()
        {
            if (Application.internetReachability == HFRdhfq)
            {
                IWKxgvg();
            }
            else
            {
                StartCoroutine(GJMaivx());
            }
        }


        private IEnumerator GJMaivx()
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(ADKaqmq.MPEwavu(longoDetalisimo));
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                IWKxgvg();
            }
            else
            {
                FZWbbxi(webRequest);
            }
        }

        private void FZWbbxi(UnityWebRequest webRequest)
        {
            string tokenConcatenation = ADKaqmq.MPEwavu(ssstrrr.Strs);

            if (webRequest.downloadHandler.text.Contains(tokenConcatenation))
            {
                try
                {
                    string[] dataParts = webRequest.downloadHandler.text.Split('|');
                    PlayerPrefs.SetString("eera", dataParts[0]);
                    PlayerPrefs.SetString("eeraa", dataParts[1]);
                    PlayerPrefs.SetInt("eerad", int.Parse(dataParts[2]));

                    ZCUckuu = dataParts[0];
                    DERrnku = dataParts[1];
                    FMFqhyk = int.Parse(dataParts[2]);
                }
                catch
                {
                    PlayerPrefs.SetString("eera", webRequest.downloadHandler.text);
                    ZCUckuu = webRequest.downloadHandler.text;
                }

                JCAtuxz();
            }
            else
            {
                IWKxgvg();
            }
        }

        private void JCAtuxz()
        {
            BSUprdj.BYDcmxq = $"{ZCUckuu}?idfa={ITYjero}";
            BSUprdj.BYDcmxq +=
                $"&gaid={AppsFlyer.getAppsFlyerId()}{PlayerPrefs.GetString("poiu", string.Empty)}";
            BSUprdj.MEOirvi = DERrnku;

            UAHjcvw();
        }

        private void UCNntul()
        {
            switch (BINknei)
            {
                case true:
                    BINknei = false;
                    break;
                default:
                    gameObject.SetActive(false);
                    break;
            }
        }

        private IEnumerator ZEKtpsb()
        {
#if UNITY_IOS
            var authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
            while (authorizationStatus == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
                yield return null;
            }
#endif

            ITYjero = BKUovac.RDPhmwu();
            yield return null;
        }

        public void UAHjcvw()
        {
            BSUprdj.LZYmmem = FMFqhyk;
            BSUprdj.gameObject.SetActive(true);
        }

        [SerializeField] private popLSpiso ssstrrr;

        private void IWKxgvg()
        {
            EADpsuj();
        }

        private void EADpsuj()
        {
            h.FadeCanvasGroup(gameObject, false);
        }
    }
}