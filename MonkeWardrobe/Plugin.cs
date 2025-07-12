using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[BepInPlugin("com.elliot.gorillatag.monkewardrobe", "MonkeWardrobe", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    private GameObject wardrobeGazebo;
    private GameObject wardrobeMirror;
    private GameObject wardrobeBasement;

    private readonly string bayouSceneName = "Bayou";

    void Start()
    {
        StartCoroutine(DelayedLoadAndSpawn());
    }

    private IEnumerator DelayedLoadAndSpawn()
    {
        yield return new WaitForSeconds(2f);

        if (!SceneManager.GetSceneByName(bayouSceneName).isLoaded)
        {
            AsyncOperation loadOp = SceneManager.LoadSceneAsync(bayouSceneName, LoadSceneMode.Additive);
            yield return loadOp;
        }

        yield return null;

        var bayouMain = GameObject.Find("BayouMain");
        if (bayouMain == null) yield break;

        var computerArea = bayouMain.transform.Find("ComputerArea");
        if (computerArea == null) yield break;

        var satelliteWardrobe = computerArea.Find("SatelliteWardrobe");
        if (satelliteWardrobe == null) yield break;

        wardrobeGazebo = Instantiate(satelliteWardrobe.gameObject, StandLocations.gazeboStandPosition, StandLocations.gazeboStandRotation);
        wardrobeGazebo.name = "GazeboWardrobe";
        wardrobeGazebo.SetActive(true);
        DontDestroyOnLoad(wardrobeGazebo);

        wardrobeMirror = Instantiate(satelliteWardrobe.gameObject, StandLocations.mirrorStandPosition, StandLocations.mirrorStandRotation);
        wardrobeMirror.name = "CityMirrorWardrobe";
        wardrobeMirror.SetActive(true);
        DontDestroyOnLoad(wardrobeMirror);

        wardrobeBasement = Instantiate(satelliteWardrobe.gameObject, StandLocations.basementStandPosition, StandLocations.basementStandRotation);
        wardrobeBasement.name = "BasementWardrobe";
        wardrobeBasement.SetActive(true);
        DontDestroyOnLoad(wardrobeBasement);
    }

    void Update()
    {
        if (wardrobeGazebo != null && !wardrobeGazebo.activeSelf) wardrobeGazebo.SetActive(true);
        if (wardrobeMirror != null && !wardrobeMirror.activeSelf) wardrobeMirror.SetActive(true);
        if (wardrobeBasement != null && !wardrobeBasement.activeSelf) wardrobeBasement.SetActive(true);
    }
}
