# Dev ToolBox

## Overview
Dev ToolBox is a collection of handy utilities designed to assist developers with common tasks such as calculations, conversions, formatting, and more.

## Features

### Calculator
- **Simple Calculator**: Perform basic arithmetic operations.
- **Compound Interest Calculator**: Calculate the future value of an investment with compound interest.
- **Percentage Calculator**: Easily compute percentage-based calculations.

### Converters
- **String Converter**: Convert text between different formats.
- **Time Converter**: Convert between different time units.
- **Temperature Converter**: Convert temperatures between Celsius, Fahrenheit, and Kelvin.
- **Speed Converter**: Convert between different speed units (m/s, km/h, mph, etc.).
- **Color Converter**: Convert colors between RGB, RGBA, and Hex formats.

### Miscellaneous Tools
- **Diff Viewer**: Compare two pieces of text and highlight differences.
- **Regex Checker**: Test and validate regular expressions.
- **JSON Formatter & Validator**: Format and validate JSON data.
- **URL Parser**: Extract components from a URL.
- **Sort & Dedupe Line**: Sort lines of text and remove duplicates.
- **QR Code Generator**: Generate QR codes from text input.
- **Duplicate File Finder**: Scan a directory and identify duplicate files.
- **Password Generator**: Generate secure passwords with customizable options.
- **Dark Mode/Theme Editor**: Customize the app's theme and toggle between light and dark modes.

## Installation
1. Download the latest release from the Releases section.
2. Run the installer.
3. Launch the application and start using the tools.

## How to Build and Run

### Prerequisites

.NET SDK 8.0 or later.

Visual Studio (optional, for development).

### Steps to Build Locally

Clone the repository:

git clone https://github.com/your-username/Dev_ToolBox.git
cd Dev_ToolBox

Build the application:

dotnet build -c Release

Run the application:

dotnet run -c Release

### Automated GitHub Build

The project is configured with GitHub Actions to automatically build and publish the application:

On every push, the app is built.

If the build succeeds, a new release is created with the executable package.
