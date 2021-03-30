using Interfaces;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;

namespace WordListener
{
    public class WordListener : IObserver
    {
        public List<string> NameList { get; set; } = new List<string>();
        public List<string> ValueList { get; set; } = new List<string>();

        public void Update(string message, string type)
        {
            Application app = null;
            try
            {
                app = new Application { Visible = false };
                var doc = app.Documents.Open(Directory.GetCurrentDirectory() + @"\Word.docx");
                doc.Content.Text += $"{message} || {type}";

                doc.Save();
                doc.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                app.Quit();
            }
        }
    }
}
