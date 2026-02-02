using System;
using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class BuildScript
{
    public static void BuildWindows()
    {
        var version = Environment.GetEnvironmentVariable("BUILD_VERSION");
        if (!string.IsNullOrEmpty(version))
            PlayerSettings.bundleVersion = version;

        var scenes = EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();

        var report = BuildPipeline.BuildPlayer(
                    scenes,
                    $"Build/Windows/Jenkins_{PlayerSettings.bundleVersion}.exe",
                    BuildTarget.StandaloneWindows64,
                    BuildOptions.None
                );

        if (report.summary.result != BuildResult.Succeeded)
            throw new Exception("Build Failed: " + report.summary.result);
    }
}
