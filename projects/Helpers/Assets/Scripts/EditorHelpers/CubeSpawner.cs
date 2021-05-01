using System;
using System.Collections.Generic;
using UnityEngine;

namespace AValentini.Helpers.EditorHelpers
{
    public class CubeSpawner : MonoBehaviour
    {
        public List<Cube> cubes = new List<Cube> ();

        void Start ()
        {
            Debug.LogFormat ("Cubes = {0}", cubes.Count);
        }
    }

    [Serializable]
    public struct Cube
    {
        public int edge;
        public string name;
        public CubeColor color;
    }

    public enum CubeColor
    {
        RED,
        WHITE,
        BLUE
    }
}