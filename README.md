# Particular.Packaging

This package is used by the team at [Particular Software](https://particular.net) to enforce consistency and best practices when creating NuGet packages.

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

## Deployment

Tagged versions are automatically pushed to [feedz.io](https://feedz.io/org/particular-software/repository/packages/packages/Particular.Analyzers). After validating new versions, the package should be promoted to production by pushing the package to NuGet using the feedz.io push upstream feature.