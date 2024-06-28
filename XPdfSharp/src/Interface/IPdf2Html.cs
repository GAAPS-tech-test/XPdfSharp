using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using XPdfSharp.Implementation;
using System.Diagnostics.CodeAnalysis;

namespace XPdfSharp.Interface
{
    public interface IPdf2Html
    {

        public string Suffix { get; set; }
        /// <summary>
        /// First page to print
        /// </summary>
        public int FirstPage { get; set; }
        /// <summary>
        /// Last page to print
        /// </summary>
        public int LastPage { get; set; }
        /// <summary>
        /// Resolution, in Zoom (Default: 1.0)
        /// </summary>
        public int Zoom { get; set; }
        /// <summary>
        /// Resolution, in DPI (Default: 72dpi)
        /// </summary>
        public int Dpi { get; set; }

        /// <summary>
        /// Convert AcroForm text and checkbox fields  to  HTML  input  ele-
        /// ments.This also removes text(e.g., underscore characters) and
        /// erases background image content(e.g., lines or  boxes)  in  the
        /// field areas.
        /// </summary>
        public bool FormField { get; set; }

        /// <summary>
        /// Use table mode when performing the underlying  text  extraction.
        /// This will  generally produce better output when the PDF content
        ///      is a full-page table.NB: This does not generate  HTML tables;
        /// it just changes the way text is split up.
        /// </summary>
        public bool TableMode { get; set; }
        /// <summary>
        /// By default pdftohtml will not overwrite the specified output di-
        /// rectory.If the directory already exists, pdftohtml will  exit
        /// with an error.This option tells pdftohtml to instead overwrite
        /// the existing directory.
        /// </summary>
        public bool OverWrite { get; set; }

        public Task<int> GenerateHTMLAsync([NotNull] string fileName, [NotNull] string outputDirectory);
    }
}
