using System;
using System.Diagnostics;
using Datalogics.PDFL;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Create();
                Console.WriteLine("Hello World!");
        }

        public static void Create()
        {
            using (Library lib = new Library())
            {
                String sOutput = "Actions-out.pdf";

                Console.WriteLine("Initialized the library.");

                Document doc = new Document();

                using (new Path())
                {
                    // Create a PDF page which is the same size of the image.
                    Rect pageRect = new Rect(0, 0, 100, 100);
                    Page docpage = doc.CreatePage(Document.BeforeFirstPage,
                        pageRect);
                    Console.WriteLine("Created page.");
                    PrintUserParams param = new PrintUserParams();
                    param.PaperSource = PaperSource.Auto;
                   
                    // Create our first link with a URI action
                    LinkAnnotation newLink = new LinkAnnotation(docpage, new Rect(1.0, 2.0, 3.0, 4.0));
                    Console.WriteLine(newLink.ToString());

                    doc.BaseURI = "http://www.datalogics.com";
                    URIAction uri = new URIAction("/products/pdf/pdflibrary/", false);
                    Console.WriteLine("Action data: " + uri);

                    newLink.Action = uri;

                    // Create a second link with a GoTo action
                    LinkAnnotation secondLink = new LinkAnnotation(docpage, new Rect(5.0, 6.0, 7.0, 8.0));

                    Rect r = new Rect(5, 5, 100, 100);
                    GoToAction gta = new GoToAction(new ViewDestination(doc, 0, "FitR", r, 1.0));
                    Console.WriteLine("Action data: " + gta);

                    secondLink.Action = gta;

                    // Read some URI properties
                    Console.WriteLine("Extracted URI: " + uri.URI);

                    if (uri.IsMap)
                        Console.WriteLine("Send mouse coordinates");
                    else
                        Console.WriteLine("Don't send mouse coordinates");

                    // Change the URI properties
                    doc.BaseURI = "http://www.datalogics.com";
                    uri.URI = "/products/pdf/pdflibrary/";

                    uri.IsMap = true;

                    Console.WriteLine("Complete changed URI:" + doc.BaseURI + uri.URI);

                    if (uri.IsMap)
                        Console.WriteLine("Send mouse coordinates");
                    else
                        Console.WriteLine("Don't send mouse coordinates");

                    // Testing gta
                    Console.WriteLine("Fit type of destination: " + gta.Destination.FitType);
                    Console.WriteLine("Rectangle of destination: " + gta.Destination.DestRect);
                    Console.WriteLine("Zoom of destination: " + gta.Destination.Zoom);
                    Console.WriteLine("Page number of destination: " + gta.Destination.PageNumber);
                    doc.Print(param);
                    //doc.Save(SaveFlags.Full, sOutput);
                }
            }
        }

    }
}
