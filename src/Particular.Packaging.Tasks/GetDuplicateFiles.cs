namespace Particular.Packaging.Tasks;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

public class GetDuplicateFiles : Task
{
    [Required]
    public string BasePath { get; set; } = string.Empty;

    [Required]
    public ITaskItem[] Paths { get; set; } = [];

    [Output]
    public ITaskItem[]? DuplicateFiles { get; private set; } = [];

    public override bool Execute()
    {
        BasePath = Path.GetFullPath(BasePath);
        HashSet<(string, long)>? duplicates = null;

        foreach (var path in Paths)
        {
            var files = EnumerateFiles(Path.Combine(BasePath, path.ItemSpec));
            duplicates ??= files;

            duplicates.IntersectWith(files);
        }

        if (duplicates is not null)
        {
            var results = new List<ITaskItem>(duplicates.Count);

            foreach (var (fileName, _) in duplicates)
            {
                results.Add(new TaskItem(fileName));
            }

            DuplicateFiles = results.ToArray();
        }

        return true;
    }

    static HashSet<(string FileName, long Length)> EnumerateFiles(string path)
    {
        HashSet<(string, long)> files = [];

        foreach (var file in Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories))
        {
            var fileInfo = new FileInfo(file);
            var fileName = fileInfo.FullName.Substring(path.Length + 1);
            files.Add((fileName, fileInfo.Length));
        }

        return files;
    }
}