# AsyncBridge release notes

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## v0.3.0

This release contains a critical fix. It also unifies AsyncBridge.Net35 and AsyncBridge.Portable into the main AsyncBridge package.

Building the repo from source is now possible. It requires Visual Studio 2017.

### Deprecated

- AsyncBridge.Net35 and AsyncBridge.Portable packages are officially deprecated. You should switch to using the main AsyncBridge package which now does the work of all three packages.  
  They are still updated as part of this release. This allows update notifications appear in consuming projects and it allows the package metadata to be updated to reflect the deprecation and point you to the unified AsyncBridge package. The assemblies they contain are still binary-compatible with their previous versions. These deprecated packages contain the fixes and changes in this release but they will not be updated in any future release.

### Fixed

- [Critical bug which rendered `.ConfigureAwait(false)` useless](https://github.com/OmerMor/AsyncBridge/issues/7)

- Now publishing optimized assemblies rather than debug assemblies

- [A strong-name signed net40 assembly is available for the first time.](https://github.com/OmerMor/AsyncBridge/issues/5#issuecomment-355767383)
  (Strong-named assemblies have been available for both net35 and portable since 2012.)

- AsyncBridge.Portable.dll moved from `/lib` to the appropriate `/lib/portable-net40+sl5`

- Copyright notices and attributions

### Added

- The main AsyncBridge package now ships with new targets besides `net40-client`:  
  `net35-client`, moved from the now-deprecated AsyncBridge.Net35 package  
  `portable-net40+sl5`, moved from the now-deprecated AsyncBridge.Portable package  
  `net45`, empty so that projects which multi-target don’t pick up the `net40-client` reference for target frameworks which already include async support

- Now publishing PDBs in the main package in the modern ‘portable’ PDB format which have the source files embedded.  
  (Debugging into embedded source requires Visual Studio 2017 Update 5 and is as easy as turning off Just My Code and [making sure PDBs are copied to build output](https://github.com/dotnet/sdk/issues/1458#issuecomment-344422574).)

### Known issues

- [(net35) System.Threading polyfill dependency incorrectly flows SynchronizationContext](https://github.com/OmerMor/AsyncBridge/issues/12)  
  This has always been a problem with https://www.nuget.org/packages/TaskParallelLibrary/1.0.2856.
