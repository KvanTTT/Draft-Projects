using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CenterOfMass
{
    public partial class Form1 : Form
    {
        private static readonly Color CutterColor = Color.RoyalBlue;
        private static readonly Color BckColor = Color.FromArgb(232, 253, 210);

        private Bitmap B;
        private Graphics G;
        private List<PointD> Polygon;
        private bool PBuild = false;
        private List<PointD> Points = new List<PointD>();
        int Conv, SelfIntersect;
        double S;

        public struct PointD
        {
            public double X, Y;

            public PointD(double x, double y)
            {
                X = x;
                Y = y;
            }

            public static implicit operator System.Drawing.PointF(PointD P)
            {
                return new System.Drawing.PointF((float)P.X, (float)P.Y);
            }

            public static implicit operator System.Drawing.Point(PointD P)
            {
                return new System.Drawing.Point((int)P.X, (int)P.Y);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public bool PolygonParams(List<PointD> Polygon, out double S, out int Conv, out int SelfIntersect)
        {
            S = 0;
            Conv = 0;
            SelfIntersect = 0;
            if (Polygon.Count < 3)
                return false;
            else
            {
                S = DSquare(Polygon);
                Conv = Convex(Polygon);
                SelfIntersect = SelfIntersection(Polygon);
                return true;
            }
        }

        double Distance(PointD P1, PointD P2)
        {
            double t1 = P2.X - P1.X;
            double t2 = P2.Y - P1.Y;
            return Math.Sqrt(t1 * t1 + t2 * t2);
        }

        double DistanceSqr(PointD P1, PointD P2)
        {
            double t1 = P2.X - P1.X;
            double t2 = P2.Y - P1.Y;
            return t1 * t1 + t2 * t2;
        }

        double PMSquare(PointD P1, PointD P2)
        {
            return (P2.X * P1.Y - P1.X * P2.Y);
        }

        double PMSquare(PointD P1, PointD P2, PointD P3)
        {
            return ((P3.X - P1.X) * (P2.Y - P1.Y) - (P2.X - P1.X) * (P3.Y - P1.Y));
        }

        int LineIntersect(PointD A1, PointD A2, PointD B1, PointD B2, ref PointD O)
        {
            double a1 = A2.Y - A1.Y;
            double b1 = A1.X - A2.X;
            double d1 = -a1 * A1.X - b1 * A1.Y;
            double a2 = B2.Y - B1.Y;
            double b2 = B1.X - B2.X;
            double d2 = -a2 * B1.X - b2 * B1.Y;
            double t = a2 * b1 - a1 * b2;

            if (t == 0)
                return -1;

            O.Y = (a1 * d2 - a2 * d1) / t;
            O.X = (b2 * d1 - b1 * d2) / t;

            if (A1.X > A2.X)
            {
                if ((O.X < A2.X) || (O.X > A1.X))
                    return 0;
            }
            else
            {
                if ((O.X < A1.X) || (O.X > A2.X))
                    return 0;
            }

            if (A1.Y > A2.Y)
            {
                if ((O.Y < A2.Y) || (O.Y > A1.Y))
                    return 0;
            }
            else
            {
                if ((O.Y < A1.Y) || (O.Y > A2.Y))
                    return 0;
            }

            if (B1.X > B2.X)
            {
                if ((O.X < B2.X) || (O.X > B1.X))
                    return 0;
            }
            else
            {
                if ((O.X < B1.X) || (O.X > B2.X))
                    return 0;
            }

            if (B1.Y > B2.Y)
            {
                if ((O.Y < B2.Y) || (O.Y > B1.Y))
                    return 0;
            }
            else
            {
                if ((O.Y < B1.Y) || (O.Y > B2.Y))
                    return 0;
            }

            return 1;
        }
        bool LineIntersectParam(PointD A1, PointD A2, PointD B1, PointD B2, ref PointD O)
        {
            double k11 = A2.X - A1.X;
            double k12 = A2.Y - A1.Y;
            double k21 = B2.X - B1.X;
            double k22 = B2.Y - B1.Y;
            double dx = B1.X - A1.X;
            double dy = A1.Y - B1.Y;

            double d = 1/(k22 * k11 - k21 * k12);

            double t1 = (k22 * dx + k21 * dy) * d;
            if ((t1 < 0) || (t1 > 1))
                return false;

            double t2 = (k12 * dx + k11 * dy) * d;
            if ((t2 < 0) || (t2 > 1))
                return false;

            O.X = A1.X + k11 * t1;
            O.Y = A1.Y + k12 * t1;
            return true;
        }

        double DSquare(List<PointD> Polygon)
        {
            double S = 0;
            if (Polygon.Count >= 3)
            {
                for (int i = 0; i < Polygon.Count - 1; i++)
                    S += PMSquare((PointD)Polygon[i], (PointD)Polygon[i + 1]);
                S += PMSquare((PointD)Polygon[Polygon.Count - 1], (PointD)Polygon[0]);
            }
            return S;
        }

        int SelfIntersection(List<PointD> Polygon)
        {
            if (Polygon.Count < 3)
                return 0;
            int High = Polygon.Count - 1;
            PointD O = new PointD();
            int i;
            for (i = 0; i < High; i++)
            {
                for (int j = i + 2; j < High; j++)
                {
                    if (LineIntersect(Polygon[i], Polygon[i + 1],
                                      Polygon[j], Polygon[j + 1], ref O) == 1)
                        return 1;
                }
            }
            for (i = 1; i < High - 1; i++)
                if (LineIntersect(Polygon[i], Polygon[i + 1], Polygon[High], Polygon[0], ref O) == 1)
                    return 1;
            return -1;
        }

        int PointInPolygon(PointD P, List<PointD> Polygon)
        {
            double S1;
            if (DSquare(Polygon) > 0)
            {
                for (int i = 0; i < Polygon.Count - 1; i++)
                {
                    S1 = PMSquare(Polygon[i], Polygon[i + 1], P);
                    if (S1 < 0)
                        return -1;
                    else
                        if (S1 == 0)
                            return 0;
                }
                S1 = PMSquare(Polygon[Polygon.Count - 1], Polygon[0], P);
                if (S1 < 0)
                    return -1;
                else
                    if (S1 == 0)
                        return 0;
            }
            else
            {
                for (int i = 0; i < Polygon.Count - 1; i++)
                {
                    S1 = PMSquare(Polygon[i], Polygon[i + 1], P);
                    if (S1 > 0)
                        return -1;
                    else
                        if (S1 == 0)
                            return 0;
                }
                S1 = PMSquare(Polygon[Polygon.Count - 1], Polygon[0], P);
                if (S1 > 0)
                    return -1;
                else
                    if (S1 == 0)
                        return 0;
            }
            return 1;
        }

        int Convex(List<PointD> Polygon)
        {
            if (Polygon.Count >= 3)
            {
                if (DSquare(Polygon) > 0)
                {
                    for (int i = 0; i < Polygon.Count - 2; i++)
                        if (PMSquare(Polygon[i], Polygon[i + 1], Polygon[i + 2]) < 0)
                            return -1;
                    if (PMSquare(Polygon[Polygon.Count - 2], Polygon[Polygon.Count - 1], Polygon[0]) < 0)
                        return -1;
                    if (PMSquare(Polygon[Polygon.Count - 1], Polygon[0], Polygon[1]) < 0)
                        return -1;
                }
                else
                {
                    for (int i = 0; i < Polygon.Count - 2; i++)
                        if (PMSquare(Polygon[i], Polygon[i + 1], Polygon[i + 2]) > 0)
                            return -1;
                    if (PMSquare(Polygon[Polygon.Count - 2], Polygon[Polygon.Count - 1], Polygon[0]) > 0)
                        return -1;
                    if (PMSquare(Polygon[Polygon.Count - 1], Polygon[0], Polygon[1]) > 0)
                        return -1;
                }
                return 1;
            }
            return 0;

        }

        double CrossProduct(PointD P1, PointD P2)
        {
            return (P1.X * P2.X + P1.Y * P2.Y);
        }

        double NormSqr(PointD V)
        {
            return (V.X * V.X + V.Y * V.Y);
        }

        double Norm(PointD V)
        {
            return (double)Math.Sqrt(V.X * V.X + V.Y * V.Y);
        }

        double Cos(List<PointD> Polygon, int CenterInd, int V1Ind, int V2Ind)
        {
            PointD A = new PointD(((PointD)Polygon[V1Ind]).X - ((PointD)Polygon[CenterInd]).X,
                                  ((PointD)Polygon[V1Ind]).Y - ((PointD)Polygon[CenterInd]).Y);
            PointD B = new PointD(((PointD)Polygon[V2Ind]).X - ((PointD)Polygon[CenterInd]).X,
                                  ((PointD)Polygon[V2Ind]).Y - ((PointD)Polygon[CenterInd]).Y);
            return (CrossProduct(A, B) / (double)Math.Sqrt(NormSqr(A) * NormSqr(B)));
        }

        bool Intersect(List<PointD> Polygon, int Vertex1Ind, int Vertex2Ind, int Vertex3Ind)
        {
            double S1, S2, S3;
            for (int i = 0; i < Polygon.Count; i++)
            {
                if ((i == Vertex1Ind) || (i == Vertex2Ind) || (i == Vertex3Ind))
                    continue;
                S1 = PMSquare(Polygon[Vertex1Ind], Polygon[Vertex2Ind], Polygon[i]);
                S2 = PMSquare(Polygon[Vertex2Ind], Polygon[Vertex3Ind], Polygon[i]);
                if (((S1 < 0) && (S2 > 0)) || ((S1 > 0) && (S2 < 0)))
                    continue;
                S3 = PMSquare(Polygon[Vertex3Ind], Polygon[Vertex1Ind], Polygon[i]);
                if (((S3 >= 0) && (S2 >= 0)) || ((S3 <= 0) && (S2 <= 0)))
                    return true;
            }
            return false;
        }

        PointD VertexCenterOfMass(List<PointD> Polygon)
        {
            PointD Result = new PointD();
            for (int i = 0; i < Polygon.Count; i++)
            {
                Result.X += Polygon[i].X;
                Result.Y += Polygon[i].Y;
            }
            Result.X /= Polygon.Count;
            Result.Y /= Polygon.Count;

            return Result;
        }

        PointD EdgeCenterOfMass(List<PointD> Polygon)
        {
            PointD Result = new PointD();
            double Perim = 0;
            double L;
            for (int i = 0; i < Polygon.Count - 1; i++)
            {
                L = Distance(Polygon[i], Polygon[i + 1]);
                Result.X += (Polygon[i].X + Polygon[i + 1].X) * 0.5 * L;
                Result.Y += (Polygon[i].Y + Polygon[i + 1].Y) * 0.5 * L;
                Perim += L;
            }
            L = Distance(Polygon[Polygon.Count - 1], Polygon[0]);
            Result.X += (Polygon[Polygon.Count - 1].X + Polygon[0].X) * 0.5 * L;
            Result.Y += (Polygon[Polygon.Count - 1].Y + Polygon[0].Y) * 0.5 * L;
            Perim += L;

            Result.X /= Perim;
            Result.Y /= Perim;

            return Result;
        }

        void SquareMassInertion(PointD P1, PointD P2, PointD P3, double Density, out double Square, out double Mass, out double Inertion)
        {
            double S = PMSquare(P1, P2, P3);
            Square = 0.5 * S;
            Mass = Math.Abs(Square) * Density;
            Inertion = 0.013888888888888888888888888888889 * (P1.X * P1.X + P1.Y * P1.Y + P2.X * P2.X + P2.Y * P2.Y + P3.X * P3.X + P3.Y * P3.Y +
                -P1.X * P2.X - P1.X * P3.X - P2.X * P3.X - P1.Y * P2.Y - P1.Y * P3.Y - P2.Y * P3.Y) * S * S * Density;
        }

        struct Triangle
        {
            public PointD P1;
            public PointD P2;
            public PointD P3;

            public Triangle(PointD p1, PointD p2, PointD p3)
            {
                P1 = p1;
                P2 = p2;
                P3 = p3;
            }
        }

        struct AdvTriangle
        {
            public double Square;
            public PointD CM;
            public PointD P1;
            public PointD P2;
            public PointD P3;

            public AdvTriangle(PointD p1, PointD p2, PointD p3)
            {
                P1 = p1;
                P2 = p2;
                P3 = p3;
                CM = new PointD((P1.X + P2.X + P3.X) * 0.333333333333333333333333333, (P1.Y + P2.Y + P3.Y) * 0.333333333333333333333333333);
                Square = Math.Abs((P3.X - P1.X) * (P2.Y - P1.Y) - (P2.X - P1.X) * (P3.Y - P1.Y))*0.5;
            }
        }

        PointD FaceCenterOfMass(List<PointD> Polygon)
        {
            PointD CM = new PointD(0, 0);
            double M;
            double Sum = 0;
            for (int i = 0; i < Polygon.Count - 1; i++)
            {
                M = Polygon[i].X * Polygon[i + 1].Y - Polygon[i].Y * Polygon[i + 1].X;
                CM.X += M * (Polygon[i].X + Polygon[i + 1].X) / 3;
                CM.Y += M * (Polygon[i].Y + Polygon[i + 1].Y) / 3;
                Sum += M;
            }
            M = (Polygon[Polygon.Count - 1].X * Polygon[0].Y - Polygon[Polygon.Count - 1].Y * Polygon[0].X);
            CM.X += M * (Polygon[Polygon.Count - 1].X + Polygon[0].X) / 3;
            CM.Y += M * (Polygon[Polygon.Count - 1].Y + Polygon[0].Y) / 3;
            Sum += M;
            CM.X /= (2*Sum);
            CM.Y /= (2*Sum);
            return CM;
        }

        PointD FaceCenterOfMass(List<PointD> Polygon, double Density, out double Square, out double Mass, out double Inertion)
        {
            List<PointD> TempPolygon = new List<PointD>(Polygon);
            List<AdvTriangle> Triangles = new List<AdvTriangle>();

            int begin_ind = 0;
            int cur_ind;
            int N = Polygon.Count;
            int Range;
            int Count = 0;

            PointD Result = new PointD(0,0);
            
            Square = 0;
            Mass = 0;
            int TC;

            Pen pConvPolygon = new Pen(CutterColor);
            pConvPolygon.Color = Color.FromArgb(pConvPolygon.Color.R + (BckColor.R - pConvPolygon.Color.R) / 2,
                                                pConvPolygon.Color.G + (BckColor.G - pConvPolygon.Color.G) / 2,
                                                pConvPolygon.Color.B + (BckColor.B - pConvPolygon.Color.B) / 2);

            double DS = DSquare(TempPolygon);
            Square = 0.5 * DS;    
            Mass = Math.Abs(Square) * Density;
            if (Square < 0)
            {
                TempPolygon.Reverse();
                DS = -DS;
            }

            while (N >= 3)
            {
                while ((PMSquare(TempPolygon[begin_ind], TempPolygon[(begin_ind + 1) % N],
                          TempPolygon[(begin_ind + 2) % N]) < 0) ||
                          (Intersect(TempPolygon, begin_ind, (begin_ind + 1) % N, (begin_ind + 2) % N) == true))
                {
                    begin_ind++;
                    begin_ind %= N;
                }
                cur_ind = (begin_ind + 1) % N;
                Triangles.Add(new AdvTriangle(TempPolygon[begin_ind], TempPolygon[cur_ind], TempPolygon[(begin_ind + 2) % N]));

                Range = cur_ind - begin_ind;
                if (Range > 0)
                {
                    TempPolygon.RemoveRange(begin_ind + 1, Range);
                }
                else
                {
                    TempPolygon.RemoveRange(begin_ind + 1, N - begin_ind - 1);
                    TempPolygon.RemoveRange(0, cur_ind + 1);
                }
                N = TempPolygon.Count;
                begin_ind++;
                begin_ind %= N;

                TC = Triangles.Count - 1;                
                Result.X += (Triangles[TC].CM.X * Triangles[TC].Square);
                Result.Y += (Triangles[TC].CM.Y * Triangles[TC].Square);
                Count++;

                if (checkBox1.Checked == true)
                {
                    G.DrawLine(pConvPolygon, Triangles[Triangles.Count - 1].P1, Triangles[Triangles.Count - 1].P2);
                    G.DrawLine(pConvPolygon, Triangles[Triangles.Count - 1].P2, Triangles[Triangles.Count - 1].P3);
                    G.DrawLine(pConvPolygon, Triangles[Triangles.Count - 1].P1, Triangles[Triangles.Count - 1].P3);
                }
            }

            Result.X /= Math.Abs(Square * Density);
            Result.Y /= Math.Abs(Square * Density);            

            Inertion = 0;
            for (int i = 0; i < Triangles.Count; i++)
            {
                Inertion += Triangles[i].Square * (
                    /*0.037037037037037037037037037037037 *
                    (DistanceSqr(Triangles[i].P1, new PointD((Triangles[i].P2.X + Triangles[i].P3.X) * 0.5f, (Triangles[i].P2.Y + Triangles[i].P3.Y) * 0.5f)) +
                     DistanceSqr(Triangles[i].P2, new PointD((Triangles[i].P1.X + Triangles[i].P3.X) * 0.5f, (Triangles[i].P1.Y + Triangles[i].P3.Y) * 0.5f)) +
                     DistanceSqr(Triangles[i].P3, new PointD((Triangles[i].P1.X + Triangles[i].P2.X) * 0.5f, (Triangles[i].P1.Y + Triangles[i].P2.Y) * 0.5f))));*/

                      0.055555555555555555555555555555556 *
                    (Triangles[i].P1.X * Triangles[i].P1.X + Triangles[i].P2.X * Triangles[i].P2.X + Triangles[i].P3.X * Triangles[i].P3.X + 
                     Triangles[i].P1.Y * Triangles[i].P1.Y + Triangles[i].P2.Y * Triangles[i].P2.Y + Triangles[i].P3.Y * Triangles[i].P3.Y -
                     Triangles[i].P1.X * Triangles[i].P2.X - Triangles[i].P1.X * Triangles[i].P3.X - Triangles[i].P2.X * Triangles[i].P3.X -
                     Triangles[i].P1.Y * Triangles[i].P2.Y - Triangles[i].P1.Y * Triangles[i].P3.Y - Triangles[i].P2.Y * Triangles[i].P3.Y
                     - DistanceSqr(Triangles[i].CM, Result)));
            }
            Inertion = Inertion * Density/* * 0.5*/;
            double CircleMass = Math.PI * DistanceSqr(Result, Polygon[0]) * Density;
            double CircleInertion = CircleMass * DistanceSqr(Result, Polygon[0]) * 0.5;
            tbCircle.Text = Convert.ToString(CircleInertion);
            tbInert2.Text = Convert.ToString(CircleMass);
            tbCount.Text = Convert.ToString(Count);

            Triangles.Clear();

            TempPolygon.Clear();
            return Result;
        }

        bool HorizIntersec(PointD P1, PointD P2, PointD Line)
        {
            if (P1.Y > P2.Y)
            {
                if ((Line.Y < P2.Y) || (Line.Y > P1.Y))
                    return false;
            }
            else
            {
                if ((Line.Y < P1.Y) || (Line.Y > P2.Y))
                    return false;
            }

            double a1 = P2.Y - P1.Y;
            double b1 = P1.X - P2.X;
            double d1 = -a1 * P1.X - b1 * P1.Y;

            double b2 = Line.X;
            double d2 = -b2 * Line.Y;
            double t = -a1 * b2;

            if (t == 0)
                return false;

            double X = (b2 * d1 - b1 * d2) / t;

            if (X > Line.X)
                return false;

            return true;
        }

        int NumberOfIntersec(List<PointD> Polygon, PointD P)
        {
            int result = 0;

            for (int i = 0; i < Polygon.Count - 1; i++)
                if (HorizIntersec(Polygon[i], Polygon[i + 1], P) == true)
                    result++;
            if (HorizIntersec(Polygon[Polygon.Count - 1], Polygon[0], P) == true)
                result++;

            return result;
        }

        private void UpdateAll()
        {
            Brush brush = new SolidBrush(BckColor);
            G.FillRectangle(brush, 0, 0, B.Width, B.Height);

            if (PolygonParams(Polygon, out S, out Conv, out SelfIntersect) == false)
            {
                lblBypass.Text = "---";
                lblConvex.Text = "---";
                lblSelfintersect.Text = "---";
            }
            else
            {
                if (S > 0)
                    lblBypass.Text = "Counterclockwise";
                else
                    if (S < 0)
                    lblBypass.Text = "Clockwise";

                if (Conv > 0)
                    lblConvex.Text = "Yes";
                else
                    if (Conv < 0)
                    lblConvex.Text = "No";

                if (SelfIntersect > 0)
                    lblSelfintersect.Text = "Yes";
                else
                    if (SelfIntersect < 0)
                    lblSelfintersect.Text = "No";
            }

            Pen pCuttingRect = new Pen(CutterColor);
            Brush bCuttingRect = new SolidBrush(pCuttingRect.Color);
            if (Polygon.Count > 0)
                G.FillEllipse(bCuttingRect, (float)Polygon[0].X - 2.5f, (float)Polygon[0].Y - 2.5f, 5, 5);
            if (Polygon.Count > 1)
            {
                PointD VCM = VertexCenterOfMass(Polygon);
                PointD ECM = EdgeCenterOfMass(Polygon);
                G.DrawLine(new Pen(Color.Red), (float)VCM.X - 5, (float)VCM.Y, (float)VCM.X + 5, (float)VCM.Y);
                G.DrawLine(new Pen(Color.Red), (float)VCM.X, (float)VCM.Y - 5, (float)VCM.X, (float)VCM.Y + 5);
                G.DrawString("VertexCenterOfMass", new Font(label1.Font, FontStyle.Regular), Brushes.Red, VCM);
                G.DrawLine(new Pen(Color.IndianRed), (float)ECM.X - 5, (float)ECM.Y, (float)ECM.X + 5, (float)ECM.Y);
                G.DrawLine(new Pen(Color.IndianRed), (float)ECM.X, (float)ECM.Y - 5, (float)ECM.X, (float)ECM.Y + 5);
                G.DrawString("EdgeCenterOfMass", new Font(label1.Font, FontStyle.Regular), Brushes.IndianRed,
                    new PointD((double)ECM.X - G.MeasureString("EdgeCenterOfMass", label1.Font).Width, (double)ECM.Y));
                if (SelfIntersect < 0)
                {
                    double Square, Mass, Inertion;
                    PointD FCM = FaceCenterOfMass(Polygon, Convert.ToDouble(tbDensity.Text), out Square, out Mass, out Inertion);
                    tbSquare.Text = Convert.ToString(Square);
                    tbMass.Text = Convert.ToString(Mass);
                    tbInertion.Text = Convert.ToString(Inertion);
                    G.DrawLine(new Pen(Color.Indigo), (float)FCM.X - 5, (float)FCM.Y, (float)FCM.X + 5, (float)FCM.Y);
                    G.DrawLine(new Pen(Color.Indigo), (float)FCM.X, (float)FCM.Y - 5, (float)FCM.X, (float)FCM.Y + 5);
                    G.DrawString("FaceCenterOfMass", new Font(label1.Font, FontStyle.Regular), Brushes.Indigo, new PointD((double)FCM.X, (double)FCM.Y - 10));
                }
            }

            pictBox.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            B = new Bitmap(pictBox.ClientSize.Width, pictBox.ClientSize.Height);
            pictBox.Image = B;
            G = Graphics.FromImage(B);
            Polygon = new List<PointD>();

            btnUpdate_Click(null, null);
        }

        private void pictBox_MouseUp_1(object sender, MouseEventArgs e)
        {
                PointD P = new PointD(e.X, e.Y);
                if (e.Button == MouseButtons.Left)
                {
                    if (PBuild == false)
                    {
                        Polygon.Clear();
                        PBuild = true;
                    }
                    else
                    {
                        if (IsShiftDown() == true)
                        {
                            PointD PT = new PointD();
                            PT = Polygon[Polygon.Count - 1];
                            if (Math.Abs(e.X - PT.X) < Math.Abs(e.Y - PT.Y))
                            {
                                P.X = PT.X;
                                P.Y = e.Y;
                            }
                            else
                            {
                                P.X = e.X;
                                P.Y = PT.Y;
                            }
                        }
                    }
                    Polygon.Add(P);
                }
                else
                    if (e.Button == MouseButtons.Right)
                    {
                        PBuild = false;
                    }
                UpdateAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Brush brush = new SolidBrush(BckColor);
            G.FillRectangle(brush, 0, 0, B.Width, B.Height);
            pictBox.Refresh();
        }

        private void tbYb_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar != (char)8) && ((e.KeyChar < '0') || (e.KeyChar > '9')))
                e.KeyChar = (char)0;
        }

        const int VK_SHIFT = 16;
        const int VK_CTRL = 17;
        const ushort MASK = 0x8000;

        [DllImport("User32.dll")]
        static extern short GetKeyState(int nVirtKey);

        public static bool IsShiftDown()
        {
            return ((GetKeyState(VK_SHIFT) & MASK) > 0);
        }

        public static bool IsCtrlDown()
        {
            return ((GetKeyState(VK_CTRL) & MASK) > 0);
        }

        private void pnlCuttingLine_MouseUp(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                (sender as Panel).BackColor = colorDialog1.Color;
                UpdateAll();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void tbYb_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)8) && ((e.KeyChar < '0') || (e.KeyChar > '9')))
                e.KeyChar = (char)0;
        }

        private void dgvPolygon_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Polygon.RemoveAt(e.RowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Polygon.Clear();
            UpdateAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Points.Clear();
            UpdateAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Polygon.Clear();
            PointD P = new PointD();
            Random R = new Random();

            int X, Y;
            P.X = R.Next(0, pictBox.Width);
            P.Y = R.Next(0, pictBox.Height);
            Polygon.Add(P);
            X = (int)((PointD)Polygon[Polygon.Count - 1]).X;
            Y = (int)((PointD)Polygon[Polygon.Count - 1]).Y;
            P.X = R.Next(X - pictBox.Width / 16, (int)(X + pictBox.Width / 16));
            P.Y = R.Next(Y - pictBox.Height / 16, (int)(Y + pictBox.Height / 16));
            P.X = R.Next(0, pictBox.Width);
            P.Y = R.Next(0, pictBox.Height);
            Polygon.Add(P);

            for (int i = 2; i < edtEdgesCount.Value; i++)
            {
                P.X = R.Next(0, pictBox.Width);
                P.Y = R.Next(0, pictBox.Height);
                Polygon.Add(P);
                if (cbConvex.Checked == true)
                {
                    while ((Convex(Polygon) <= 0) || (SelfIntersection(Polygon) == 1))
                    {
                        Polygon.RemoveAt(Polygon.Count - 1);
                        P.X = R.Next(0, pictBox.Width);
                        P.Y = R.Next(0, pictBox.Height);
                        Polygon.Add(P);
                    }
                }
                else
                    while (SelfIntersection(Polygon) == 1)
                    {
                        Polygon.RemoveAt(Polygon.Count - 1);
                        P.X = R.Next(0, pictBox.Width);
                        P.Y = R.Next(0, pictBox.Height);
                        Polygon.Add(P);
                    }
            }
            UpdateAll();
        }

        private void cbTriag_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void rbInterlace_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAll();
        }

        double CalculateMass(PointD[] A, double density)
        {
            if (A.Length < 2)
                return 5.0 * density;

            double mass = 0.0;

            for (int j = A.Length - 1, i = 0; i < A.Length; j = i, i++)
            {
                PointD P0 = A[j];
                PointD P1 = A[i];
                mass += (double)Math.Abs(P0.X * P1.Y - P0.Y * P1.X);
            }
            if (A.Length <= 2)
                mass = 10.0;

            mass *= density * 0.5;

            return mass;
        }

        double CalculateInertia(PointD[] A, double mass)
        {
            if (A.Length == 1) return 0.0;

            double denom = 0.0;
            double numer = 0.0;

            for (int j = A.Length - 1, i = 0; i < A.Length; j = i, i++)
            {
                PointD P0 = A[j];
                PointD P1 = A[i];

                double a = (double)Math.Abs(P0.X * P1.Y - P0.Y * P1.X);
                double b = (P1.X * P1.X + P1.Y * P1.Y + P1.X * P0.X + P1.Y * P0.Y + P0.X * P0.X + P0.Y * P0.Y);

                denom += (a * b);
                numer += a;
            }
            double inertia = (mass / 6.0) * (denom / numer);

            return inertia;
        }

        double CalculateInertia(PointD[] A, PointD Center, double mass)
        {
            if (A.Length == 1) return 0.0;

            double denom = 0.0f;
            double numer = 0.0f;

            for (int j = A.Length - 1, i = 0; i < A.Length; j = i, i++)
            {
                PointD P0 = A[j];
                PointD P1 = A[i];

                double a = (double)Math.Abs(P0.X * P1.Y - P0.Y * P1.X);
                double b = (P1.X * P1.X + P1.Y * P1.Y + P1.X * P0.X + P1.Y * P0.Y + P0.X * P0.X + P0.Y * P0.Y);

                denom += (a * b);
                numer += a;
            }
            double inertia = (mass / 6.0f) * (denom / numer) - (Center.X * Center.X + Center.Y * Center.Y) * mass;

            return inertia;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Polygon.Clear();
            PointD O = new PointD(pictBox.Width / 2, pictBox.Height / 2);
            int N = 1000;
            double R = 30;
            double A =   Math.PI;
            double Step = A / N;
            double Ang = 0;
            for (int i = 0; i <= N; i++)
            {
                Polygon.Add(new PointD(O.X + (R * Math.Cos(Ang)), O.Y + (R * Math.Sin(Ang))));
                Ang += Step;
            }

            Polygon.Add(new PointD(O.X - R, O.Y - R));
            Polygon.Add(new PointD(O.X + R, O.Y - R));

            PBuild = false;
            UpdateAll();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Polygon.Clear();
            Random R = new Random();
            PointD O = new PointD(R.Next(0, pictBox.Width - 100), R.Next(0, pictBox.Height - 100));
            Polygon.Add(O);
            Polygon.Add(new PointD(O.X + 10, O.Y));
            Polygon.Add(new PointD(O.X + 10, O.Y + 10));
            Polygon.Add(new PointD(O.X, O.Y + 10));
            UpdateAll();
        }
    }
}