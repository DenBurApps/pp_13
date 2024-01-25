using System.Linq;
using System;
using UnityEditor;
using UnityEngine;

public static class BuildScript
{
    [MenuItem("Build/Build iOS")]
    public static void BuildIos()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.locationPathName = "ios";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;
        buildPlayerOptions.scenes = GetScenes();

        Debug.Log("Building iOS");
        BuildPipeline.BuildPlayer(buildPlayerOptions);
        Debug.Log("Built iOS");
    }

    private static string[] GetScenes()
    {
        return (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
    }

}