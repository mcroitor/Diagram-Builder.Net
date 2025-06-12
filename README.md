# Diagram-Builder.Net

[русская версия](README.RU.md)

Diagram Builder, standalone version. This version is .Net Framework dependent.

## Versions history

### 2.0.3

- Load last used fen file on start.
- Import PGN format.
- Import OLV format.

### 2.0.1

- Menu File --> Recent was added. It memorize 10 last opened files.
- Loading chess fonts by maps. Font maps are defined in the `fonts/mapping` folder.
- An option of crop image was added.

### 2.0.0

Refactoring. Extracted ChessFont and ChessBoard classes in libraries. Created console utility for fen to png image conversion.

### 1.0.3

- fixed bug with up / down keys;
- export name of images contains epd file name;
- `Condal` and `Leipzig` fonts added.

### 1.0.2

.Net Framework version. Fix some bugs. Implemented functionality:

- "on top" option
- default options
- init / clear position toolbar buttons

### 1.0.1

Two versions, .Net Core and .Net Framework. Fix some bugs. Implemented functionality:

- open / save fen files
- initial board, clear board
- export fen to set of PNG images

### 1.0.0

.Net Core version. Very first version with many bugs. Can set position, can export to image.

## Known bugs

- [+] up / down key doesn't lists positions.
- [-] if `fonts` or `images` folders are not present, the program does not start and does not report an error.

## TO DO

- [#] extend toolbar
- [+] implement change / save default options
- [-] highlight piece moved on board
- [+] import pgn format
- [+] import olv format
- [-] export to JPEG, TIFF
- [+] "Always on top" option
- [+] load last used fen file
