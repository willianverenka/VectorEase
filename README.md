# VectorEase

VectorEase is an intuitive C# library designed to streamline vector operations by providing a versatile abstraction layer. Whether you're working with 2D or 3D vectors, VectorEase simplify the execution of common vector operations, eliminating the need to delve into the details of underlying mathematical operations.

## Work in Progress

This project is currently a work in progress. While it may have some functionality, please be aware of the following:

- Certain features are not yet implemented.
- Code may not be fully optimized.
- Documentation is in progress.

Feel free to contribute by reporting issues or submitting pull requests.

## Installation

### .NET 8 Sdk
Ensure you have the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed in your ambient.

### Clone the repository:
```bash
git clone https://github.com/willianverenka/VectorEase/
```

### Reference the library in your project:
You can manually reference the library in your .csproj project file.
```xml
  <ItemGroup>
    <ProjectReference Include="path\to\VectorEase\VectorEase.csproj" />
  </ItemGroup>
```

### Build

After referencing the library, you should be able to build your solution to ensure the library is compiled, it's then ready to use.

## Usage

You can instantiate vectors through the VectorEase.Model namespace, the static operation methods work under VectorEase.Utility.

```csharp
using VectorEase.Model;
using VectorEase.Utility;

// Create 2D vectors
var v1 = new Vector2D(3, 4);
var v2 = new Vector2D(-1, 2);

// Perform vector addition
var result = VectorOperations.VectorSum(v1, v2);

// Calculate the dot product
double dotProduct = VectorOperations.DotProduct(v1, v2);

// Create 3d vector

var v3 = new Vector3D(-2, -2, 1);

// Calculate its magnitude
Console.WriteLine($"The magnitude of v3 is {VectorOperations.Magnitude(v3)}")
// => The magnitude of v3 is 3.0
```

## License

This project is licensed under the [MIT License](https://opensource.org/license/mit/).
