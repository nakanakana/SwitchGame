using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FanGizmos
{
    /// <summary>
    /// ��`�̃M�Y�������
    /// </summary>
    public class FanGizmo : MonoBehaviour
    {
        /// <summary>
        /// ��`�̃M�Y�������
        /// </summary>
        /// <param name="parent">�M�Y���̐e�I�u�W�F�N�g</param>
        /// <param name="loc">�e�I�u�W�F�N�g�Ƃ̑��Έʒu</param>
        /// <param name="rot">�e�I�u�W�F�N�g�Ƃ̑��Ίp�x</param>
        /// <param name="mat">�M�Y���Ɋ��蓖�Ă�}�e���A��</param>
        /// <returns>instantiate�����M�Y���I�u�W�F�N�g</returns>
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
        /// �M�Y�����w�肵���p�x�A�����ɕό`����B�����͏d���̂�Update�񐄏��B
        /// </summary>
        /// <param name="g">�M�Y���ɂȂ�gameobject���̂���ref�œn��</param>
        /// <param name="parent">�M�Y���̐e�I�u�W�F�N�g</param>
        /// <param name="angle">�M�Y���̊p�x</param>
        /// <param name="range">�M�Y���̒���</param>
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
