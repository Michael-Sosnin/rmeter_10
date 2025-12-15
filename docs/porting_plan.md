# Porting plan: VB.NET WinForms "CVR-10" to C++20 + Qt 6.9.1

## 1. Inventory of user-visible flows and background work
- **Start screen**: choose between measurement run or result processing; selection opens respective form and closes start window.【F:CVR-10/frmStart.vb†L1-L39】
- **Measurement workflow (frmMeasurement)**
  - Load/save settings (poll interval, graph speed, KG step, COM port, core project) from Windows registry; updates timers, numeric controls and graph limits on load; persist on exit.【F:CVR-10/frmMeasurement.vb†L5-L101】
  - Menus/toolbar for help placeholder, back to start, exit, About dialog; dynamic menu population for core type and COM port selection with check marks; enables DB creation when core selected and allows starting device polling when COM chosen.【F:CVR-10/frmMeasurement.vb†L104-L180】
  - Settings apply handler validates numeric inputs and updates in-memory settings affecting timers and step controls.【F:CVR-10/frmMeasurement.vb†L182-L199】
  - Device I/O (not fully shown in snippet) covers serial polling of CVR-10, continuous/averaged data capture, graphing (KSP widgets), KG positioning, timers `tmrContRec` / `tmrGraph`, and DB insertions via clsDataWorks (based on prior repo summary).
- **Calculation workflow (frmCalculation)**
  - Registry persistence for temperature/step and chart grid options; initializes dataset from clsDataWorks on load.【F:CVR-10/frmCalculation.vb†L3-L69】
  - Open existing Access DB via dialog; dw sets path, initializes datasets, merges continuous data, derives core type metadata; updates labels with counts/time ranges; toggles menu/toolbar availability; provides disconnect handler clearing UI grids and labels.【F:CVR-10/frmCalculation.vb†L71-L198】
  - Subsequent processing (not fully shown) generates Excel workbook with charts/tables from working DB (per previous analysis), showing progress to user.
- **Data layer and calculations**
  - `clsDataWorks` loads system DB `SysDb.usr` (Jet 4.0) into datasets with relations for action types, core/kG mappings, etc.; exposes getters and work path property for user DB; prepares auto-increment seeds.【F:CVR-10/clsDataWorks.vb†L1-L200】
  - `modCalc` buffers time/temperature/reactivity samples, accumulates sums, computes linear regression (K/ B coefficients) and averages for the last sample set; exposes global `lngStartTime` and `AddSample`/`CalcLastSample`.【F:CVR-10/modCalc.vb†L1-L114】

## 2. Dependency map
- **Runtime/SDK**: .NET Framework WinForms with VB.NET; uses kernel32 `SetProcessWorkingSetSize` P/Invoke to trim working set in measurement and calculation forms.【F:CVR-10/frmMeasurement.vb†L28-L66】【F:CVR-10/frmCalculation.vb†L12-L36】
- **Storage**: Microsoft Jet OLE DB 4.0 (optionally ACE 12.0 commented) for Access databases (`SysDb.usr` system DB and per-experiment user DB). Dataset relations include ActionTypes, CoreTypes, KgTypes, MovedKg, etc.【F:CVR-10/clsDataWorks.vb†L1-L200】
- **Device I/O**: SerialPort connection to CVR-10 hardware (binary 32-byte packets) with COM port selection and start/stop controls (detailed elsewhere in frmMeasurement.vb).
- **Office automation**: Microsoft Office Interop for Excel workbook generation during results processing (see project references in bin/obj and prior analysis).
- **Registry**: Settings stored under `HKCU\CVR-10_PhysNet_OKBM` for both measurement and calculation parameters.【F:CVR-10/frmMeasurement.vb†L74-L101】【F:CVR-10/frmCalculation.vb†L41-L69】
- **UI assets**: GIF/PNG/ICO resources for buttons/backgrounds (Resources folder) referenced by forms.

## 3. Proposed C++/Qt6 architecture
- **Solution layout**
  - `cvr10-app/` (Qt Widgets application, CMake-based, C++20)
  - `src/ui/` QWidget/QMainWindow subclasses for start screen, measurement window, calculation window, About dialog.
  - `src/device/` serial communication layer using `QSerialPort`, binary packet parsing, polling timers, buffering.
  - `src/data/` data access abstraction for system/work databases via Qt SQL (`QSqlDatabase` with `QODBC`/`QSQLITE` depending on Access driver strategy or alternative format), dataset models, and migration helpers.
  - `src/analysis/` equivalents of `modCalc` regression/averaging routines, computation pipelines for derived metrics.
  - `src/export/` Excel export using `QtXlsx` or CSV+LibreOffice compatible output; chart generation via `QtCharts` or Xlsx drawing; includes progress reporting.
  - `src/settings/` wrapper over `QSettings` to replace registry usage.
  - `src/resources/` icons/images in Qt resource system (.qrc).
  - `tests/` for unit tests (QTest) and integration harness for serial + DB mocks.
- **Key principles**
  - Separate UI from logic via controllers/services; UI widgets call services for serial, DB, export.
  - Central `AppContext` holds settings, resource paths, and shared services.
  - Use model-view (QAbstractTableModel) for displaying datasets instead of ad-hoc DataGridView binding.

## 4. Verification plan
- **Functional checklist** mapped from inventory: start navigation; registry/settings persistence; COM port selection and polling; continuous/averaged capture; KG step control and drawing; Access DB creation/open; dataset relations; calculation parameters; Excel export with charts/tables; progress dialogs; About/help dialogs.
- **Golden data**: capture sample serial packet streams and expected parsed values; store sample Access DBs and expected computed metrics/graphs; exported Excel/CSV golden files for regression.
- **Automated tests**
  - Unit tests for packet parsing, averaging/regression math (compare to VB outputs), settings read/write, DB schema creation.
  - Integration tests using mocked serial port and temporary DB to validate continuous/average recording flows.
- **Manual scenarios**: end-to-end measurement session with live/mocked device; DB creation and later processing to Excel; UI navigation and menu actions; resource rendering.

## 5. Migration plan (incremental PRs)
1. **Scaffold Qt project**: set up CMake, Qt modules (Widgets, SerialPort, Sql, Charts/Xlsx dependency decision), resource import; stub windows replicating navigation only.
2. **Settings port**: implement QSettings-based persistence; map to existing fields (poll interval, graph speed, KG step, calculation dT parameters, COM selection).
3. **Data layer**: design schema migration strategy (Access via ODBC, or convert to SQLite); implement system/work DB loaders, relations, and creation utilities; import of existing `.usr` data if needed.
4. **Device communication**: port serial polling, packet parsing, timers; integrate live graphs and buffer for averaging; hook into data layer for continuous/averaged writes.
5. **Measurement UI parity**: implement controls, KG drawing, menu/toolbar actions, About/help placeholders; ensure start/back navigation.
6. **Analysis UI and export**: load DB, show stats, compute metrics via `analysis` module, generate Excel/CSV with charts; progress reporting.
7. **Testing & stabilization**: build automated tests, golden-file comparisons, and manual validation; finalize packaging/runtime instructions.

## Files analyzed
- `CVR-10/frmStart.vb`
- `CVR-10/frmMeasurement.vb`
- `CVR-10/frmCalculation.vb`
- `CVR-10/clsDataWorks.vb`
- `CVR-10/modCalc.vb`

## Build/run commands (current repo)
- Legacy VB.NET solution build (Windows): `msbuild CVR-10.sln /p:Configuration=Release`
- Future Qt project (planned): `cmake -S . -B build -D CMAKE_PREFIX_PATH=<Qt-6.9.1>` then `cmake --build build` and run `./build/cvr10-app`.
