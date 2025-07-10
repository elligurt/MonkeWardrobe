using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[BepInPlugin("com.elliot.gorillatag.monkewardrobe", "MonkeWardrobe", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    private GameObject clone1;
    private GameObject clone2;

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

        clone1 = Instantiate(satelliteWardrobe.gameObject, StandLocations.Stand1Position, StandLocations.Stand1Rotation);
        clone1.name = "GazeboWardrobe";
        clone1.SetActive(true);
        DontDestroyOnLoad(clone1);

        clone2 = Instantiate(satelliteWardrobe.gameObject, StandLocations.Stand2Position, StandLocations.Stand2Rotation);
        clone2.name = "CityMirrorWardrobe";
        clone2.SetActive(true);
        DontDestroyOnLoad(clone2);
    }

    void Update()
    {
        if (clone1 != null && !clone1.activeSelf) clone1.SetActive(true);
        if (clone2 != null && !clone2.activeSelf) clone2.SetActive(true);
    }
}
