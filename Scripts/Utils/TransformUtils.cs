using UnityEngine;

namespace UniversalUnityPackage
{
    public static class TransformUtils
    {
        public static Transform[] GetChildren(this Transform parent)
        {
            Transform[] children = new Transform[parent.childCount];

            for (int i = 0; i < children.Length; i++)
            {
                children[i] = parent.GetChild(i);
            }

            return children;
        }

        public static T[] GetChildren<T>(this Transform parent) where T : Component
        {
            T[] components = new T[parent.childCount];

            for (int i = 0; i < components.Length; i++)
            {
                components[i] = parent.GetChild(i).GetComponent<T>();
            }

            return components;
        }
    }
}