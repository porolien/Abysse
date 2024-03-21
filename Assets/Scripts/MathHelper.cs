using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public static class MathHelper
{
    public static float VectorDistance(Vector3 VectorA, Vector3 VectorB)
    {
        return (float)Math.Sqrt(Mathf.Pow(VectorA.x - VectorB.x, 2) + Mathf.Pow(VectorA.y - VectorB.y, 2));
    }
    public static float DotProduct(Vector3 VectorA, Vector3 VectorB)
    {
        return (VectorA.x * VectorB.x + VectorA.y * VectorB.y + VectorA.z * VectorB.z);
    }
    public static Vector3 CrossProduct(Vector3 VectorA, Vector3 VectorB)
    {
        return new Vector3(VectorA.y * VectorB.z - VectorA.z * VectorB.y,
                           VectorA.z * VectorB.x - VectorA.x * VectorB.z,
                           VectorA.x * VectorB.y - VectorA.z * VectorB.x);
    }
    public static float AngleBetween(Vector3 VectorA, Vector3 VectorB)
    {
        //Suite aux tests le r�sultat de cette m�thode n'�tait pas coh�rente par rapport � la m�thode Vector3.Angle, j'ai v�rifi� sur diff�rent site si le calcul �tait le bon. 
        //Sur les sites le calcul �tait bon, j'ai demand� � CHATGPT pour voir pourquoi le r�sultat n'est pas coh�rent. Il m'a dit que mon r�sultat �tait en radiant.
        return (Mathf.Acos(DotProduct(VectorA, VectorB) / (VectorA.magnitude * VectorB.magnitude))) * (180.0f / Mathf.PI);
    }
}
