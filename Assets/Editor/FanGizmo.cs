using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FanGizmos
{
    /// <summary>
    /// 扇形のギズモを作る
    /// </summary>
    public class FanGizmo : MonoBehaviour
    {
        /// <summary>
        /// 扇形のギズモを作る
        /// </summary>
        /// <param name="parent">ギズモの親オブジェクト</param>
        /// <param name="loc">親オブジェクトとの相対位置</param>
        /// <param name="rot">親オブジェクトとの相対角度</param>
        /// <param name="mat">ギズモに割り当てるマテリアル</param>
        /// <returns>instantiateしたギズモオブジェクト</returns>
        public GameObject CreateGizmo(GameObject parent, Vector3 loc, Vector3 rot, Material mat)
        {
            GameObject g = Instantiate(new GameObject(), loc + parent.transform.position, Quaternion.Euler(rot)) as GameObject;
            g.transform.parent = parent.transform;
            g.AddComponent<MeshRenderer>();
            g.AddComponent<MeshFilter>();
            g.GetComponent<MeshRenderer>().material = mat;
            return g;
        }
        /// <summary>
        /// ギズモを指定した角度、長さに変形する。処理は重いのでUpdate非推奨。
        /// </summary>
        /// <param name="g">ギズモになるgameobjectそのものrefで渡す</param>
        /// <param name="parent">ギズモの親オブジェクト</param>
        /// <param name="angle">ギズモの角度</param>
        /// <param name="range">ギズモの長さ</param>
        public void RefreshGizmo(ref GameObject g, GameObject parent, float angle, float range)
        {
            var mesh = new Mesh();
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            float x, y;
            int i = 0;
            vertices.Add(new Vector3(0, 0, 0));

            for (float d = -angle / 2f; d <= angle / 2f; d++)
            {
                x = Mathf.Sin(d * Mathf.Deg2Rad) * range;
                y = Mathf.Cos(d * Mathf.Deg2Rad) * range;
                vertices.Add(new Vector3(x, 0, y));
                triangles.AddRange(new int[] { 0, i + 1, i + 2 });
                i++;
            }
            triangles.RemoveRange(triangles.Count - 3, 3);
            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0);

            mesh.RecalculateNormals();
            g.GetComponent<MeshFilter>().sharedMesh = mesh;

        }
    }
}
