namespace Particular.Packaging.Tasks;

using System.IO.Compression;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

public class ZipFiles : Task
{
    [Required]
    public string BasePath { get; set; } = string.Empty;

    [Required]
    public ITaskItem[] Files { get; set; } = [];

    public ITaskItem[] ExcludedFiles { get; set; } = [];

    [Required]
    public string DestinationFile { get; set; } = string.Empty;

    public override bool Execute()
    {
        using var fileStream = new FileStream(DestinationFile, FileMode.Create);
        using var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create);

        foreach (var file in Files)
        {
            var entryName = file.ItemSpec.Substring(BasePath.Length + 1);

            if (!ExcludedFiles.Any(t => t.ItemSpec == entryName))
            {
                zipArchive.CreateEntryFromFile(file.ItemSpec, entryName, CompressionLevel.Optimal);
            }
        }

        return true;
    }
}
