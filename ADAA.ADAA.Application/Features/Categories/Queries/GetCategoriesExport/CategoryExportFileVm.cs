using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Solution.Application.Features.Categories.Queries.GetCategoriesExport
{
    public class CategoryExportFileVm
    {
        public string CategoryExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
