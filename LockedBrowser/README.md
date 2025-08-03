# LockedBrowser

A Windows application (runs in Wine) that opens only two websites:
- https://www.khaled-sakr.com/
- https://mohamed-abdelgwad.com/

## How to Build

1. Install .NET 6 SDK and WebView2 SDK.
2. Run:
   ```
   dotnet new winforms -o LockedBrowser
   mv Program.cs LockedBrowser/
   mv MainForm.cs LockedBrowser/
   cd LockedBrowser
   dotnet add package Microsoft.Web.WebView2
   dotnet publish -c Release -r win-x64 --self-contained false -o dist
   ```
3. The executable will be in `dist/LockedBrowser.exe`.

## How to Run

```bash
wine dist/LockedBrowser.exe
```
