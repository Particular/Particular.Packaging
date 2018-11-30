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
