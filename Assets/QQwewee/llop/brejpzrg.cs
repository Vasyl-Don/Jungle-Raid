using UnityEngine;

namespace QVXkvoo.vseioAW.pllj
{
    public class brejpzrg : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void OVWsuaa()
        {
            UniWebView.SetAllowInlinePlay(true);

            var mnbvgfgh = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (var ertyuiolkmn in mnbvgfgh)
            {
                ertyuiolkmn.Stop();
            }

            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}