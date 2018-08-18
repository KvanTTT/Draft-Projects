using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace EjectionGame
{
    // нет ни одного цикла для лучшей производительности (теоретически)
    class FloatMatrix
    {
        protected float[] data;
    }

    // используется для геометрических преобразований (т.к. последний столбец в них не используется,
    // поэтому получается быстрее
    class Matrix43f : FloatMatrix
    {
        public Matrix43f()
        {
            data = new float[6];
        }

        public Matrix43f(bool Identity)
        {
            data = new float[6];
            if (Identity)
            {
                data[0] = 1;
                data[4] = 1;
            }
        }

        public void MakeIdentity()
        {
            data[0] = 1; data[1] = 0; data[2] = 0;
            data[3] = 0; data[4] = 1; data[5] = 0;
        }

        public void MakeZero()
        {
            data[0] = 0; data[1] = 0; data[2] = 0;
            data[3] = 0; data[4] = 0; data[5] = 0;
        }

        public float Determinant()
        {
            return data[0] * data[4] - data[1] * data[3];
        }

        public void AddTranslation(Vector2 Displacement)
        {
            data[2] += Displacement.X;
            data[5] += Displacement.Y;
        }

        public void AddScaling(Vector2 ScaleCoef)
        {
            data[0] *= ScaleCoef.X; data[1] *= ScaleCoef.X; data[2] *= ScaleCoef.X;
            data[3] *= ScaleCoef.Y; data[4] *= ScaleCoef.Y; data[5] *= ScaleCoef.Y;
        }

        public void AddScaling(Vector2 ScaleCoef, Vector2 Point)
        {
            data[0] *= ScaleCoef.X;
            data[1] *= ScaleCoef.X;
            data[2] = data[2] * ScaleCoef.X + Point.X * (1 - ScaleCoef.X);
            data[3] *= ScaleCoef.Y;
            data[4] *= ScaleCoef.Y;
            data[5] = data[5] * ScaleCoef.Y + Point.Y * (1 - ScaleCoef.Y);
        }

        public void Set(Vector2 Row1, Vector2 Row2, Vector2 Column)
        {
            data[0] = Row1.X; data[1] = Row1.Y; data[3] = Column.X;
            data[4] = Row2.X; data[5] = Row2.Y; data[6] = Column.Y;
        }

        public void AddRotationZ(float angle)
        {
            float sina = (float)Math.Sin(angle);
            float cosa = (float)Math.Cos(angle);
            float t;

            t = data[0];
            data[0] = t * cosa - data[2] * sina;
            data[2] = data[2] * cosa + t * sina;
            t = data[1];
            data[1] = t * cosa - data[4] * sina;
            data[4] = data[4] * cosa + t * sina;
            t = data[2];
            data[2] = t * cosa - data[5] * sina;
            data[5] = data[5] * cosa + t * sina;
        }

        public static Matrix43f operator +(Matrix43f M1, Matrix43f M2)
        {
            Matrix43f Result = new Matrix43f(false);
            Result.data[0] = M1.data[0] + M2.data[0]; 
            Result.data[1] = M1.data[1] + M2.data[1]; 
            Result.data[2] = M1.data[2] + M2.data[2];
            Result.data[3] = M1.data[3] + M2.data[3]; 
            Result.data[4] = M1.data[4] + M2.data[4]; 
            Result.data[5] = M1.data[5] + M2.data[5];
            return Result;
        }

        public static Matrix43f operator -(Matrix43f M1, Matrix43f M2)
        {
            Matrix43f Result = new Matrix43f(false);
            Result.data[0] = M1.data[0] - M2.data[0];
            Result.data[1] = M1.data[1] - M2.data[1];
            Result.data[2] = M1.data[2] - M2.data[2];
            Result.data[3] = M1.data[3] - M2.data[3];
            Result.data[4] = M1.data[4] - M2.data[4];
            Result.data[5] = M1.data[5] - M2.data[5];
            return Result;
        }

        public static Matrix43f operator *(Matrix43f M1, Matrix43f M2)
        {
            Matrix43f Result = new Matrix43f(false);
            Result.data[0] = M1.data[0] * M2.data[0] + M1.data[1] * M2.data[4] + M1.data[2] * M2.data[8];
            Result.data[1] = M1.data[0] * M2.data[1] + M1.data[1] * M2.data[5] + M1.data[2] * M2.data[9];
            Result.data[2] = M1.data[0] * M2.data[2] + M1.data[1] * M2.data[6] + M1.data[2] * M2.data[10];
            Result.data[3] = M1.data[0] * M2.data[3] + M1.data[1] * M2.data[7] + M1.data[2] * M2.data[11] + M1.data[3];

            Result.data[4] = M1.data[4] * M2.data[0] + M1.data[5] * M2.data[4] + M1.data[6] * M2.data[8];
            Result.data[5] = M1.data[4] * M2.data[1] + M1.data[5] * M2.data[5] + M1.data[6] * M2.data[9];
            Result.data[6] = M1.data[4] * M2.data[2] + M1.data[5] * M2.data[6] + M1.data[6] * M2.data[10];
            Result.data[7] = M1.data[4] * M2.data[3] + M1.data[5] * M2.data[7] + M1.data[6] * M2.data[11] + M1.data[7];

            Result.data[8] = M1.data[8] * M2.data[0] + M1.data[9] * M2.data[4] + M1.data[10] * M2.data[8];
            Result.data[9] = M1.data[8] * M2.data[1] + M1.data[9] * M2.data[5] + M1.data[10] * M2.data[9];
            Result.data[10] = M1.data[8] * M2.data[2] + M1.data[9] * M2.data[6] + M1.data[10] * M2.data[10];
            Result.data[11] = M1.data[8] * M2.data[3] + M1.data[9] * M2.data[7] + M1.data[10] * M2.data[11] + M1.data[11];

            return Result;
        }

        public static Matrix43f operator *(Matrix43f M, float s)
        {
            Matrix43f Result = new Matrix43f(false);
            Result.data[0] = M.data[0] * s;
            Result.data[1] = M.data[1] * s;
            Result.data[2] = M.data[2] * s;
            Result.data[3] = M.data[3] * s;
            Result.data[4] = M.data[4] * s;
            Result.data[5] = M.data[5] * s;
            return Result;
        }

        public static Vector2 operator *(Vector2 V, Matrix43f M)
        {
            Vector2 Result = new Vector2();
            Result.X = M.data[0] * V.X + M.data[1] * V.Y + M.data[2];
            Result.Y = M.data[3] * V.X + M.data[4] * V.Y + M.data[5];
            return Result;
        }

        // умножение, только не учитывая последний столбец
        public static Vector2 operator |(Vector2 V, Matrix43f M)
        {
            Vector2 Result = new Vector2();
            Result.X = M.data[0] * V.X + M.data[1] * V.Y;
            Result.Y = M.data[3] * V.X + M.data[4] * V.Y;
            return Result;
        }

        //обращение матрицы - не доделано
        public static Matrix43f operator !(Matrix43f M)
        {
            Matrix43f Result = new Matrix43f(false);
            float a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11;
            float OneDivDet = 1 / M.Determinant();

            a0 = M.data[0]; a1 = M.data[1]; a2 = M.data[2]; a3 = M.data[3];
            a4 = M.data[4]; a5 = M.data[5]; a6 = M.data[6]; a7 = M.data[7];
            a8 = M.data[8]; a9 = M.data[9]; a10 = M.data[10]; a11 = M.data[11];

            Result *= OneDivDet;
            return Result;
        }
    }
}
