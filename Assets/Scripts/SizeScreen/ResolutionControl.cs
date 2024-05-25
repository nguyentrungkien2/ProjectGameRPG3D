//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//public class ResolutionControl : MonoBehaviour
//{
//    [SerializeField] private TMP_Dropdown resolutionDropDown;
//    private Resolution[] resolutions;
//    private List<Resolution> filteredResolutions;

//    private float currentRefreshRate;
//    private int currentResolutionIndex = 0;

//    // Start is called before the first frame update
//    void Start()
//    {
//        resolutions=Screen.resolutions;
//        filteredResolutions = new List<Resolution>();

//        resolutionDropDown.ClearOptions();
//        currentRefreshRate = Screen.currentResolution.refreshRate;
//        Debug.Log("Resolution" + currentRefreshRate);
//        for (int i = 0; i < resolutions.Length; i++)
//        {
//            Debug.Log("Resolution" + resolutions[i]);
//            if (resolutions[i].refreshRate==currentRefreshRate)
//            {
//                filteredResolutions.Add(resolutions[i]);
//            }    
//        }
//        List<string> options = new List<string>();
//        for(int i = 0;i<filteredResolutions.Count;i++)
//        {
//            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate+"Hz";
//       options.Add(resolutionOption);
//            if (filteredResolutions[i].width==Screen.width && filteredResolutions[i].height==Screen.height)
//            {
//                currentResolutionIndex = i;
//            }    
//        }  
//        resolutionDropDown.AddOptions(options);
//        resolutionDropDown.value = currentResolutionIndex;
//        resolutionDropDown.RefreshShownValue();
//    }
//    public void SetResolution(int resolutionIndex)
//    {
//        Resolution resolution= filteredResolutions[resolutionIndex];
//        Screen.SetResolution(resolution.width, resolution.height,true);
//    }    
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropDown.ClearOptions();

        // Tính toán refresh rate từ refreshRateRatio
        currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.numerator / Screen.currentResolution.refreshRateRatio.denominator;
        Debug.Log("Current Refresh Rate: " + currentRefreshRate);

        for (int i = 0; i < resolutions.Length; i++)
        {
            // Tính toán refresh rate từ refreshRateRatio
            float refreshRate = (float)resolutions[i].refreshRateRatio.numerator / resolutions[i].refreshRateRatio.denominator;
            //Debug.Log("Resolution: " + resolutions[i].width + "x" + resolutions[i].height + " @ " + refreshRate + "Hz");

            if (Mathf.Approximately(refreshRate, currentRefreshRate))
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " @ " +
                ((float)filteredResolutions[i].refreshRateRatio.numerator / filteredResolutions[i].refreshRateRatio.denominator) + "Hz";
            options.Add(resolutionOption);

            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }
}
