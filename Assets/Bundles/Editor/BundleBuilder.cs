using UnityEditor;
using System.IO;

public static class BundleBuilder
{
    [MenuItem("Assets/Build Bundles")]
    static void BuildBundles()
    {
        var tempDir = "AssetBundles";
        var destDir = "Assets/StreamingAssets";

        if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
        if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

        BuildPipeline.BuildAssetBundles
          (tempDir,
           BuildAssetBundleOptions.None,
           EditorUserBuildSettings.activeBuildTarget);

        File.Copy(tempDir + "/bundle1", destDir + "/bundle1", true);
        File.Copy(tempDir + "/bundle2", destDir + "/bundle2", true);
    }
}
