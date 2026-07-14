namespace BrightistRenderer.Texts.Fonts.Glyphs
{
    internal class VariableWidthProvider
    {
        private static readonly int[] VariableWidths =
        [
            12,  7, 12, 12,  3,  3, 12,  3,  3,  7,  3, 12, 12, 12, 12, 12,
             6, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12,
            12, 12, 12,  2, 12, 12, 12, 12, 12, 12,  4,  5, 12, 12,  4,  5,
             5,  6, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 10, 10, 12, 12,
            12, 12, 10, 12, 11, 11, 12, 12, 12, 12, 12, 12, 12,  2,  4, 12,
            12,  9, 12, 12, 12, 11, 10,  8, 12, 12, 12, 12, 12, 12, 12, 12,
	
             8,  4,  8,  9,  9,  8,  8,  8,  9,  8,  0,  0,  0,  0,  0,  0,
	
             0, 10,  9, 10,  9,  8,  8, 10,  8,  2,  8,  8,  8, 10,  8, 10,
             8, 10,  9,  9, 10,  8, 10, 12,  9,  8,  8,  0,  0,  0,  0,  0,
	
             0,  0,  8,  7,  8,  8,  8,  6,  8,  7,  2,  4,  7,  2, 10,  7,
             8,  7,  8,  6,  7,  6,  7,  8, 10,  7,  7,  7,  0,  0,  0,  0
        ];

        private static readonly int[] PreDistance =
        [
             0,  0,  0,  0,  0,  0,  0,  4,  4,  3,  5,  0,  0,  0,  0,  0,
             3,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
             0,  0,  0,  5,  0,  0,  0,  0,  0,  0,  8,  0,  0,  0,  8,  0,
             7,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  1,  1,  0,  0,
             0,  0,  1,  0,  0,  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
             0,  2,  0,  0,  0,  0,  1,  2,  0,  0,  0,  0,  0,  0,  0,  0,
	
             2,  3,  2,  1,  1,  2,  2,  2,  1,  2,  0,  0,  0,  0,  0,  0,
	
             0,  1,  2,  1,  2,  2,  2,  1,  2,  5,  2,  2,  2,  1,  2,  1,
             2,  1,  2,  2,  1,  2,  1,  0,  1,  2,  2,  0,  0,  0,  0,  0,
	
             0,  0,  2,  3,  2,  2,  2,  3,  2,  3,  5,  4,  3,  5,  1,  3,
             2,  3,  2,  4,  3,  3,  3,  2,  1,  3,  3,  3,  0,  0,  0,  0
        ];

        public static int GetCharacterWidth(ushort code, int defaultWidth)
        {
            int lookupIndex = GetLookupIndex(code);
            return lookupIndex >= 0 ? VariableWidths[lookupIndex] : defaultWidth;
        }

        public static int GetCharacterX(ushort code, int defaultDistance)
        {
            int lookupIndex = GetLookupIndex(code);
            return lookupIndex >= 0 ? PreDistance[lookupIndex] : defaultDistance;
        }

        private static int GetLookupIndex(ushort code)
        {
            if (code < 0x824f)
                return code - 0x813f;

            if (code < 0x829f)
                return code - 0x81ef;

            return -1;
        }
    }
}
