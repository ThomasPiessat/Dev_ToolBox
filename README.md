## Dev ToolBox

Dev ToolBox is a versatile WPF-based desktop application that provides a suite of tools to assist with everyday development and productivity tasks. Its intuitive interface and modular design make it easy to use, whether you're a seasoned developer or a beginner.

## Features

### 1. String Converter

- Convert text to lowercase, UPPERCASE, PascalCase, snake_case, camelCase, and kebab-case.

### 2. Percentage Calculator

- Perform percentage-based calculations:

- Calculate percentage increase/decrease.

- Find variation between two numbers.

- Compute compound interest with additional contributions and display the total interest earned.

### 3. Diff Viewer

- Compare two blocks of text to identify differences.

- Highlights added, removed, and modified lines.

### 4. QR Code Generator

- Generate a QR code from a pasted URL or text.

- Save the QR code as an image.

### 5. Regex Checker

- Test and validate regular expressions.

- View matches and groups in real-time.

### 6. Time Converter

- Convert time between various units (seconds, minutes, hours, days).

- User-friendly interface for quick conversions.

### 7. URL Parser

- Parse URLs to extract components like protocol, hostname, path, query parameters, and fragments.

### 8. Basic Calculator

- Perform simple arithmetic operations (addition, subtraction, multiplication, division).

- Clear interface with responsive design.

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
