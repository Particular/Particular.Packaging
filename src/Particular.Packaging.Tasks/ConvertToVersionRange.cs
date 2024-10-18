namespace Particular.Packaging.Tasks;

using System.Text.RegularExpressions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

public class ConvertToVersionRange : Task
{
    [Required]
    public ITaskItem[] References { get; set; } = [];

    [Output]
    public ITaskItem[]? ReferencesWithVersionRanges { get; private set; } = [];

    public override bool Execute()
    {
        var success = true;

        foreach (var reference in References)
        {
            var upperBound = reference.GetMetadata("UpperBound");

            if (upperBound.Equals("false", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var privateAssets = reference.GetMetadata("PrivateAssets");

            if (privateAssets.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            //System.Diagnostics.Debugger.Launch();

            var version = reference.GetMetadata("Version");
            var match = Regex.Match(version, @"^\d+");

            if (match.Value == string.Empty)
            {
                Log.LogError("Reference '{0}' with Version '{1}' is not valid for automatic version range conversion. Fix the range or disable by setting the property.", reference.ItemSpec, version);
                success = false;
                continue;
            }

            var nextMajor = Convert.ToInt32(match.Value) + 1;

            var versionRange = $"[{version}, {nextMajor}.0.0)";
            reference.SetMetadata("Version", versionRange);
        }

        ReferencesWithVersionRanges = References;

        return success;
    }
}
