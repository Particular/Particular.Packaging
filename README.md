# Particular.Packaging

Note: This package only works with csproj-based packaging!

## Usage

Add the following package reference to your csproj:

`<PackageReference Include="Particular.Packaging" Version="*" PrivateAssets="All" />`

The package description defaults to the package id, so add the following project to provide a real description:

```
  <PropertyGroup>
    <Description>{The package's description}</Description>
  </PropertyGroup>
```

Remove all references to
* NuGetPackager
* GitVersionTask
