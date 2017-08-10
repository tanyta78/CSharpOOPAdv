using System;

namespace Graphic_Editor
{
    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
           Console.WriteLine(shape.Draw());
        }
    }
}