# GitHub Copilot Instructions for Agrivoltaic Solar Panel Mod

## Mod Overview and Purpose

The **Agrivoltaic Solar Panel** mod introduces a novel type of solar panel to RimWorld, designed for placement over crops to maximize space usage on your colony. These panels offer an immersive way to harness solar energy while maintaining agricultural productivity, by sharing space with crops.

- **Mod Name**: Agrivoltaic Solar Panel
- **Mod Author**: Mlie, with initial concept and graphics by HydromancerX
- **Package ID**: Mlie.AgrivoltaicSolarPanel

The panels are intended to balance efficiency with spatial ingenuity, having slightly higher installation costs due to elevated placement on poles. While their physical footprint is 1x1, they are visually represented in a 5x5 grid to symbolize their elevated height, allowing visibility of the crops beneath.

## Key Features and Systems

- **Hybrid Space Utilization**: Enables efficient colonist use of space by combining solar energy production with agriculture.
- **Elevated Design**: The panels are set at a height allowing sunlight to penetrate and nourish underlying crops.
- **Strategic Placement**: Consideration of panel placement is vital, as they cannot be installed near other tall structures.

## Coding Patterns and Conventions

- **C# Naming Conventions**: 
  - Types and members follow PascalCase notation for clarity and readability.
  - Private fields are prefixed with an underscore (`_`) for distinction.
  - Interface names are prefixed with an 'I'.

- **Structure and Organization**: 
  - Each class is contained in its own file, aligning with single responsibility principle.
  - Consistent use of regions (`#region`) for organizing methods and properties within classes.

## XML Integration

- **XML File**: `Buildings_Solar.xml` located in the `TranslationTemplate/ThingDef` directory.
- **Key Elements**: Defines and integrates new building types leveraging RimWorld's existing XML schema.
- **ThingDef Usage**: Ensure that new definitions align with in-game mechanics such as power output and placement constraints, enriching player environment.

## Harmony Patching

- **Harmony**: Utilized for runtime modifications, providing functionality to dynamically customize existing game logic without editing original source code.
- **Patch Applications**: Modifies place workers and attributes, ensuring suitable environmental considerations.

## Suggestions for GitHub Copilot

1. **Code Suggestions**:
   - Use Copilot to autocomplete for RimWorld-specific classes and methods, aiding in seamless integration.
   - Suggest improvements in code logic, especially around Harmony patching and XML file structures.

2. **Error Checks**:
   - Automatically detect typical mistakes in C# like uninitialized variables or malformed XML tags.

3. **Efficiency Improvements**:
   - Recommend best practices for optimizing performance impacts of additions, especially for heavy graphical rendering.

4. **Documentation Enhancements**:
   - Generate succinct code comments and summaries, amplifying understandability for future development and mod updates.

Through these guidelines, leveraging GitHub Copilot can substantially streamline the mod development process for **Agrivoltaic Solar Panels**, enhancing coder productivity and output efficacy.

This `copilot-instructions.md` should equip developers with a comprehensive understanding of your mod's framework, facilitating collaborative development with AI assistance in a way that is both contextually aware and functionally impactful.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

