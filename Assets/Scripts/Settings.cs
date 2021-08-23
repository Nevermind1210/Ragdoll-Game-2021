using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Settings : MonoBehaviour
{
   void FramerateLimit(int target)
   {
      Application.targetFrameRate = 120;
   }

   void vSyncCount()
   {
      QualitySettings.vSyncCount = 0; // 0 - 4
   }

   void ChangeResolution()
   {
      Resolution[] allowedRes = Screen.resolutions;

      var example = allowedRes;

      Resolution res = new Resolution();

      res.height = 1080;
      res.width = 1920;
      res.refreshRate = 60;

      //Screen.currentResolution = allowedRes[5];
   }
}
