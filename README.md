# Particular.Packaging

Note: This package only works with csproj based packaging!

## Usage

Add the following package reference to your csproj:

`<PackageReference Include="Particular.Packaging" Version="*" PrivateAssets="All" />`

Add the following required attributes to the cspproj:

```
  <PropertyGroup>
    <Description>{The package's description}</Description>
  </PropertyGroup>
```

additionally, if you want to create the NuGet package on build, add:

`<GeneratePackageOnBuild>true</GeneratePackageOnBuild>`
  
  
Remove all package dependencies to
* NuGetPackager
* GitVersionTask

