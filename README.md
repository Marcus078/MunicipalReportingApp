# South African Municipal Services Portal (Part 1 - Report Issues)

## Project Overview
The South African Municipal Services Portal is a C# .NET Windows Forms application designed to improve citizen engagement and streamline municipal service reporting. Part 1 enables residents to log service issues (e.g., sanitation, road repairs, electricity outages), attach supporting documentation, and track their report completion through a gamified engagement progress bar.

---

## Features
- **Main Portal Navigation (`Form1.cs`):** Entry point providing navigation to reporting options, with placeholders for future phases (Local Events and Service Status).
- **Issue Reporting Screen (`ReportIssuesForm.cs`):** 
  - Location input text field.
  - Predefined category selection dropdown.
  - Detailed description rich text box.
  - Media attachment handler (`OpenFileDialog`) supporting `.jpg`, `.png`, `.pdf`, `.docx`.
  - Dynamic user engagement feature tracking real-time completion progress (0% to 100%).
- **In-Memory Data Storage:** Uses `List<ServiceRequest>` to store issues during runtime.

---

## Prerequisites
- Visual Studio 2022 (or 2019) with the **.NET Desktop Development** workload installed.
- .NET Framework 4.8 or .NET 6.0/8.0 (Windows Desktop runtime).

---

## How to Compile and Run
1. **Open Project:**
   - Launch Visual Studio.
   - Select **File > Open > Project/Solution** and open `MunicipalityAppPoe.sln`.
2. **Build Solution:**
   - Click **Build** in the top menu bar, then select **Build Solution** (or press `Ctrl + Shift + B`).
3. **Run Application:**
   - Click the green **Start** button (or press `F5`).

---

## How to Use the Application
1. On startup (`Form1`), click **Report Issues**.
2. Fill in the issue details:
   - Enter the location/address.
   - Select a service category from the dropdown menu.
   - Provide a description of the issue.
   - (Optional) Click **Attach Image / Document** to upload supporting media.
3. Observe the dynamic **Engagement Progress Bar** update in real time as fields are completed.
4. Click **Submit Report** to finalize the request and view your unique Reference ID.
5. Click **← Back to Main Menu** to return to the startup screen.
