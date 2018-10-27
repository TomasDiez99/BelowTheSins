using UnityEngine;

namespace Tools
{
    public static class VectorsStuff
    {
        public static Vector3 GoTo(this Vector3 self, Vector3 other)
        {
            return other - self;
        }
        public static Vector2 GoTo(this Vector2 self, Vector2 other)
        {
            return other - self;
        }
        /// <summary>
        /// will rotate the vector clockwise the angle range is [-2,2] 2 for an entire turn clockwise (2 pi) and -2 for an entire turn anti-clockwise (-2pi)
        /// </summary>
        /// <param name="self"> angle [-1,1] </param>
        /// <param name="angle"></param>
        public static Vector2 Rotate(this Vector2 self, float angle)
        {
            /*
             x' = x cos a - y sen a
             y' = x sen a + y cos a
             */
            float a = Mathf.PI * angle ;
            return new Vector2(self.x * Mathf.Cos(a)  - self.y * Mathf.Sin(a) , self.x * Mathf.Sin(a) + self.y * Mathf.Cos(a));            
        }

        

        public static bool Near(this Vector2 self, Vector2 other ,float maxdelta)
        {
            return Vector2.Distance(self,other) <= maxdelta;
        }
        public static bool Near(this Vector3 self, Vector3 other, float maxdelta)
        {
            return Vector3.Distance(self, other) <= maxdelta;
        }

        public static Vector2 MiddlePoint(this Vector2 self, Vector2 other)
        {
            return (self + other) * 0.5f;
        }

        public static Vector3 MiddlePoint(this Vector3 self, Vector3 other)
        {
            return (self + other) * 0.5f;
        }

        public static Vector2 ScreenToWorld(this Vector2 v)
        {
            return Camera.main.ScreenToWorldPoint(v);
        }
        public static Vector3 ScreenToWorld(this Vector3 v)
        {
            return Camera.main.ScreenToWorldPoint(v);
        }

    }
}
