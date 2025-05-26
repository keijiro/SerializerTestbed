using UnityEditor;
using UnityEngine;

public static class TestObjectCreator
{
    [MenuItem("GameObject/Create Test Object")]
    public static void CreateTestObject()
    {
        var go = new GameObject("TestObject");
        Undo.RegisterCreatedObjectUndo(go, "Create Test Object");

        var meshFilter = go.AddComponent<MeshFilter>();
        meshFilter.sharedMesh = CreateSphereMesh(1, 32, 16);

        var meshRenderer = go.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");

        Selection.activeGameObject = go;
    }

    static Mesh CreateSphereMesh(float radius, int longitudeSegments, int latitudeSegments)
    {
        var mesh = new Mesh() { name = "Sphere" };

        var vertCount = (longitudeSegments + 1) * (latitudeSegments + 1);
        var vertices = new Vector3[vertCount];

        var index = 0;
        for (var lat = 0; lat <= latitudeSegments; lat++)
        {
            var a1 = Mathf.PI * lat / latitudeSegments;
            var sin1 = Mathf.Sin(a1);
            var cos1 = Mathf.Cos(a1);

            for (var lon = 0; lon <= longitudeSegments; lon++)
            {
                var a2 = 2 * Mathf.PI * lon / longitudeSegments;
                var sin2 = Mathf.Sin(a2);
                var cos2 = Mathf.Cos(a2);

                vertices[index++] = new Vector3(sin1 * cos2, cos1, sin1 * sin2) * radius;
            }
        }

        var triangles = new int[longitudeSegments * latitudeSegments * 6];
        var triIndex = 0;
        for (var lat = 0; lat < latitudeSegments; lat++)
        {
            for (var lon = 0; lon < longitudeSegments; lon++)
            {
                var current = lat * (longitudeSegments + 1) + lon;
                var next = current + longitudeSegments + 1;

                triangles[triIndex++] = current;
                triangles[triIndex++] = next + 1;
                triangles[triIndex++] = next;

                triangles[triIndex++] = current;
                triangles[triIndex++] = current + 1;
                triangles[triIndex++] = next + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}
