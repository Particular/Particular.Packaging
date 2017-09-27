# Particular.Packaging

Note: This package only works with csproj based packaging!

## Usage

Add the following package reference to your csproj:

`<PackageReference Include="Particular.Packaging" Version="*" PrivateAssets="All" />`

Add the following required attributes to the csproj:

```
  <PropertyGroup>
    <Description>{The package's description}</Description>
  </PropertyGroup>
```

Remove all references to
* NuGetPackager
* GitVersionTask
