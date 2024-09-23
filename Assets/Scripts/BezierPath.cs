using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPath
{
   public static Vector2 EvalQuadratic(Vector2 a, Vector2 b, Vector2 c, float t)
   {
      Vector2 P0 = Vector2.Lerp(a, b, t);
      Vector2 P1 = Vector2.Lerp(b, c, t);
      return Vector2.Lerp(P0, P1, t);
   }

   public static Vector2 EvalCubic(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
   {
      
   }
}
