using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Utilities;
using System.Xml.Linq;

namespace Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum ActionType
    {
        Select,
        LineCreate,
        BoxCreate,
        CircleCreate,
        PolygonCreate
    }

    public partial class MainWindow : Window
    {
        List<FloatShape> Bodies = new List<FloatShape>();
        Point P;
        Point TempP;
        bool IsLeftMouseDown = false;
        bool IsShapeCreating = false;

        Rectangle Rectangle = null;
        Ellipse Ellipse = null;
        Polygon Polygon = null;
        Line Line = null;
        int RectangleCounter = 0;
        int EllipseCounter = 0;
        int PolygonCounter = 0;
        int LineCounter = 0;
        
        ActionType ActionType = ActionType.BoxCreate;
        double radius;

        double Distance(Point P1, Point P2)
        {
            return Math.Sqrt((P2.X - P1.X) * (P2.X - P1.X) + (P2.Y - P1.Y) * (P2.Y - P1.Y));
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        void RedrawScene()
        {
            canvasEditor.Children.Clear();
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
            foreach (FloatShape S in Bodies)
            {
                if (S is FloatRect)
                {
                    if (S.Name != "WorldRect")
                    {
                        Rectangle = new Rectangle();
                        Rectangle.Stroke = Brushes.Red;
                        Rectangle.StrokeThickness = 2;
                        Rectangle.Fill = myBrush;
                        Canvas.SetLeft(Rectangle, (S as FloatRect).Left);
                        Canvas.SetTop(Rectangle, (S as FloatRect).Top);
                        Rectangle.Width = (S as FloatRect).Width;
                        Rectangle.Height = (S as FloatRect).Height;
                        canvasEditor.Children.Add(Rectangle);
                    }
                }
                else
                    if (S is FloatCircle)
                    {
                        Ellipse = new Ellipse();
                        Ellipse.Stroke = Brushes.Red;
                        Ellipse.StrokeThickness = 2;
                        Ellipse.Fill = myBrush;
                        Canvas.SetLeft(Ellipse, (S as FloatCircle).X - (S as FloatCircle).Radius);
                        Canvas.SetTop(Ellipse, (S as FloatCircle).Y - (S as FloatCircle).Radius);
                        Ellipse.Width = (S as FloatCircle).Radius * 2;
                        Ellipse.Height = (S as FloatCircle).Radius * 2;
                        canvasEditor.Children.Add(Ellipse);
                    }
                    else
                        if (S is FloatPolygon)
                        {
                            Polygon = new Polygon();
                            Polygon.Stroke = Brushes.Red;
                            Polygon.StrokeThickness = 2;
                            Polygon.Fill = myBrush;
                            Polygon.Points = new PointCollection();
                            Array.ForEach((S as FloatPolygon).Vertexes, Vertex => Polygon.Points.Add(new Point(Vertex.X, Vertex.Y)));
                            canvasEditor.Children.Add(Polygon);
                        }
                        else
                            if (S is FloatLine)
                            {
                                Line = new Line();
                                Line.Stroke = Brushes.Red;
                                Line.StrokeThickness = 2;
                                Line.Fill = myBrush;
                                Line.X1 = (S as FloatLine).X1;
                                Line.Y1 = (S as FloatLine).Y1;
                                Line.X2 = (S as FloatLine).X2;
                                Line.Y2 = (S as FloatLine).Y2;
                                canvasEditor.Children.Add(Line);
                            }

            }
        }

        void ClearScene()
        {
            Rectangle = null;
            Ellipse = null;
            Polygon = null;
            Line = null;
            RectangleCounter = 0;
            EllipseCounter = 0;
            PolygonCounter = 0;
            LineCounter = 0;
            Bodies.Clear();
            RedrawScene();
        }

        private void canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point P = e.GetPosition(canvasEditor);
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (ActionType == Editor.ActionType.BoxCreate)
                {
                    if (!IsShapeCreating)
                    {
                        Rectangle = new Rectangle();
                        Rectangle.Stroke = Brushes.Red;
                        Rectangle.StrokeThickness = 2;
                        Rectangle.Fill = myBrush;
                        Canvas.SetLeft(Rectangle, P.X);
                        Canvas.SetTop(Rectangle, P.Y);
                        canvasEditor.Children.Add(Rectangle);
                        IsShapeCreating = true;
                    }
                    else
                    {
                        Bodies.Add(new FloatRect("Rect" + RectangleCounter++.ToString(), P.X < TempP.X ? P.X : TempP.X, P.Y < TempP.Y ? P.Y : TempP.Y,
                            Math.Abs(P.X - TempP.X), Math.Abs(P.Y - TempP.Y)));
                        Rectangle = null;
                        IsShapeCreating = false;
                    }
                }
                else
                    if (ActionType == Editor.ActionType.CircleCreate)
                    {
                        if (!IsShapeCreating)
                        {
                            Ellipse = new Ellipse();
                            Ellipse.Stroke = Brushes.Red;
                            Ellipse.StrokeThickness = 2;
                            Ellipse.Fill = myBrush;
                            Canvas.SetLeft(Ellipse, P.X);
                            Canvas.SetTop(Ellipse, P.Y);
                            canvasEditor.Children.Add(Ellipse);
                            IsShapeCreating = true;
                        }
                        else
                        {
                            Bodies.Add(new FloatCircle("Circle" + EllipseCounter++.ToString(), TempP.X, TempP.Y, radius));
                            Ellipse = null;
                            IsShapeCreating = false;
                        }
                    }
                    else
                        if (ActionType == Editor.ActionType.PolygonCreate)
                    {
                        if (!IsShapeCreating)
                        {
                            Polygon = new Polygon();
                            Polygon.Stroke = Brushes.Red;
                            Polygon.StrokeThickness = 2;
                            Polygon.Fill = myBrush;
                            Polygon.Points = new PointCollection();
                            Polygon.Points.Add(P);
                            Polygon.Points.Add(P);
                            canvasEditor.Children.Add(Polygon);
                            IsShapeCreating = true;
                        }
                        else
                        {
                            Polygon.Points.Add(P);
                        }
                    }
                        else
                            if (ActionType == Editor.ActionType.LineCreate)
                            {
                                if (!IsShapeCreating)
                                {
                                    Line = new Line();
                                    Line.Stroke = Brushes.Red;
                                    Line.StrokeThickness = 2;
                                    Line.Fill = myBrush;
                                    Line.X1 = P.X;
                                    Line.Y1 = P.Y;
                                    canvasEditor.Children.Add(Line);
                                    IsShapeCreating = true;
                                }
                                else
                                {
                                    Bodies.Add(new FloatLine("Line" + LineCounter++.ToString(), Line.X1, Line.Y1, P.X, P.Y));
                                    Line = null;
                                    IsShapeCreating = false;
                                }
                                    
                            }
                            if (ActionType == Editor.ActionType.Select)
                            {

                            }

            }

            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (Polygon != null)
                {
                    Polygon.Points.RemoveAt(Polygon.Points.Count - 1);
                    Bodies.Add(new FloatPolygon("Polygon" + PolygonCounter++.ToString(), 
                        Array.ConvertAll(Polygon.Points.ToArray(), Point => new FloatPoint(Point.X, Point.Y))));
                    Polygon = null;
                    IsShapeCreating = false;
                }
            }

            IsLeftMouseDown = true;
            TempP = new Point(P.X, P.Y);
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsShapeCreating)
            {
                P = e.GetPosition(canvasEditor);
                if (ActionType == Editor.ActionType.BoxCreate)
                {                    
                    if (P.X < TempP.X)
                        Canvas.SetLeft(Rectangle, P.X);
                    if (P.Y < TempP.Y)
                        Canvas.SetTop(Rectangle, P.Y);
                    Rectangle.Width =  Math.Abs(P.X - TempP.X);
                    Rectangle.Height = Math.Abs(P.Y - TempP.Y);
                }
                else
                    if (ActionType == Editor.ActionType.CircleCreate)
                    {
                        radius = Distance(P, TempP);
                        Canvas.SetLeft(Ellipse, TempP.X - radius);
                        Canvas.SetTop(Ellipse, TempP.Y - radius);
                        Ellipse.Width = radius * 2;
                        Ellipse.Height = Ellipse.Width;
                    }
                    else
                        if (ActionType == Editor.ActionType.PolygonCreate)
                    {
                        if (Polygon != null)
                            Polygon.Points[Polygon.Points.Count - 1] = P;
                    }
                        else
                            if (ActionType == Editor.ActionType.LineCreate)
                            {
                                if (Line != null)
                                {
                                    Line.X2 = P.X;
                                    Line.Y2 = P.Y;
                                }
                            }
            }
        }

        private void canvas1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (IsLeftMouseDown)
            {
                IsLeftMouseDown = false;
                if (ActionType == Editor.ActionType.BoxCreate)
                {
                    
                }
                else
                    if (ActionType == Editor.ActionType.CircleCreate)
                    {
                        
                    }
                    else
                    {

                    }
            }
        }

        void SerializeObject(XmlWriter Writer, Object Obj)
        {
            MemoryStream MS = new MemoryStream();
            XmlSerializer Serializer = new XmlSerializer(Obj.GetType());
            Serializer.Serialize(MS, Obj);
            string str = Encoding.Default.GetString(MS.ToArray());
            str = str.Remove(0, 23);
            int ind = str.IndexOf("xmlns");
            str = str.Remove(ind, str.LastIndexOf(@"XMLSchema") + 12 - ind - 1) + Environment.NewLine;
            Writer.WriteRaw(str);
        }

        void SerializeWorld(string XMLFile)
        {
            XmlWriterSettings Settings = new XmlWriterSettings();
            Settings.Indent = true;
            Settings.IndentChars = "    ";
            XmlWriter Writer = XmlWriter.Create(XMLFile, Settings);
            
            Writer.WriteStartDocument();            
            Writer.WriteStartElement("Bodies");
            Writer.WriteRaw(Environment.NewLine);

            Bodies.ForEach(Body => {Body.Normalize((float)(udRealWidth.Value / udWidth.Value), (float)(udRealHeight.Value / udHeight.Value));
                SerializeObject(Writer, Body); });
            FloatSize S = new FloatSize(udRealWidth.Value, udRealHeight.Value);
            SerializeObject(Writer, S);

            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Close();
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SerializeWorld(@"..\..\..\WindowsPhoneGame1\WindowsPhoneGame1Content\Levels\Level1.xml");

        }
        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
           /* XmlSerializer Serializer = new XmlSerializer(typeof(List<FloatShape>));
            System.Xml.Linq.XDocument Doc = System.Xml.Linq.XDocument.Load(@"..\..\..\WindowsPhoneGame1\WindowsPhoneGame1Content\Levels\Level1.xml");
            System.IO.MemoryStream Stream = new System.IO.MemoryStream();
            Doc.Save(Stream);
            Stream = new MemoryStream(Stream.ToArray(), 3, (int)Stream.Length - 3);
            List<FloatShape> Bodies = (List<FloatShape>)Serializer.Deserialize(Stream);*/

            Bodies = Loader.DeserializeWorld(@"..\..\..\WindowsPhoneGame1\WindowsPhoneGame1Content\Levels\Level1.xml");
            /*foreach (FloatShape FS in Bodies)
                FS.Normalize((float)(udRealWidth.Value / udWidth.Value), (float)(udRealHeight.Value / udHeight.Value));*/
            RedrawScene();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ActionType = Editor.ActionType.BoxCreate;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            ActionType = Editor.ActionType.CircleCreate;
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            ActionType = Editor.ActionType.PolygonCreate;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            ActionType = Editor.ActionType.Select;
        }

        private void btnCreateLine_Click(object sender, RoutedEventArgs e)
        {
            ActionType = Editor.ActionType.LineCreate;
        }


        
    }
}
