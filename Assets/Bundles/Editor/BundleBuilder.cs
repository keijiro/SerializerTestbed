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

        var bundle1 = new AssetBundleBuild()
        {
            assetBundleName = "bundle1",
            assetNames = new[] { "Assets/Bundles/Material.mat" },
            addressableNames = new[] { "material" }
        };

        var bundle2 = new AssetBundleBuild()
        {
            assetBundleName = "bundle2",
            assetNames = new[] { "Assets/Bundles/Image.png" },
            addressableNames = new[] { "texture" }
        };

        var param = new BuildAssetBundlesParameters()
        {
            outputPath = tempDir,
            bundleDefinitions = new[] { bundle1, bundle2 }
        };

        BuildPipeline.BuildAssetBundles(param);

        File.Copy(tempDir + "/bundle1", destDir + "/bundle1", true);
        File.Copy(tempDir + "/bundle2", destDir + "/bundle2", true);

        AssetDatabase.Refresh();
    }
}
