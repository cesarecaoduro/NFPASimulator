using System;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace NFPASimulator.Utilities
{
    using Newtonsoft.Json;
    using Autodesk.Revit.DB;
    using NFPASimulator.Models;

    public class Utilities
    {
        internal static BitmapSource GetImage(IntPtr bm)
        {
            BitmapSource bmSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bm,
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return bmSource;
        }

        internal static DesignParametersModel[] DesignParametersFromJSON(string path)
        {
            DesignParametersModel[] designParameters;
            using (StreamReader file = File.OpenText(path))
            {
                var jsonData = file.ReadToEndAsync().Result;
                designParameters = JsonConvert.DeserializeObject<DesignParametersModel[]>(jsonData);
            }
            return designParameters;
        }

        internal static List<ElementId> CollectElementsByCategory(Document doc, BuiltInCategory bic)
        {
            return new FilteredElementCollector(doc)
                .OfCategory(bic)
                .WhereElementIsNotElementType()
                .ToElementIds()
                .ToList();
        }
    }
}

