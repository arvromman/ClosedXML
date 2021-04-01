using System;
using ClosedXML.Excel;

namespace ClosedXML.Examples.Misc
{
    public class WorkbookProtection : IXLExample
    {
        #region Methods

        // Public
        public void Create(String filePath)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Workbook Protection");
                wb.Protect( "Abc@123", XLProtectionAlgorithm.Algorithm.SHA512, XLWorkbookProtectionElements.Everything);
                wb.SaveAs(filePath);
            }
        }

        #endregion
    }
}
