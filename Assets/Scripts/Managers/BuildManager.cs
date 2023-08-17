using UnityEngine;
using System;
public class BuildManager : MonoBehaviour
{
    [SerializeField] GameObject standartTurret;
    [SerializeField] GameObject missileLauncher;
    [SerializeField] GameObject laserBeamer;

    Vector3 buildOffset = Vector3.up * 0.5f;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnBuildStandartTurret, new Action<Vector3, Quaternion>(OnBuildStandartTurret));
        EventManager.AddHandler(GameEvent.OnBuildMissileLauncher, new Action<Vector3, Quaternion>(OnBuildMissileLauncher));
        EventManager.AddHandler(GameEvent.OnBuildLaserBeamer, new Action<Vector3, Quaternion>(OnBuildLaserBeamer));
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnBuildStandartTurret, new Action<Vector3, Quaternion>(OnBuildStandartTurret));
        EventManager.RemoveHandler(GameEvent.OnBuildMissileLauncher, new Action<Vector3, Quaternion>(OnBuildMissileLauncher));
        EventManager.RemoveHandler(GameEvent.OnBuildLaserBeamer, new Action<Vector3, Quaternion>(OnBuildLaserBeamer));
    }

    void OnBuildStandartTurret(Vector3 position, Quaternion rotation)
    {
        Instantiate(standartTurret, position + buildOffset, rotation);
    }

    void OnBuildMissileLauncher(Vector3 position, Quaternion rotation)
    {
        Instantiate(missileLauncher, position + buildOffset, rotation);
    }

    void OnBuildLaserBeamer(Vector3 position, Quaternion rotation)
    {
        Instantiate(laserBeamer, position + buildOffset, rotation);
    }
}
