using System.Linq;
using UnityEditor;

public class BuildScript
{
    public static void BuildWindows()
    {
        var senes = EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();

        BuildPipeline.BuildPlayer(
            senes,
            "Build/Windows/Jenkins.exe",
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}
