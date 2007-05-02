using System;
using System.Collections.Generic;
using System.Text;

namespace taio.Data
{
    
    class Rectangle
    {
        /**width and height of rectange*/
        int width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        
    }
}
