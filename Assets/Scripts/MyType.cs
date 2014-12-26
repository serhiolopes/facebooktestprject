using UnityEngine;
using System.Collections;
using CustomAttributes;


public class MyType : MonoBehaviour
{
    int m_SomeInt;
    float m_SomeFloat;
    bool m_SomeBool;
    string m_Etc;

    [ExposeProperty]
    [ReadOnly]
    public int SomeInt
    {
        get
        {
            return Random.Range(0, 10000);
        }
        set
        {
            m_SomeInt = value;
        }
    }

    [ExposeProperty]
    public float SomeFloat
    {
        get
        {
            return m_SomeFloat;
        }
        set
        {
            m_SomeFloat = value;
        }
    }

    [ExposeProperty]
    public bool SomeBool
    {
        get
        {
            return m_SomeBool;
        }
        set
        {
            m_SomeBool = value;
        }
    }

    
    [ExposeProperty]
    [ReadOnly]
    public string SomeString
    {
        get
        {
            return "4";
        }
        set
        {
            m_Etc = value;
        }
    }
}