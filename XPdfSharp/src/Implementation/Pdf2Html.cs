using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPdfSharp.Implementation.Utils;
using XPdfSharp.Interface;

namespace XPdfSharp.Implementation
{
    public class Pdf2Html : IPdf2Html
    {
        private const string ProgramBaseName = "pdftohtml";
        public string Suffix { get; set; } = "page";
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int Zoom { get; set; }
        public int Dpi { get; set; } = 72;
        public bool FormField { get; set; }
        public bool TableMode { get; set; }
        public bool OverWrite { get; set; }

        public async Task<int> GenerateHTMLAsync([NotNull] string fileName, [NotNull] string outputDirectory)
        {
            if (!File.Exists(fileName) || !Directory.CreateDirectory(outputDirectory).Exists)
                return -1;

            if (outputDirectory[^1] != Path.DirectorySeparatorChar)
                outputDirectory = string.Concat(outputDirectory, Path.DirectorySeparatorChar);

            var args = ParseParameters();
            args.Add(LibUtils.QuotedStr(fileName));
            args.Add(LibUtils.QuotedStr($"{outputDirectory}{Suffix}"));

            var programName = LibUtils.GetProgramName(ProgramBaseName);
            var fullArgs = LibUtils.ParseParameters(args);
            var workDir = LibUtils.WorkDirectory;

            return await CustomProcess.RunProcessAsync(programName, fullArgs, workDir);
        }
        public void Dispose()
        {
        }

        private List<string> ParseParameters()
        {
            var args = new List<string>();

            if (FirstPage > 0) args.Add($"-f {FirstPage}");
            if (LastPage > 0) args.Add($"-l {LastPage}");

            if (Zoom > 0) args.Add($"-z {Zoom}");
            if (Dpi > 0) args.Add($"-r {Dpi}");            

            if (FormField) args.Add("-formfields");
            if (TableMode) args.Add("-table");
            if (OverWrite) args.Add("-overwrite");            

            return args;
        }
    }
}
