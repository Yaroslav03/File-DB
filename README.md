# File-DB

A Windows desktop utility for cataloguing automotive ECU BIN files. Enter vehicle and control-module details, select file and memory types and the work performed, then copy the selected BIN file into a library using a descriptive filename built from that metadata.

## Features

- Select a source `.bin` file through a file picker.
- Record vehicle information such as make, model, year, engine capacity, engine code, transmission, fuel type, and turbo configuration.
- Record control module name and number, software number, memory type, file type, and the tool used to read the file.
- Select one or more work types; selecting a work type marks the file as modified. The original-file option clears the work-type selections.
- Generate a filename from the selected metadata and copy the source file into the library folder.
- Open File Explorer with the saved file selected after a successful copy.

## Technology

| Component | Technology |
|---|---|
| Language | C# |
| Platform | Windows Forms |
| Target framework | .NET 10 for Windows (`net10.0-windows`) |
| External packages | None declared in the project file |

## Project structure

```text
File-DB/
├── FileDB.slnx              # Visual Studio solution
└── FileDB/
    ├── FileDB.csproj        # Windows Forms project configuration
    ├── Program.cs           # Application entry point
    ├── Form1.cs             # File selection, metadata, naming, and copy workflow
    ├── Form1.Designer.cs    # Windows Forms UI layout
    └── PathModel.cs         # Metadata used to build the output filename
```

## Requirements

- Windows
- .NET 10 SDK
- Visual Studio 2022 (or a compatible IDE with Windows Forms support)

## Build and run

From the repository root:

```bash
dotnet restore FileDB.slnx
dotnet run --project FileDB/FileDB.csproj
```

You can also open `FileDB.slnx` in Visual Studio, set `FileDB` as the startup project, then build and run it.

## Output location

The current implementation copies files to `\FileDB\UserData` on the current drive and replaces an existing file if the generated filename already exists. This path is hard-coded in `Form1.cs`; review or change it to a suitable location before using the application with important files.

## Notes

- The interface text is currently in Ukrainian.
- The application copies the selected file; it does not modify the BIN file contents.
- Filenames are assembled from the entered metadata and selected options. Review the generated naming logic if your archival convention requires different fields or separators.
