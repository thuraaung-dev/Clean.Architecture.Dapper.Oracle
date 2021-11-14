using ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesExport;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADAA.ADP.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportToCsv(List<CategoryExportDto> categoryExportDtos);
    }
}
