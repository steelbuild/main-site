﻿using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_site
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var src = args.ElementAtOrDefault(0) ?? throw new Exception("src is required");
            var dist = args.ElementAtOrDefault(1) ?? throw new Exception("dist is required");

            var converter = new markdown_to_html.Converter();

            Directory.CreateDirectory(dist);
            foreach (var file in System.IO.Directory.GetFiles(src, "*.md"))
            {
                var fileInfo = new FileInfo(file);
                Console.WriteLine($"Converting {fileInfo.Name} to HTML");

                var markdown = await File.ReadAllTextAsync(file);

                var html = converter.Execute(markdown);
                var htmlFilePath = Path.ChangeExtension(Path.Combine(dist, fileInfo.Name), "html");
                await File.WriteAllTextAsync(htmlFilePath, html, Encoding.UTF8);
            }
        }
    }
}
