# Cyberpunk 2077 AMD Optimization Patcher
Patcher for Cyberpunk 2077 game optimization on AMD processors

Uses .NET Framework (v4.7.2) and Newtonsoft.Json package.

Features:
- Drag-and-Drop
- Signatures update attempt (from data/signatures.json on this repository), else built-in signatures will used
- Interactivity:
  - Error handler for textbox (red alert icon for invalid entered path)
  - Error handler for patch button (message window for displayingsuccess/error info)
  - Patching progressbar
  - File choosing dialog window for "Choose" button
  - Textbox hint if no path entered
  - Exit button

Previews:
![alt text](previews/preview1.png?raw=true)
![alt text](previews/preview2.png?raw=true)
![alt text](previews/preview3.png?raw=true)

TODO:
- Finding Cyberpunk2077.exe path in registry
- Translate it on Russian

Changelog:
- v1.0: initial commit