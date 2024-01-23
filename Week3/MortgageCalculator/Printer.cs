namespace MortgageCalculator
{
    // Justify applys alignment on the x axis
    public enum Justify
    {
        Left,
        Center,
        Right
    }

    // Align applys alignment on the y axis
    public enum Align
    {
        Top,
        Middle,
        Bottom
    }

    public class Printer
    {
        private static int _appSafeAreaX;
        private static int AppSafeAreaY { get; set; }
        private static int _px;
        private static int _py;

        public Printer(int width, int px, int py)
        {
            _appSafeAreaX = width - px * 2;
            _px = px;
            _py = py;
        }

        public void Print(string[] lines, Justify justify = Justify.Left, Align align = Align.Top, char padChar = ' ', char boundaryChar = '#', string? header = null)
        {
            AppSafeAreaY = lines.Length + _py * 2;
            switch (align)
            {
                case Align.Top:
                    PrintTop(lines, padChar, boundaryChar, justify, header);
                    break;
                case Align.Middle:
                    PrintMiddle(lines, padChar, boundaryChar, justify, header);
                    break;
                case Align.Bottom:
                    PrintBottom(lines, padChar, boundaryChar, justify, header);
                    break;
            }
        }

        private static void PrintTop(string[] lines, char padChar, char boundaryChar, Justify justify = Justify.Left, string? header = null)
        {
            PrintBoundary(boundaryChar);

            if (header != null)
            {
                PrintHeader(header, padChar, boundaryChar);
            }

            for (int i = 0; i < _py - 1; i++)
            {
                PrintEmptyLine(padChar, boundaryChar);
            }

            foreach (string line in lines)
            {
                string sanitizedLine = SanitizeText(line);
                int length = sanitizedLine.Length;
                switch (justify)
                {
                    case Justify.Left:
                        string justifiedLine = JustifyLeft(sanitizedLine, padChar);
                        string paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                    case Justify.Center:
                        justifiedLine = JustifyCenter(sanitizedLine, length, padChar);
                        paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                    case Justify.Right:
                        justifiedLine = JustifyRight(sanitizedLine, padChar);
                        paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                }
            }

            for (int j = 0; j < AppSafeAreaY - lines.Length; j++)
            {
                PrintEmptyLine(padChar, boundaryChar);
            }

            PrintBoundary(boundaryChar);
        }

        private static void PrintMiddle(string[] lines, char padChar, char boundaryChar, Justify justify = Justify.Left, string? header = null)
        {

            int topPadding = (AppSafeAreaY - lines.Length) / 2;
            int bottomPadding = AppSafeAreaY - lines.Length - topPadding;

            PrintBoundary(boundaryChar);

            if (header != null)
            {
                PrintHeader(header, padChar, boundaryChar);
            }

            for (int i = 0; i < topPadding; i++)
            {
                PrintEmptyLine(padChar, boundaryChar);
            }

            foreach (string line in lines)
            {
                string sanitizedLine = SanitizeText(line);
                int length = sanitizedLine.Length;
                switch (justify)
                {
                    case Justify.Left:
                        string justifiedLine = JustifyLeft(sanitizedLine, padChar);
                        string paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                    case Justify.Center:
                        justifiedLine = JustifyCenter(sanitizedLine, length, padChar);
                        paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                    case Justify.Right:
                        justifiedLine = JustifyRight(sanitizedLine, padChar);
                        paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                }
            }

            for (int j = 0; j < bottomPadding; j++)
            {
                PrintEmptyLine(padChar, boundaryChar);
            }

            PrintBoundary(boundaryChar);
        }

        private static void PrintBottom(string[] lines, char padChar, char boundaryChar, Justify justify = Justify.Left, string? header = null)
        {
            int topPadding = AppSafeAreaY - lines.Length;

            PrintBoundary(boundaryChar);

            if (header != null)
            {
                PrintHeader(header, padChar, boundaryChar);
            }

            for (int i = 0; i < topPadding; i++)
            {
                PrintEmptyLine(padChar, boundaryChar);
            }

            foreach (string line in lines)
            {
                string sanitizedLine = SanitizeText(line);
                int length = sanitizedLine.Length;
                switch (justify)
                {
                    case Justify.Left:
                        string justifiedLine = JustifyLeft(sanitizedLine, padChar);
                        string paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                    case Justify.Center:
                        justifiedLine = JustifyCenter(sanitizedLine, length, padChar);
                        paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                    case Justify.Right:
                        justifiedLine = JustifyRight(sanitizedLine, padChar);
                        paddedLine = ApplyPadding(justifiedLine, padChar, boundaryChar);
                        PrintLine(paddedLine);
                        break;
                }
            }

            for (int j = 0; j < _py - 1; j++)
            {
                PrintEmptyLine(padChar, boundaryChar);
            }

            PrintBoundary(boundaryChar);
        }

        private static void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        private static void PrintBoundary(char boundaryChar)
        {
            string boundaryJustified = JustifyCenter("", _appSafeAreaX, boundaryChar);
            string boundary = ApplyPadding(boundaryJustified, boundaryChar, boundaryChar);
            PrintLine(boundary);
        }

        private static void PrintEmptyLine(char padChar, char boundaryChar)
        {
            string emptyLineJustified = JustifyCenter("", _appSafeAreaX, padChar);
            string emptyLine = ApplyPadding(emptyLineJustified, padChar, boundaryChar);
            PrintLine(emptyLine);
        }

        private static void PrintHeader(string header, char padChar, char boundaryChar)
        {
            char overwritePadChar = '-';
            string headerJustified = JustifyCenter(header, header.Length, overwritePadChar);
            string headerPadded = ApplyPadding(headerJustified, padChar, boundaryChar);
            PrintLine(headerPadded);
        }

        private static string ApplyPadding(string alignedText, char padChar, char boundaryChar = '#')
        {
            string leftPad = $"{boundaryChar}{"".PadRight(_px - 1, padChar)}";
            string rightPad = $"{"".PadRight(_px - 1, padChar)}{boundaryChar}";
            return $"{leftPad}{alignedText}{rightPad}";
        }

        private static string SanitizeText(string source)
        {
            return TrimText(ClampText(source));
        }

        private static string TrimText(string source)
        {
            return source.Trim();
        }

        // Method to trim the source string if it exceeds the safe area of the app
        private static string ClampText(string source)
        {
            return source.Length > _appSafeAreaX ? source[.._appSafeAreaX] : source;
        }


        /**
         * Justify methods
         */
        private static string JustifyLeft(string text, char padChar)
        {
            // To align the text left we take the safe area minus input and pad the right side with the padChar
            return text.PadRight(_appSafeAreaX, padChar);
        }

        private static string JustifyCenter(string text, int length, char padChar)
        {
            int spaces = _appSafeAreaX - length; // The number of available spaces is the total safe area minus the text length

            int padLeft = spaces / 2 + length; // The number of spaces to pad left is the number of available spaces divided by 2 plus your text length

            return text.PadLeft(padLeft, padChar).PadRight(_appSafeAreaX, padChar); // Return the text padded left and right with the boundary chars
        }

        private static string JustifyRight(string text, char padChar)
        {
            // To align the text right we take the safe area minus input and pad the left side with the padChar
            return text.PadLeft(_appSafeAreaX, padChar);
        }

        /**
         * Align methods
         */
    }
}