using ADAA.ADP.Application.Contracts.Infrastructure;
using ADAA.ADP.Application.Features.Categories.Queries.GetCategoriesExport;
using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ADP.ADAA.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        //public byte[] ExportCategoriesToCsv(List<CategoryExportDto> categoryExportDtos)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using (var streamWriter = new StreamWriter(memoryStream))
        //    {
        //        using var csvWriter = new CsvWriter(streamWriter,Thread.CurrentThread.CurrentCulture, false);
        //        csvWriter.WriteRecords(categoryExportDtos);
        //    }

        //    return memoryStream.ToArray();
        //}

        public byte[] ExportToCsv(List<CategoryExportDto> categoryExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, Thread.CurrentThread.CurrentCulture, false);
                csvWriter.WriteRecords(categoryExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
