using System.Collections.Generic;
using UnityEngine;

namespace UniversalUnityPackage
{
    public static class TransformUtils
    {
        public static Transform[] GetChildren(this Transform parent, bool recursive = false)
        {
            List<Transform> children = new List<Transform>();

            if (!recursive)
            {
                for (int i = 0; i < parent.childCount; i++)
                {
                    children.Add(parent.GetChild(i));
                }
            }
            else
            {
                children.AddRange(parent.GetComponentsInChildren<Transform>());
            }

            return children.ToArray();
        }

        public static T[] GetChildren<T>(this Transform parent, bool recursive = false) where T : Component
        {
            List<T> components = new List<T>();

            Transform[] children = parent.GetChildren(recursive);
            
            foreach (Transform child in children)
            {
                if (child.TryGetComponent(out T component))
                {
                    components.Add(component);
                }
            }

            return components.ToArray();
        }

        public static T GetParent<T>(this Transform transform) where T : Component
        {
            while (true)
            {
                if (transform.TryGetComponent(out T component))
                {
                    return component;
                }

                if (transform.parent == null) return null;
                
                transform = transform.parent;
            }
        }
    }
}