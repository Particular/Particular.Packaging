# Particular.Packaging

Note: This package only works with SDK-style projects.

## Usage

Add the following package reference to your csproj:

`<PackageReference Include="Particular.Packaging" Version="{package version}" PrivateAssets="All" />`

The package description defaults to the package ID, so add the following to provide a real description:

```
  <PropertyGroup>
    <Description>{The package's description}</Description>
  </PropertyGroup>
```

Remove all references to

* NuGetPackager
* GitVersionTask
* SourceLink

## Design notes

Particular.Packaging takes the properties defined in Particular.Packaging.props and injects them into projects that reference the [Particular.Packaging package](https://github.com/Particular/Particular.Packaging/blob/master/src/Particular.Packaging/build/Particular.Packaging.props). This allows a common set of properties to be applied to all our packages (authors, company, license file, etc). It does the same for the targets defined in [Particular.Package.targets](https://github.com/Particular/Particular.Packaging/blob/master/src/Particular.Packaging/build/Particular.Packaging.targets), which perform tasks such as including the license file and blocking unsupported .NET frameworks.

There are two folders that need to be included: `build` and `buildMultitargeting`. This is to ensure the Particular.Packaging props and targets are included in multiple scenarios, including builds that are multi-targeted. Note that there is another build type, [buildTransitive](https://github.com/NuGet/Home/wiki/Allow-package--authors-to-define-build-assets-transitive-behavior), which is not covered here.

The Particular.Packaging.csproj file includes references to both the `build` and `buildMultiTargeting` folders which ensures the relevant props and targets files are included in the package and ultimately referenced by other packages that reference Particular.Packaging.

Note that the Particular.Packaging project includes both [Directory.Build.props](https://docs.microsoft.com/en-us/visualstudio/msbuild/customize-your-build?view=vs-2022) and Directory.Build.targets. These files perform the same function that the Particular.Packaging package itself does. But since Particular.Packaging can not reference itself, we need these Directory.Build.* files to perform that function here.
