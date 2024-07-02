using System;
using System.IO;
using System.Threading.Tasks;
using XPdfSharp.Factory;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("====== XPdfToolsForSharp Demo ======");
            Console.WriteLine();
            
            //using (var extract = ToolsFactory.NewPdf2Text)
            //{
            //    extract.Raw = true;
            //    extract.NoBreakPage = true;
            //    var text = await extract.ExtractTextAsync("samples/sample.pdf");
                
            //    Console.WriteLine(text);
            //}
            
            Console.WriteLine();
            
            //if (Directory.Exists("samples/images/"))
            //    Directory.Delete("samples/images/", true);
            
            //using (var images = ToolsFactory.NewPdf2Png)
            //{
            //    images.Dpi = 75;
            //    var result = await images.GenerateImagesAsync("samples/sample.pdf", "samples/images/");
                
            //    Console.WriteLine("Generated images success: {0} codeError: {1}", result == 0, result);
            //    if (result != 0)
            //        return;

            //    var files = Directory.GetFiles("samples/images/");
            //    Console.WriteLine("Image Count: {0}", files.Length);
            //}

            if (Directory.Exists("samples/html/"))
                Directory.Delete("samples/html/", true);

            using (var html = ToolsFactory.NewPdf2Html)
            {
                //html.Dpi = 75;
                //html.FirstPage = html.LastPage= 1; //-> uncomment these line to just convert the file page to HTML.
                html.Suffix = "page"; // chnage the folder name
                var result = await html.GenerateHTMLAsync("samples/BKGCONF_NAM6862034.pdf", "samples/html/");

                Console.WriteLine("Generated HTML success: {0} codeError: {1}", result == 0, result);
                if (result != 0)
                    return;

                var files = Directory.GetFiles($"samples/html/{html.Suffix}/");
                Console.WriteLine("Html Count: {0}", files.Length);
                // read the HTML file.
                string text = File.ReadAllText($"samples/html/page/{html.Suffix}1.html");
                Console.WriteLine("Html Count: {0}", files.Length);
            }


        }
    }
}