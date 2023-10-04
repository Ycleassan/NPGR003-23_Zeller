using SixLabors.ImageSharp;

Random rnd = new Random();
int[] Permutation(int size)
{
  int[] ordered = new int[size];
  for( int i = 0; i < size; i++)
  {
    ordered[i] = i;
  }
  return ordered.OrderBy(x => rnd.Next()).ToArray();
}

void GB_Square (byte red, int startX, int startY, Image<Rgba32> image)
{
  int[] permGreen = Permutation(256);
  int[] permBlue = Permutation(256);

  for (int i = 0; i < 256; i++)
  {
    for (int j = 0; j < 256; j++)
    {
      image[permGreen[i] + startX, permBlue[j] + startY] = new Rgba32(red, (byte)i, (byte)j);
    }
  }
}

using (var image = new Image<Rgba32>(256 * 16, 256 * 16))
{
  int[] permRed = Permutation(256);
  for(int i = 0; i < 16; ++i)
  {
    for(int j = 0;j < 16; j++)
    {
      GB_Square((byte)permRed[(16 * i + j)], 256 * i, 256 * j, image);

    }
  }
  image.SaveAsPng("..\\..\\..\\..\\16mColorsZeller_random.png");

}

