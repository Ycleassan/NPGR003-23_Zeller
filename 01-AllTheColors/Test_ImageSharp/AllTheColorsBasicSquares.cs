using SixLabors.ImageSharp;
using System.Collections.Immutable;
using static System.Net.Mime.MediaTypeNames;

void GB_Square(byte red, int startX, int startY, Image<Rgba32> image)
{
  for (int i = 0; i < 256; i++)
  {
    for (int j = 0; j < 256; j++)
    {
      image[i + startX, j+startY] = new Rgba32(red, (byte)i, (byte)j);
    }
  }
}

using (var image = new Image<Rgba32>(256*16, 256*16))
{
  for(int i = 0; i < 16; ++i)
  {
    for (int j = 0; j < 16; ++j)
    {
      GB_Square((byte)(16*i + j), 256*i, 256*j, image);
    }
  }


  image.SaveAsPng("..\\..\\..\\..\\16mColorsZeller.png");
}
